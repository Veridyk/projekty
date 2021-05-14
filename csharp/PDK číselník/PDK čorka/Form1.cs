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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace PDK_čorka
{
    public partial class Form1 : Form
    {
        const int ROW_COUNT = 20;
        List<Item> m_items = new List<Item>();
        public Form1()
        {
            InitializeComponent();
        }

        public void InitSocket()
        {
            WebClient wc = new WebClient();
            for (int i = 0; i < 60; i++)
            {
                string data = wc.DownloadString("https://www.pharmdata.cz/pdk/browse_vip.php?result_count=35335&page=" + i.ToString());
                CutData(data);
                System.Threading.Thread.Sleep(3000);
            }
            toExcel();
        }

        private void toExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int idx = 1;
            foreach (Item it in m_items)
            {
                xlWorkSheet.Cells[idx, 1].NumberFormat = "@";
                xlWorkSheet.Cells[idx, 1] = it.KodPDK;
                xlWorkSheet.Cells[idx, 2] = it.Nazev;
                xlWorkSheet.Cells[idx, 3] = it.Pojistovna;
                xlWorkSheet.Cells[idx, 4] = it.SUKL;
                xlWorkSheet.Cells[idx, 5] = it.Vyrobce;
                idx++;
            }

            xlWorkBook.SaveAs("ciselnik_PDK.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Uloženo v dokumentech.");
            m_items.Clear();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CutData(string data)
        {
            for (int i = 0; i < ROW_COUNT; i++)
            {
                string finder = "line_" + i.ToString();
                int first = data.IndexOf(finder) + finder.Length;
                data = data.Remove(0, first);

                first = data.IndexOf("<td>") + "<td>".Length;
                data = data.Remove(0, first);

                //kod
                int end = data.IndexOf("<td>") - "<td>".Length - 1;
                string Kod = data.Substring(0, end);

                //mazani
                data = data.Remove(0, end);
                first = data.IndexOf("<td>") + "<td>".Length;
                data = data.Remove(0, first);
                //Nazev
                end = data.IndexOf("</td>");
                string Nazev = data.Substring(0, end);

                //mazani
                first = data.IndexOf("<td>") + "<td>".Length;
                data = data.Remove(0, first);

                first = data.IndexOf("<td>") + "<td>".Length;
                data = data.Remove(0, first);
                first = data.IndexOf("<td>") + "<td>".Length;
                data = data.Remove(0, first);

                //Vyrobce
                end = data.IndexOf("</td>");
                string Vyrobce = data.Substring(0, end);

                Item it = new Item(Kod, Nazev, "", "", Vyrobce);
                m_items.Add(it);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitSocket();
        }
    }
}
