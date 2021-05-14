using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace reporty
{
    public partial class ItemForm : Form
    {
        int ID;
        OleDbConnection Connection;
        OrderForm Parent;

        public ItemForm(int id, OleDbConnection connection, OrderForm parent)
        {
            InitializeComponent();
            ID = id;
            Connection = connection;
            Parent = parent;

            LoadItems(id, connection);
        }

        private void LoadItems(int id, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM OrderItems WHERE ID = " + ID, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            polozka.Text = dt.Rows[0][1].ToString();
            popis.Text = dt.Rows[0][2].ToString();
            popis2.Text = dt.Rows[0][3].ToString();
            vymera.Text = dt.Rows[0][4].ToString();
            mj.Text = dt.Rows[0][5].ToString();
            cena.Text = dt.Rows[0][6].ToString();

            decimal Total = Convert.ToDecimal(dt.Rows[0][6]) * Convert.ToDecimal(dt.Rows[0][4]);
            celkem.Text = Total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal Total = 0;
            if (Convert.ToDecimal(celkem.Text) > 0)
            {
                Total = Convert.ToDecimal(celkem.Text);
            }
            else
            {
                Total = Convert.ToDecimal(vymera.Text) * Convert.ToDecimal(cena.Text);
            }

            OleDbCommand cmd = new OleDbCommand("UPDATE OrderItems SET Item = ?, Item_Sub = ?, Item_Sub2 = ?, SizeMJ =?, Unit = ?, Price = ?, TotalPrice = ? WHERE ID = " + ID, Connection);
            cmd.Parameters.AddWithValue("?",polozka.Text);
            cmd.Parameters.AddWithValue("?", popis.Text);
            cmd.Parameters.AddWithValue("?", popis2.Text);
            cmd.Parameters.AddWithValue("?", vymera.Text);
            cmd.Parameters.AddWithValue("?", mj.Text);
            cmd.Parameters.AddWithValue("?", cena.Text);
            cmd.Parameters.AddWithValue("?", Total.ToString());
            cmd.ExecuteNonQuery();

            Parent.RefreshGrid();
        }
    }
}
