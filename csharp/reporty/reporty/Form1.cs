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
    public partial class Form1 : Form
    {
        OleDbConnection Connection;
        public Form1()
        {
            InitializeComponent();
        }

        private Boolean isConnected()
        {
            return Connection.State == ConnectionState.Open;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT OrderName, Building, Company, Invest, Address, Contact FROM Orders WHERE ID = " + id, Connection);
                DataTable ds = new DataTable();
                adapter.Fill(ds);

                adapter = new OleDbDataAdapter("SELECT * FROM OrderItems WHERE OrderID = " + id, Connection);
                DataTable ds2 = new DataTable();
                adapter.Fill(ds2);
                OrderView ov = new OrderView();
                ov.Database.Tables[1].SetDataSource(ds);
                ov.Database.Tables[0].SetDataSource(ds2);
                //ov.Database.Tables[0].SetParameterValue("DPH",15);

                View viewer = new View(ov);
                viewer.Show();
            }
            else
            {
                MessageBox.Show("Chyba připojení k databázi. Restartujte aplikaci.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.accdb;Persist Security Info=False;");
            if (!isConnected())
                Connection.Open();

            LoadOrders();
        }

        private void LoadOrders()
        {
            if (isConnected())
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM ORDERS", Connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dt.Columns[0].ColumnName = "Evidenční číslo";
                dt.Columns[0].ReadOnly = true;
                dt.Columns[1].ColumnName = "Název nabídky";
                dt.Columns[2].ColumnName = "Stavba";
                dt.Columns[3].ColumnName = "Firma";
                dt.Columns[4].ColumnName = "Investor";
                dt.Columns[5].ColumnName = "Adresa";
                dt.Columns[6].ColumnName = "Kontakt";


                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Chyba připojení k databázi. Restartujte aplikaci.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERS (OrderName, Building, Company, Invest, Address, Contact) VALUES('Testovací nabídka', 'Tišnov', 'Moje firma', '', 'Tišnov ok', '666 666 66')", Connection);
            cmd.ExecuteNonQuery();*/

            OleDbCommand cmd = new OleDbCommand("INSERT INTO OrderItems (Item, Item_Sub, Item_Sub2, Size, Unit, Price, TotalPrice, OrderID) VALUES ('Testovací položka','Pol 2', 'Pol 3', 100, 'm2', 6000, 0, 2)", Connection);
            cmd.ExecuteNonQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenOrder();
        }

        private void OpenOrder()
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (id != -1)
            {
                OrderForm orderForm = new OrderForm(id, Connection, this);
                orderForm.Show();
            }
        }
        
        public void RefreshGrid()
        {
            LoadOrders();
            dataGridView1.Refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERS (OrderName, Building, Company, Invest, Address, Contact) VALUES('', '', '', '', '', '')", Connection);
            cmd.ExecuteNonQuery();
            RefreshGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadOrders();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERS (OrderName, Building, Company, Invest, Address, Contact) VALUES(@OrderName, @Building, @Company, @Invest, @Address, @Contact)", Connection);
            cmd.Parameters.AddWithValue("@OrderName", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[1].Value;
            cmd.Parameters.AddWithValue("@Building", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[2].Value;
            cmd.Parameters.AddWithValue("@Company", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[3].Value;
            cmd.Parameters.AddWithValue("@Invest", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[4].Value;
            cmd.Parameters.AddWithValue("@Address", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[5].Value;
            cmd.Parameters.AddWithValue("@Contact", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[6].Value;
            cmd.ExecuteNonQuery();
            
            RefreshGrid();

            /*int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Item, Item_Sub, Item_Sub2, SizeMJ, Unit, Price, TotalPrice FROM OrderList WHERE ID = " + id, Connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach(DataRow dr in dt)
            {
                dr.Table.Columns[5].ColumnName
            }*/
            //cmd2.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            OleDbCommand cmd = new OleDbCommand("DELETE FROM ORDERS WHERE ID =" + id, Connection);
            cmd.ExecuteNonQuery();

            cmd = new OleDbCommand("DELETE FROM OrderItems WHERE OrderID =" + id, Connection);
            cmd.ExecuteNonQuery();

            RefreshGrid();
        }

    }
}
