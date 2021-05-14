using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KPG
{
    class FileManager
    {
        public static string LoadSentence(string path)
        {
            string output = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string data = sr.ReadLine();
                if (data != null)
                {
                    string[] param = data.Split('#');
                    output = param[0];
                    Config.GetConfig(param[1], Convert.ToInt32(param[2]));
                }

                sr.Close();
            }

            return output;
        }
    }

    class Log
    {
        private static Log m_looger = null;
        List<string> Data = new List<string>();

        public static Log GetLogger()
        {
            if (m_looger == null)
            {
                m_looger = new Log();
            }

            return m_looger;
        }

        public void LogData(string message)
        {
            Data.Add(message);
        }

        public void SaveLog()
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            foreach (string message in Data)
            {
                sw.WriteLine(message);
            }

            sw.Close();
        }
    }

    class Config
    {
        private static Config m_config = null;
        public string Host { get; set; }
        public int Port { get; set; }

        private Config(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public static Config GetConfig(string host, int port)
        {
            if (m_config == null)
                m_config = new Config(host, port);

            return m_config;
        }

        public static Config GetConfig()
        {
            return m_config;
        }
    }
}
