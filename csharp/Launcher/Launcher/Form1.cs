using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button4.ImageList = imageList1;
            button4.Image = button4.ImageList.Images[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Image = button4.ImageList.Images[1];
        }
    }
}
