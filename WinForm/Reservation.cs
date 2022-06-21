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

        long TempTotal;
        long TempHargaKamar;
        long CancelItem;
        long CancelKamar;

        long Harga;
        long Total;
        long TotalItemAsli;
        long Jumlah;
        int Price;
        long TotalKamar;
        long TotalFix;
        long TotalFix2;
        long TotalMalam;
        long TotalItem;
        long jumlahMalam;
        //Hitung dan display total
        private void updateTotal(long HargaKamar, long HargaItem, bool isKamarDeleted = false, bool isItemDeleted = false)
        {
            /* MessageBox.Show(TotalKamar.ToString());
             MessageBox.Show(MalamBox.Value.ToString());
             MessageBox.Show(Price.ToString());
             MessageBox.Show(JumlahItem.ToString());

 */
            long TotalKamar;
            long TotalItem;

            TotalKamar = HargaKamar * MalamBox.Value;
            TotalItem = HargaItem * QtyBox.Value;
            // kamar * malam = totkamar
            // item * qty = totItem

            if (isKamarDeleted == false && isItemDeleted == false)
            {
                TempTotal += TotalKamar + TotalItem;
            }

            if (isKamarDeleted)
            {
                long tempDeleteKamar;
                tempDeleteKamar = CancelKamar * MalamBox.Value;
                TempTotal -= tempDeleteKamar;
            }
            if (isItemDeleted)
            {
                long tempDeleteItem;
                tempDeleteItem = CancelItem;
                //MessageBox.Show(tempDeleteItem.ToString());
                TempTotal -= tempDeleteItem;
                //apa gitu
            }
            TotalBayarLBL.Text = TempTotal.ToString();
        }
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
            long TotKamar = 0;
            foreach (DataGridViewRow kamar in dataGridView4.Rows)
            {
                string rawText = kamar.Cells["RoomPrice"].Value.ToString();
                
                TotKamar += (TotalKamar + int.Parse(rawText))-TotalKamar;
            }

            updateTotal(TotKamar, 0);
            
/*            TotalFix2 = TotalFix2 + TotalKamar;
            TotalFix = TotalFix + TotalFix2;
            TotalBayarLBL.Text = TotalFix.ToString();
*/  
            //updateTotal();
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

                CancelKamar = long.Parse(dataGridView4.Rows[row.Index].Cells["RoomPrice"].FormattedValue.ToString());
                /*MessageBox.Show(CancelKamar.ToString());*/
                /*TotalFix2 = TotalFix2 - CancelKamar;
                TotalBayarLBL.Text = TotalFix2.ToString();*/
                updateTotal(0, 0, true);
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

                // --------------------------- MENAMBAHKAN HARGA BARANG KE DATA GRID ------------------------------
                while (row.Read())
                {
                    Price = int.Parse( row["RequirePrice"].ToString());
                    Total = Price * QtyBox.Value;
                    /*JumlahItem = QtyBox.Value;*/
                    
                }
                
                //cmd.Parameters.AddWithValue("@Name");
                string[] InputData = {"",ItemCB.Text, QtyBox.Value.ToString(), RoomNumberBox.Text, Total.ToString()};
                dataGridView5.Rows.Add(InputData);

                // --------------------------- MENAMBAHKAN HARGA ITEM KE TOTAL BAYAR ----------------------------
                long TotItem = 0;
                foreach (DataGridViewRow dgvRow in dataGridView5.Rows)
                {
                    TotItem = int.Parse(row["RequirePrice"].ToString());
                    /*
                    Total = Price * QtyBox.Value;
                    
                    Harga = (Harga + long.Parse(Total.ToString()))-Harga;
                    Harga += Total;

                    TotalItem = Harga;
                    //MessageBox.Show(TotalItem.ToString());
                    */
                }
                updateTotal(0, TotItem);

                /*Jumlah += TotalItem;
                TotalFix += Jumlah + TotalKamar;
                TotalBayarLBL.Text = TotalFix.ToString();*/
                // ----------------------------------------------------------------------------------------------
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
                
                CancelItem = long.Parse(dataGridView5.Rows[e.RowIndex].Cells["HargaItem"].Value.ToString());
                /*TotalFix = TotalFix - int.Parse(rawText);
                TotalBayarLBL.Text = TotalFix.ToString();*/
                updateTotal(0, 0, false, true);
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

        private void gunaNumeric2_ValueChanged(object sender, EventArgs e)
        {
            //jumlahMalam = MalamBox.Value;
            //TotalFix2 = TotalFix2 + TotalMalam;
           
        }

        private void TotalBayarLBL_Click(object sender, EventArgs e)
        {

        }

        private void ItemCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            var chars = "0123456789";
            var stringChars = new char[5];
            var random = new Random();
            var CSID = new char[6];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
                CSID[i] = chars[random.Next(chars.Length)];
            }

            int CODE = int.Parse(new String(stringChars));
            int CustomerID = int.Parse(new String(CSID));

            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            try
            {
                string Query = "INSERT INTO reservation(ID, DateTime, EmployeeID, CustomerID, Code) VALUES (NULL,@DateTime,@EmployeeID,@CustomerID,@Code)";
     
                MySqlCommand cmd = new MySqlCommand(Query,conn);
                int EmployeeID = int.Parse(Login.GetUserID);
                var date = Convert.ToDateTime(DateTime.Text).ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@DateTime",date);
                cmd.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                cmd.Parameters.AddWithValue("@CustomerID",CustomerID);
                cmd.Parameters.AddWithValue("@Code",CODE);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Reservasi Berhasil");

                } else
                {
                    MessageBox.Show("Reservasi gagal");

                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
