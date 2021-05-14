using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
namespace KPG
{
    class TCPConnection
    {
        private static TcpClient m_client = null;

        public static TcpClient GetClient()
        {
            Config cfg = Config.GetConfig();

            if (m_client == null)
            {
                m_client = new TcpClient(cfg.Host, cfg.Port);
            }

            return m_client;
        }
    }

    class Sender {
        string Path;
        string Sentence;

        TcpClient Client;
        Log Logger;


        public Sender()
        {
            Path = "\\\\ap\\QI-klient\\Ostra-KPG\\Temporary_forklift.txt";
            Sentence = FileManager.LoadSentence(Path);
            Client = TCPConnection.GetClient();
            Logger = Log.GetLogger();
        }

        public void Run()
        {
            if (Sentence == null)
                Environment.Exit(0);

            byte[] data = Encoding.ASCII.GetBytes(Sentence);
            NetworkStream stream = Client.GetStream();
            stream.Write(data, 0, data.Length);
            
            data = new byte[256];
            string responseData = string.Empty;
            
            int bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Logger.LogData(responseData);
            stream.Close();

            Client.Close();
            Logger.SaveLog();
        }
    }
}
