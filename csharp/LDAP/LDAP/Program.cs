using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LDAP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Config.CreateConfig(args);
                ProcessInjector.Inject();
                List <dynamic> users = ADService.AttrToUser(ADService.FindAttributes());
                FileManager.CreateFile(users);
                Logger.GetLogger().CloseStream();
            }
            catch (Exception ex)
            {
                Logger.GetLogger().Write(ex.ToString());
                Logger.GetLogger().CloseStream();
            }

            ///Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
