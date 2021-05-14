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
    public partial class OrderForm : Form
    {
        OleDbConnection Connection;
        int ID;
        Form1 Parent;
        public OrderForm(int id, OleDbConnection connection, Form1 parent)
        {
            InitializeComponent();
            Connection = connection;
            ID = id;
            Parent = parent;
            LoadOrders(id, connection);
        }

        private void LoadOrders(int id, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM ORDERS WHERE ID = " + id, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            orderID.Text = dt.Rows[0][0].ToString();
            orderName.Text = dt.Rows[0][1].ToString();
            Building.Text = dt.Rows[0][2].ToString();
            Company.Text = dt.Rows[0][3].ToString();
            Invest.Text = dt.Rows[0][4].ToString();
            Address.Text = dt.Rows[0][5].ToString();
            Contact.Text = dt.Rows[0][6].ToString();

            LoadItems(id, connection);
        }

        private void LoadItems(int id, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM OrderItems WHERE OrderID = " + id, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dt.Columns[0].ColumnName = "Číslo položky";
            dt.Columns[0].ReadOnly = true;
            dt.Columns[1].ColumnName = "Položka";
            dt.Columns[2].ColumnName = "Popis 1";
            dt.Columns[3].ColumnName = "Popis 2";
            dt.Columns[4].ColumnName = "Výměra";
            dt.Columns[5].ColumnName = "MJ";
            dt.Columns[6].ColumnName = "Cena/MJ";
            dt.Columns[7].ColumnName = "Cena celkem";

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE Orders SET OrderName = @OrderName, Building = @Building, Company = @Company, Invest = @Invest, Address = @Address, Contact = @Contact WHERE ID = " + ID, Connection);

            cmd.Parameters.AddWithValue("@OrderName", OleDbType.VarChar).Value = orderName.Text;
            cmd.Parameters.AddWithValue("@Building", OleDbType.VarChar).Value = Building.Text;
            cmd.Parameters.AddWithValue("@Company", OleDbType.VarChar).Value = Company.Text;
            cmd.Parameters.AddWithValue("@Invest", OleDbType.VarChar).Value = Invest.Text;
            cmd.Parameters.AddWithValue("@Address", OleDbType.VarChar).Value = Address.Text;
            cmd.Parameters.AddWithValue("@Contact", OleDbType.VarChar).Value = Contact.Text;
            cmd.ExecuteNonQuery();

            Parent.RefreshGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERITEMS (Item, Item_Sub, Item_Sub2, SizeMJ, Unit, Price, TotalPrice, OrderID) VALUES ('','','',0,'',0,0," + ID + ")", Connection);
            cmd.ExecuteNonQuery();
            RefreshGrid();
        }

        ////////////////
        public void RefreshGrid()
        {
            LoadItems(ID, Connection);
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            OleDbCommand cmd = new OleDbCommand("DELETE FROM OrderItems WHERE ID =" + id,Connection);
            cmd.ExecuteNonQuery();
            RefreshGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            OleDbCommand cmd = new OleDbCommand("UPDATE OrderItems SET Item = @Item, Item_Sub = @Item_Sub, Item_Sub2 = @Item_Sub2, SizeMJ = @SizeMJ, Unit = @Unit, Price = @Price, TotalPrice = @TotalPrice, OrderID = @orderID WHERE ID = " + id, Connection);
            cmd.ExecuteNonQuery();
            RefreshGrid();*/

            /*int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO ORDERITEMS (Item, Item_Sub, Item_Sub2, SizeMJ, Unit, Price, TotalPrice, OrderID) VALUES (@Item,@Item_Sub,@Item_Sub2,@SizeMJ,@Unit,@Price,@TotalPrice," + ID+ ")", Connection);

            cmd.Parameters.AddWithValue("@Item", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmd.Parameters.AddWithValue("@Item_Sub", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[2].ToString();
            cmd.Parameters.AddWithValue("@Item_Sub2", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[3].ToString();
            cmd.Parameters.AddWithValue("@SizeMJ", OleDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
            cmd.Parameters.AddWithValue("@Unit", OleDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[5].ToString();
            cmd.Parameters.AddWithValue("@Price", OleDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[6].Value);
            cmd.Parameters.AddWithValue("@TotalPrice", OleDbType.Decimal).Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value);
            //cmd.Parameters.AddWithValue("@OrderID", OleDbType.Integer).Value = ID;

            cmd.ExecuteNonQuery();
            RefreshGrid();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            if (id != -1)
            {
                ItemForm orderForm = new ItemForm(id, Connection, this);
                orderForm.Show();
            }
        }
    }
}
