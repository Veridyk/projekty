using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace WebRipper
{
    public partial class Form1 : Form
    {
        OpenFileDialog o = new OpenFileDialog();
        Dictionary<int, LPTMON> m_mapMon = new Dictionary<int, LPTMON>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => start());
            t.Start();
        }

        public void start()
        {
            if (m_mapMon.Count <= 0)
                return;

            this.Invoke((MethodInvoker)(() => initProgress()));

            int counter = 0;
            foreach (KeyValuePair<int, LPTMON> pMon in m_mapMon) {

                WebClient cClient = new WebClient();
                String URI = cClient.DownloadString("https://cz.4story.gameforge.com/monster/details/" + pMon.Key.ToString());


                if (URI != "" || URI != null)
                {
                    string strKey = "<img class=\"avatar\" src=\"";
                    int nStart = URI.LastIndexOf(strKey);
                    int nEnd = URI.IndexOf(".jpg\"", nStart + strKey.Length);

                    string strFinalURI = "https:" + URI.Substring(nStart + strKey.Length, nEnd - nStart);
                    strFinalURI = strFinalURI.Trim();
                    strFinalURI = strFinalURI.Remove(strFinalURI.Length - 1);

                    try
                    {
                        ProcessImage(cClient, strFinalURI, pMon.Key);
                        this.Invoke((MethodInvoker)(() => addText("Image " + pMon.Key.ToString() + " was sucessfuly downloaded.")));
                    }
                    catch
                    {
                        this.Invoke((MethodInvoker)(() => addText("Couldn't find image " + pMon.Key.ToString() + ".")));
                    }
                }
                counter++;
                this.Invoke((MethodInvoker)(() => updateStatus("Downloaded: " + counter.ToString() + "/" + m_mapMon.Count.ToString())));
                this.Invoke((MethodInvoker)(() => progressBar1.Increment(1)));
            }

            this.Invoke((MethodInvoker)(() => updateStatus("Downloading finished")));
        }

        private void updateStatus(string strText)
        {
            label1.Text = strText;
        }

        private void initProgress()
        {
            progressBar1.Maximum = m_mapMon.Count;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
        }

        private void addText(string strText)
        {
            richTextBox1.Text += strText + "\n";
        }

        void ProcessImage(WebClient cImage, string URI, int nKey)
        {
            cImage.Headers["User-Agent"] = "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
            byte[] pData = cImage.DownloadData(URI);
            File.WriteAllBytes(@"ex\" + nKey.ToString() +".jpg", pData);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() != DialogResult.OK)
                return;

            using(BinaryReader br = new BinaryReader((Stream)File.Open(o.FileName, FileMode.Open)))
            {
                short wCount = br.ReadInt16();
                for(int i = 0; i< wCount; i++)
                {
                    LPTMON pMon = new LPTMON(br);
                    m_mapMon.Add(pMon.wMonID, pMon);
                }
                br.Close();
            }
            MessageBox.Show(m_mapMon.Count.ToString());
        }
    }
}
