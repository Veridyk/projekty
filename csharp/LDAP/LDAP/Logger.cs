using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LDAP
{
    class Logger
    {
        private static Logger m_logger = null;
        const string FileName = "AD_log.txt";

        private static StreamWriter fs;

        private Logger()
        {

        }

        public static Logger GetLogger()
        {
            if (m_logger != null)
                return m_logger;


            m_logger = new Logger();

            m_logger.InitStream();

            return m_logger;
        }

        private void InitStream()
        {
            if (!File.Exists(FileName))
            {
                var mf = File.Create(FileName);
                mf.Close();
            }

            fs = new StreamWriter(FileName, true);
        }

        public void Write(string text)
        {
            if (fs != null)
            {
                fs.WriteLine(text);
            }
            else
                throw new Exception("FileStream is null");
        }

        public void CloseStream()
        {
            if (fs != null)
            {
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
