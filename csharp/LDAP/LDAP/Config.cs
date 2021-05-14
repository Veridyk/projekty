using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
    public enum ARGS
    {
        ARG_IP = 0,
        ARGS_ATTR,
        ARGS_PATH
    } 

    class Config
    {
        private static Config m_config = null;
        private string m_ip;
        private string[] m_attributes;


        public static Config CreateConfig(string[] args)
        {
            m_config = GetConfig();
            m_config.m_ip = args[(int)ARGS.ARG_IP];
            m_config.m_attributes = m_config.ListToArray(args[(int)ARGS.ARGS_ATTR]);
            Environment.CurrentDirectory = args[(int)ARGS.ARGS_PATH];

            return m_config;
        }

        public static Config GetConfig()
        {
            if(m_config == null)
            {
                return new Config();
            }

            return m_config;
        }

        private string[] ListToArray(string list)
        {
            return list.Split(';');
        }

        public string GetIP()
        {
            return m_ip;
        }

        public string[] GetAttributes()
        {
            return m_attributes;
        }
    }
}
