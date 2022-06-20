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
    public partial class MasterRoom : UserControl
    {
        public MasterRoom()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";
        String QueryTypeCB = "SELECT * FROM roomtype";
        private void MasterRoom_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(QueryTypeCB, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader row;
            row = cmd.ExecuteReader();
            while (row.Read())
            {
                //int TypeItem = int.Parse(row["ID"].ToString());
                var NameType = row["Name"].ToString();
                TypeCB.Items.Add(NameType);
            }
            conn.Close();
            conn.Open();
            string Query = "SELECT RoomTypeID, RoomNumber, RoomFloor, Description FROM room";
            
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter(Query,conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;
            conn.Close();

        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int ID;
        private void ReservationBTN_Click(object sender, EventArgs e)
        {
            if (NoRuangan.Text != "" && TypeCB.Text != "" && LantaiRuangan.Text != "" && Deskripsi.Text != "")
            {
                MySqlConnection conn = new MySqlConnection(SQLConn);
                string Query =
                    "INSERT INTO room(ID, RoomTypeID, RoomNumber, RoomFloor, Description) VALUES (NULL,@RoomTypeID,@RoomNumber,@RoomFloor,@Description)";
                try
                {
                    //while(TypeCB.)
                    // ---------------------------------------------------------
                    conn.Open();
                    string nama = TypeCB.Text;
                    string NameQuery = "SELECT ID FROM roomtype WHERE Name='" + nama + "'";
                    MySqlDataReader row;
                    MySqlCommand NameTest = new MySqlCommand(NameQuery, conn);
                    NameTest.ExecuteNonQuery();
                    row = NameTest.ExecuteReader();
                    while (row.Read())
                    {
                        ID = int.Parse(row["ID"].ToString());
                    }

                    conn.Close();
                     // --------------------------------------------------------
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Query, conn);

                    cmd.Parameters.AddWithValue("@RoomTypeID", ID);
                    cmd.Parameters.AddWithValue("@RoomNumber", NoRuangan.Text);
                    cmd.Parameters.AddWithValue("@RoomFloor", LantaiRuangan.Text);
                    cmd.Parameters.AddWithValue("@Description", Deskripsi.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Kamar telah ditambahkan", "TiketKeun", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kamar gagal ditambahkan", "TiketKeun", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                    }
                    conn.Close();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            else
                { MessageBox.Show("Kolom masih kosong", "TiketKeun", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var TypeRoom = dataGridView1.Rows[e.RowIndex].Cells["RoomTypeID"].FormattedValue.ToString();
                MySqlConnection conn = new MySqlConnection(SQLConn);
                conn.Open();
                string Query =
                    "SELECT RoomTypeID, RoomNumber, RoomFloor, Description FROM room WHERE RoomTypeID=@RoomType";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@RoomType", TypeRoom);
                cmd.ExecuteNonQuery();
                MySqlDataReader row;
                row = cmd.ExecuteReader();
                while (row.Read())
                {
                    var TypeRuangan = row["RoomTypeID"].ToString();
                    var NomorRuangan = row["RoomNumber"].ToString();
                    var LRuangan = row["RoomFloor"].ToString();
                    var Desc = row["Description"].ToString();

                    NoRuangan.Text = NomorRuangan;
                    TypeCB.Text = TypeRuangan;
                    LantaiRuangan.Text = LRuangan;
                    Deskripsi.Text = Desc;

                }
                conn.Close();
                
            }
        }
    }
}
