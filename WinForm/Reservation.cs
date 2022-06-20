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
    public partial class Reservation : UserControl
    {
        public Reservation()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaRadioButton1.Checked)
            {
                gunaLabel10.Visible = true;
                gunaLabel11.Visible = true;
                NameBox.Visible = true;
                PhoneNumber.Visible = true;
                dataGridView2.Visible = false;
            }
        }
        long Harga;
        long Total;
        long Jumlah;
        long TotalKamar;
        long TotalFix;
        long TotalFix2;
        private void Reservation_Load(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(SQLConn);
            try
            {
                dataGridView2.Visible = false;
                gunaLabel10.Visible = false;
                gunaLabel11.Visible = false;
                NameBox.Visible = false;
                PhoneNumber.Visible = false;

                
                // -------------------------- MEMUAT DATA RUANGAN -------------------------------

                conn.Open();
                string Query = "SELECT room.RoomTypeID, roomtype.Name, room.RoomNumber, room.RoomFloor ,room.Description, roomtype.RoomPrice FROM room JOIN roomtype WHERE room.RoomTypeID=roomtype.ID";
                string QRoomType = "SELECT * FROM roomtype";
                string QRoomNumber = "SELECT * FROM room";
                string QItem = "SELECT Name FROM item";
                MySqlCommand cmd = new MySqlCommand(Query, conn);

                DataTable Table = new DataTable();
                MySqlDataAdapter DA = new MySqlDataAdapter(Query,conn);
                DA.Fill(Table);
                dataGridView1.DataSource = Table;
                conn.Close();

                // --------------------------- MEMUAT DATA TIPE RUANGAN ------------------------------
                
                conn.Open();
                MySqlCommand cmdRoomType = new MySqlCommand(QRoomType, conn);
                MySqlDataReader row;
                row = cmdRoomType.ExecuteReader();
                while (row.Read())
                {
                    string RoomType = row["Name"].ToString();
                    RoomTypeCB.Items.Add(RoomType);
                }
                conn.Close();

                // ---------------------------- MEMUAT DATA ITEM -----------------------------
                // --------------------------- MEMUAT DATA TIPE RUANGAN ------------------------------

                conn.Open();
                MySqlCommand cmdRoomNumber = new MySqlCommand(QRoomNumber, conn);
                MySqlDataReader RowRoomNumber;
                RowRoomNumber = cmdRoomNumber.ExecuteReader();
                while (RowRoomNumber.Read())
                {
                    string RNumber = RowRoomNumber["RoomNumber"].ToString();
                    RoomNumberBox.Items.Add(RNumber);
                }
                conn.Close();

                // ---------------------------- MEMUAT DATA ITEM -----------------------------

                conn.Open();
                MySqlCommand cmdItem = new MySqlCommand(QItem, conn);
                MySqlDataReader ItemRow;
                ItemRow = cmdItem.ExecuteReader();
                while (ItemRow.Read())
                {
                    string ItemName = ItemRow["Name"].ToString();
                    ItemCB.Items.Add(ItemName);
                }
                conn.Close();

                // ---------------------------------------------------------




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            //tring Query = "SELECT * FROM roomtype WHERE Name=@Name";
/*            MySqlCommand cmd = new MySqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@Name", RoomTypeCB.Text);
            var search = cmd.ExecuteNonQuery();*/
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter("SELECT room.RoomTypeID, roomtype.Name, room.RoomNumber, room.RoomFloor ,room.Description, roomtype.RoomPrice FROM room JOIN roomtype WHERE room.RoomTypeID=roomtype.ID AND roomtype.Name='" + RoomTypeCB.Text+"'", conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;



        }
        
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                this.dataGridView4.Rows.Add(rowData);
            }

            foreach (DataGridViewRow kamar in dataGridView4.Rows)
            {
                string rawText = kamar.Cells["RoomPrice"].Value.ToString();
                
                TotalKamar = (TotalKamar + int.Parse(rawText))-TotalKamar;
            }
            TotalFix2 = TotalFix2 + TotalKamar;
                 
            TotalBayarLBL.Text = TotalFix2.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
 
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                dataGridView4.Rows.RemoveAt(row.Index);
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            if (ItemCB.Text !="" && QtyBox.Value > 0  && RoomNumberBox.Text != "")
            {
                MySqlConnection conn = new MySqlConnection(SQLConn);
                string ItemSelect = ItemCB.Text;
                string Query = "SELECT * FROM item WHERE Name=@Name";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query,conn);
                cmd.Parameters.AddWithValue("Name", ItemSelect);
                cmd.ExecuteNonQuery();
                MySqlDataReader row;
                row = cmd.ExecuteReader();
                while (row.Read())
                {
                    int Price = int.Parse( row["RequirePrice"].ToString());
                    Total = Price * QtyBox.Value;
                }
                
                //cmd.Parameters.AddWithValue("@Name");
                string[] InputData = {"",ItemCB.Text, QtyBox.Value.ToString(), RoomNumberBox.Text, Total.ToString()};
                dataGridView5.Rows.Add(InputData);


                foreach (DataGridViewRow dgvRow in dataGridView5.Rows)
                {
                    string rawText = dgvRow.Cells["HargaItem"].Value.ToString();
                    Harga = (Harga + long.Parse(rawText))-Harga;  
                    
                }
                
                Jumlah = Jumlah + Harga;
                TotalFix = TotalFix2 + Jumlah;
                TotalBayarLBL.Text = TotalFix.ToString();
            } else
            {
                MessageBox.Show("Kolom masih kosong", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                
                string rawText = dataGridView5.Rows[e.RowIndex].Cells["HargaItem"].Value.ToString();
                TotalFix = TotalFix - int.Parse(rawText);
                TotalBayarLBL.Text = TotalFix.ToString();
                dataGridView5.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaRadioButton2.Checked)
            {
                gunaLabel10.Visible = false;
                gunaLabel11.Visible = false;
                NameBox.Visible = false;
                PhoneNumber.Visible = false;
                dataGridView2.Visible = true;
            }
        }
    }
}
