using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LDAP
{
    class FileManager
    {
        const string fileName = "osoby_import.txt";

        public static void CreateFile(List<dynamic> users)
        {
            if (!System.IO.File.Exists(fileName))
            {
                var mf = System.IO.File.Create(fileName);
                mf.Close();
            }


            using (StreamWriter fs = new StreamWriter(fileName, false))
            {
                foreach (dynamic d in users)
                    fs.WriteLine(GetLine(d));
                fs.Close();
            }
        }

        private static string GetLine(dynamic d)
        {
            string line = "";
            var byName = (IDictionary<string, object>)d;
            string[] attributes = Config.GetConfig().GetAttributes();

            foreach(string attr in attributes)
            {
                if (byName.ContainsKey(attr))
                {
                    string value = (string)byName[attr];
                    line += value + ";";
                }
                else
                {
                    line += ";";
                }
            }

            return line;
        }
    }
}
