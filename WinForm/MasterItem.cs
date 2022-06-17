using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Aplikasi_TiketKeun.WinForm
{
    public partial class MasterItem : UserControl
    {
        public MasterItem()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";
        private void MasterItem_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            try
            {
                conn.Open();
                string Query = "SELECT Name, RequirePrice, CompensationFee FROM item";
                DataTable Table = new DataTable();
                MySqlDataAdapter DA = new MySqlDataAdapter(Query, conn);
                DA.Fill(Table);
                dataGridView1.DataSource = Table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReservationBTN_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != "" && PriceBox.Text != "" && CompensationBox.Text != "")
            {
                string Query = "INSERT INTO item(ID, Name, RequirePrice, CompensationFee) VALUES (NULL,@Name,@RequirePrice,@CompensationFee)";
                string QueryItem = "SELECT Name, RequirePrice, CompensationFee FROM item";
                MySqlConnection conn = new MySqlConnection(SQLConn);
                conn.Open();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                    cmd.Parameters.AddWithValue("RequirePrice", int.Parse(PriceBox.Text));
                    cmd.Parameters.AddWithValue("CompensationFee", int.Parse(CompensationBox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item berhasil ditambahkan", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable Table = new DataTable();
                    MySqlDataAdapter DA = new MySqlDataAdapter(QueryItem, conn);
                    DA.Fill(Table);
                    dataGridView1.DataSource = Table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Mohon isi semua kolom", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE item SET Name=@Name,RequirePrice=@RequirePrice,CompensationFee=@CompensationFee WHERE Name=@Name";
            string QueryItem = "SELECT Name, RequirePrice, CompensationFee FROM item";
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                cmd.Parameters.AddWithValue("@RequirePrice", int.Parse(PriceBox.Text));
                cmd.Parameters.AddWithValue("@CompensationFee", int.Parse(CompensationBox.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item berhasil di update", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable Table = new DataTable();
                MySqlDataAdapter DA = new MySqlDataAdapter(QueryItem, conn);
                DA.Fill(Table);
                dataGridView1.DataSource = Table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

            new DeleteForm.DeleteItem().Show();
            
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["ItemCB"].Value);
                if (isSelected)
                {
                    MessageBox.Show("Clicked");
                }
            }
            /*  if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                  e.RowIndex >= 0)
              {

                  MySqlConnection conn = new MySqlConnection(SQLConn);
                  string Query = "SELECT * FROM item WHERE ID=@ID";
                  conn.Open();
                  *//*                conn.Open();
                                  int a = e.RowIndex;
                                  a = a + 1;
                                  MySqlCommand cmdRoomType = new MySqlCommand(Query, conn);
                                  cmdRoomType.Parameters.AddWithValue("@ID",a);
                                  MySqlDataReader row;

                                  row = cmdRoomType.ExecuteReader();
                                  row.Read();
                                  string RoomType = row["Name"].ToString();
                                  MessageBox.Show(RoomType);

                  *//*
                  int a = e.RowIndex;
                  a = a + 1;
                  MySqlCommand cmd = new MySqlCommand(Query,conn);
                  cmd.Parameters.AddWithValue("@ID", a.ToString());
                  cmd.ExecuteNonQuery();
                  MySqlDataReader row;
                  row = cmd.ExecuteReader();
                  while (row.Read())
                  {
                      string test = row["Name"].ToString();
                     */
            //MessageBox.Show(test);
                
                
                

            
            



        }
    }
}
