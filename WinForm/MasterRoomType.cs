using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_TiketKeun.WinForm
{
    public partial class MasterRoomType : UserControl
    {
        public MasterRoomType()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";
        private void MasterRoomType_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            try
            {
                conn.Open();
                string Query = "SELECT Name, Capacity, RoomPrice FROM roomtype";
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

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void ReservationBTN_Click(object sender, EventArgs e)
        {
            if (NamaRuangan.Text != "" && Kapasitas.Text !="" && HargaKamar.Text != "")
            {
                string Query = "INSERT INTO roomtype(ID, Name, Capacity, RoomPrice) VALUES (NULL,@Nama,@Capacity,@Price)";
                
                MySqlConnection conn = new MySqlConnection(SQLConn);
                try 
                { 
                
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@Nama", NamaRuangan.Text);
                    cmd.Parameters.AddWithValue("@Capacity", Kapasitas.Value);
                    cmd.Parameters.AddWithValue("@Price", int.Parse( HargaKamar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tipe kamar berhasil ditambahkan", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable Table = new DataTable();
                    MySqlDataAdapter DA = new MySqlDataAdapter("SELECT Name, Capacity, RoomPrice FROM roomtype", conn);

                    DA.Fill(Table);
                    dataGridView1.DataSource = Table;
                    conn.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } else
            {
                MessageBox.Show("Form masih kosong", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string Query = "SELECT * FROM roomtype WHERE Name=@TypeName";
                MySqlConnection conn = new MySqlConnection(SQLConn);
                try
                {
                    conn.Open();
                    var TypeName = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@TypeName", TypeName);
                    
                    cmd.ExecuteNonQuery();
                    MySqlDataReader row;
                    row = cmd.ExecuteReader();
                    while (row.Read())
                    {
                        string RoomName = row["Name"].ToString();
                        string Capacity = row["Capacity"].ToString();
                        string RoomPrice = row["RoomPrice"].ToString();
                        NamaRuangan.Text = RoomName;
                        Kapasitas.Value = int.Parse(Capacity);
                        HargaKamar.Text = RoomPrice;
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

            if (NamaRuangan.Text != "")
            {
                string Query = "DELETE FROM roomtype WHERE Name=@Name";



                MySqlConnection conn = new MySqlConnection(SQLConn);
                try
                {

                    var confirm = MessageBox.Show("Apakah Anda yakin?", "TiketKeun", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.OK)
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        cmd.Parameters.AddWithValue("@Name", NamaRuangan.Text);
                        //cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Type kamar telah dihapus", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable Table = new DataTable();
                            string DataQuery = "SELECT Name, Capacity, RoomPrice FROM roomtype";
                            MySqlDataAdapter DA = new MySqlDataAdapter(DataQuery, conn);
                            DA.Fill(Table);
                            dataGridView1.DataSource = Table;
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Type kamar gagal dihapus", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                MessageBox.Show("Tidak ada type kamar yang dipilih", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (NamaRuangan.Text != "" && Kapasitas.Text != "" && HargaKamar.Text != "")
            {
                string Query = "UPDATE roomtype SET Name=@Nama,Capacity=@Capacity,RoomPrice=@Price WHERE Name=@Nama";

                MySqlConnection conn = new MySqlConnection(SQLConn);
                try
                {

                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@Nama", NamaRuangan.Text);
                    cmd.Parameters.AddWithValue("@Capacity", Kapasitas.Value);
                    cmd.Parameters.AddWithValue("@Price", int.Parse(HargaKamar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tipe kamar berhasil diupdate", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable Table = new DataTable();
                    MySqlDataAdapter DA = new MySqlDataAdapter("SELECT * FROM roomtype", conn);

                    DA.Fill(Table);
                    dataGridView1.DataSource = Table;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Form masih kosong", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
