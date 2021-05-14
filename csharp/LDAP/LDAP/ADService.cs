using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Globalization;

namespace LDAP
{
    class ADService
    {
        public static DirectoryEntry m_service = null;

        public static DirectoryEntry GetService()
        {
            if (m_service != null)
                return m_service;

            string ldapServer = Config.GetConfig().GetIP();
            m_service = new DirectoryEntry(ldapServer);

            return m_service;
        }

        public static SearchResultCollection FindAttributes()
        {
            if (GetService() == null)
            {
                Logger.GetLogger().Write("Service is null. Failed connect to AD.");
            }

            DirectorySearcher searcher = new DirectorySearcher(GetService());

            searcher.PageSize = 10000;
            searcher.SearchScope = SearchScope.Subtree;

            searcher.Filter = "(&(employeeid=*)"
                + "(|(useraccountcontrol=512)"
                + "((useraccountcontrol=544))"
                + "((useraccountcontrol=66048))"
                + "((useraccountcontrol=66080))))";

            searcher.PropertiesToLoad.AddRange(
                Config.GetConfig().GetAttributes()
            ) ;

            return searcher.FindAll();  
        }

        public static List<dynamic> AttrToUser(SearchResultCollection rc)
        {
            List<dynamic> users = new List<dynamic>();
            if (rc != null)
            {
                string[] attributes = Config.GetConfig().GetAttributes();
                foreach (SearchResult sr in rc)
                {
                    if (sr.Properties["employeeid"] != null && sr.Properties["employeeid"].Count > 0)
                    {
                        dynamic u = new System.Dynamic.ExpandoObject();

                        foreach(string attr in attributes)
                        {
                            if (sr.Properties[attr] != null && sr.Properties[attr].Count > 0)
                            {
                                if (attr.ToLower() == "accountexpires")
                                {
                                    if(sr.Properties[attr][0].ToString() == "9223372036854775807")
                                    {
                                        ((IDictionary<string, object>)u)[attr] = "";
                                    }
                                    else if(sr.Properties[attr][0].ToString() == "0")
                                    {
                                        ((IDictionary<string, object>)u)[attr] = "";
                                        //((IDictionary<string, object>)u)[attr] = DateTime.Now.ToString("d");//ToString("dd'.'MM'.'yyyy", CultureInfo.InvariantCulture); ;
                                    }
                                    else
                                    {
                                        ((IDictionary<string, object>)u)[attr] = DateTime.FromFileTime(Convert.ToInt64(sr.Properties[attr][0].ToString())).ToString("d");//ToString("dd'.'MM'.'yyyy", CultureInfo.InvariantCulture); 
                                    }
                                }
                                else {
                                    ((IDictionary<string, object>)u)[attr] = sr.Properties[attr][0].ToString();
                                }
                            }
                        }

                        users.Add(u);
                    }
                }
            }
            else Logger.GetLogger().Write("No attributtes found!");

            return users;
        }
    }
}
