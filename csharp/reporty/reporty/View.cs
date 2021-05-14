using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reporty
{
    public partial class View : Form
    {
        OrderView mov;
        public View(OrderView ov)
        {
            InitializeComponent();
            //crystalReportViewer1.ReportSource = ov;
            mov = ov;
            //crystalReportViewer1.Refresh();
        }

        private void View_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = mov;
        }
    }
}
