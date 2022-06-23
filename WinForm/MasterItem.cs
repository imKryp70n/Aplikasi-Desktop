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
                conn.Close();

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
                conn.Close();
            } else
            {
                MessageBox.Show("Mohon isi semua kolom", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != "" && PriceBox.Text != "" && CompensationBox.Text !="") {
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
                conn.Close();
            } else
            {
                MessageBox.Show("Form masih kosong", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

            //new DeleteForm.DeleteItem().Show();
            MySqlConnection conn = new MySqlConnection(SQLConn);
            string Query = "DELETE FROM item WHERE Name=@Name";

            if (NameBox.Text != "")
            {
                try
                {
                    
                    var confirm = MessageBox.Show("Apakah Anda yakin?", "TiketKeun", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.OK)
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                        //cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Item telah dihapus", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable Table = new DataTable();
                            string DataQuery = "SELECT Name, RequirePrice, CompensationFee FROM item";
                            MySqlDataAdapter DA = new MySqlDataAdapter(DataQuery, conn);
                            DA.Fill(Table);
                            dataGridView1.DataSource = Table;
                            conn.Close();
                        } else
                        {
                            MessageBox.Show("Item gagal dihapus", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }


                    }
                    else
                    {

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Tidak ada item yang dipilih", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                
                MySqlConnection conn = new MySqlConnection(SQLConn);
                string Query = "SELECT * FROM item WHERE Name=@Name";

/*                // SCRIPT BUAT MENEMUKAN ID TERAKHIR
                string GetMaxID = "SELECT max(ID) as LastID FROM item";
                MySqlCommand GetID = new MySqlCommand(GetMaxID, conn);
                conn.Open();
                MySqlDataReader ID;
                ID = GetID.ExecuteReader();
                ID.Read();
                string LastID = ID["LastID"].ToString();
                //MessageBox.Show(LastID);
                conn.Close();*/
                // -------------------------------------------
                try
                {
                    conn.Open();
                    //MessageBox.Show(a.ToString());
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    var ItemName = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                    cmd.Parameters.AddWithValue("@Name", ItemName);
                    

                    MySqlDataReader row;
                    row = cmd.ExecuteReader();
                    //MessageBox.Show(row.Read().ToString());
                    while (row.Read()) { 
                        string ItemType = row["Name"].ToString();
                        string Price = row["RequirePrice"].ToString();
                        string Compensation = row["CompensationFee"].ToString();
                        
                        NameBox.Text = ItemType;
                        PriceBox.Text = Price;
                        CompensationBox.Text = Compensation;
                        

                    }
                    conn.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
