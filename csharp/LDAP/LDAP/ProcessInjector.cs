using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LDAP
{
    class ProcessInjector
    {
        public static void Inject()
        {
            string fileName = "AD_config.txt";

            using (StreamReader sr = new StreamReader(fileName, false))
            {
                while (sr.Peek() >= 0)
                {
                    string[] data = sr.ReadLine().Split('=');
                    if (data.Length == 2)
                        Environment.SetEnvironmentVariable(data[0], data[1]);
                }

                sr.Close();
            }
        }
    }
}
