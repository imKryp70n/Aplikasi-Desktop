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

        /*********************************************************
         * Inisialisasi variabel untuk penyimpanan global
         * 
         */

        long TempTotal;
        long CancelItem;
        long CancelKamar;

        long[] Total = new long[10];
        int Price;
        long TotalKamar;

        int hargaItemInc = 0;

        /***********************************************************
         * Fungsi cek total harga kamar
         * 
         */

        private void updateTotal(long HargaKamar, long HargaItem, bool isKamarDeleted = false, bool isItemDeleted = false)
        {
            //Inisialisasi
            long TotalKamar;
            long TotalItem;

            //Menghitung total harga kamar dan harga item
            TotalKamar = HargaKamar * MalamBox.Value;
            TotalItem = HargaItem * QtyBox.Value;

            //Jika tidak ada pembatalan
            if (isKamarDeleted == false && isItemDeleted == false)
            {
                TempTotal += TotalKamar + TotalItem;
            }

            //Jika ada pembatalan kamar
            if (isKamarDeleted)
            {
                long tempDeleteKamar;
                tempDeleteKamar = CancelKamar * MalamBox.Value;
                TempTotal -= tempDeleteKamar;
            }

            //Jika ada pembatalan item
            if (isItemDeleted)
            {
                long tempDeleteItem;
                tempDeleteItem = CancelItem;
                TempTotal -= tempDeleteItem;
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
                string QItem = "SELECT Name FROM item";

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

        // ----------------------- Fungsi Search Kamar --------------------------
        private void gunaButton12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter("SELECT room.RoomTypeID, roomtype.Name, room.RoomNumber, room.RoomFloor ,room.Description, roomtype.RoomPrice FROM room JOIN roomtype WHERE room.RoomTypeID=roomtype.ID AND roomtype.Name='" + RoomTypeCB.Text+"'", conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;
        }
        
        // ------------------------ Fungsi menambahkan pesanan kamar -----------------------
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
                updateTotal(0, 0, true);
                dataGridView4.Rows.RemoveAt(row.Index);
                
            }
        }
        int ItemID = 0;

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
                int ItemPID = 0;
                // --------------------------- MENAMBAHKAN HARGA BARANG KE DATA GRID ------------------------------
                
                while (row.Read())
                {
                    Price = int.Parse( row["RequirePrice"].ToString());
                    Total[hargaItemInc] = Price * QtyBox.Value;
                    ItemPID = int.Parse( row["ID"].ToString());
                }

                //cmd.Parameters.AddWithValue("@Name");
                string[] InputData = {"",ItemPID.ToString(),ItemCB.Text, QtyBox.Value.ToString(), RoomNumberBox.Text, Total[hargaItemInc].ToString()};
                dataGridView5.Rows.Add(InputData);
                hargaItemInc++;
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
           
        }

        private void TotalBayarLBL_Click(object sender, EventArgs e)
        {

        }

        private void ItemCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            //Randomize kode
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

            //Inisialisasi variabel
            int CustomerID = int.Parse(new String(CSID));
            int RoomNum = 0;
            int RoomID = 0;
            int RoomFloor = 0;
            int PriceRoom = 0;

            MySqlConnection conn = new MySqlConnection(SQLConn);
                string Query = "INSERT INTO reservation(ID, DateTime, EmployeeID, CustomerID, Code) VALUES (NULL,@DateTime,@EmployeeID,@CustomerID,@Code)";
                conn.Open();


                string GetCustomerID = "SELECT ID FROM customer WHERE Name=@Name AND PhoneNumber=@PhoneNumber";
                string AddCustomer = "INSERT INTO customer (ID, Name, NIK, Email, Gender, PhoneNumber, Age) VALUES (NULL,@Name, '', '', '', @PhoneNumber, 0)";
                string InsertDataResRoom = "INSERT INTO reservationroom(ID, ReservationID, RoomID, StartDateTime, DurationNight, RoomPrice, CheckInDateTime, CheckOutDateTime) VALUES (NULL,@ReservationID,@RoomID,@StartDateTime,@DurationNight,@RoomPrice,@CheckInDateTime,@CheckOutDateTime)";
                MySqlCommand AddCS = new MySqlCommand(AddCustomer, conn);

                AddCS.Parameters.AddWithValue("@Name", NameBox.Text);
                AddCS.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
                AddCS.ExecuteNonQuery();
                conn.Close();
                // ----------------------------------------------------------------------------
                conn.Open();
                MySqlCommand cmdGCSID = new MySqlCommand(GetCustomerID, conn);
                cmdGCSID.Parameters.AddWithValue("@Name", NameBox.Text);
                cmdGCSID.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
                cmdGCSID.ExecuteNonQuery();
                MySqlDataReader RowCostumerID;
                RowCostumerID = cmdGCSID.ExecuteReader();
                RowCostumerID.Read();
                var GetNewCustomerID = RowCostumerID["ID"].ToString();
                //MessageBox.Show(test.ToString());
                conn.Close();
                // ----------------------------------------------------------------------------
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                int EmployeeID = int.Parse(Login.GetUserID);
                var date = Convert.ToDateTime(DateTime.Text).ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@DateTime", date);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@CustomerID", int.Parse(GetNewCustomerID));
                cmd.Parameters.AddWithValue("@Code", CODE);


            if (cmd.ExecuteNonQuery() > 0)
            { 
                conn.Close();
                MessageBox.Show("Reservasi Berhasil");
                
                //Untuk setiap pesanan kamar masukkan ke tabel reservation
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    //Open Koneksi - Ambil input dan ambil ID reservasi
                    conn.Open();
                    RoomID = int.Parse(row.Cells["RoomID"].Value.ToString());
                    RoomNum = int.Parse(row.Cells["RoomNumber"].Value.ToString());
                    RoomFloor = int.Parse(row.Cells["RoomFloor"].Value.ToString());
                    PriceRoom = int.Parse(row.Cells["RoomPrice"].Value.ToString());
                    string QueryGetID = "SELECT ID FROM reservation GROUP BY ID DESC LIMIT 1";
                    MySqlCommand QGID = new MySqlCommand(QueryGetID, conn);
                    QGID.ExecuteNonQuery();
                    MySqlDataReader RowID;
                    RowID = QGID.ExecuteReader();
                    RowID.Read();
                    var GetNewResID = RowID["ID"];
                    conn.Close();
                    //Koneksi ditutup

                    //Open Koneksi - Input data ke tabel reservasi
                    conn.Open();
                    MySqlCommand cmdInsertDataResRoom = new MySqlCommand(InsertDataResRoom, conn);
                    var StartDate = Convert.ToDateTime(DateTime.Text).ToString("yyyy-MM-dd");
                    cmdInsertDataResRoom.Parameters.AddWithValue("@ReservationID", GetNewResID);
                    cmdInsertDataResRoom.Parameters.AddWithValue("@RoomID", RoomID);
                    cmdInsertDataResRoom.Parameters.AddWithValue("@StartDateTime", StartDate);
                    cmdInsertDataResRoom.Parameters.AddWithValue("@DurationNight", MalamBox.Value);
                    cmdInsertDataResRoom.Parameters.AddWithValue("@RoomPrice", PriceRoom);
                    cmdInsertDataResRoom.Parameters.AddWithValue("@CheckInDateTime", StartDate);
                    cmdInsertDataResRoom.Parameters.AddWithValue("@CheckOutDateTime", StartDate);
                    cmdInsertDataResRoom.ExecuteNonQuery();
                    conn.Close();
                    //Koneksi ditutup
                }
            }
            else
            {
                MessageBox.Show("Reservasi gagal");
            }

            //Koneksi open - Mengambil ID reservationroom untuk insert data pesanan item
            conn.Open();
            string QueryGetItemResID = "SELECT ID FROM reservationroom GROUP BY ID DESC LIMIT 1";
            MySqlCommand QGItemID = new MySqlCommand(QueryGetItemResID, conn);
            QGItemID.ExecuteNonQuery();
            MySqlDataReader RowItemID;
            RowItemID = QGItemID.ExecuteReader();
            int GetNewItemID = 0;
            if (RowItemID.Read())
            {
                GetNewItemID = int.Parse(RowItemID["ID"].ToString());
            }
            conn.Close();
            //Koneksi Ditutup
            
            //Koneksi open - Memasukkan item yang diminta ke dalam tabel reservation_request_item
            conn.Open();
            int TotalIndex = 0;
            foreach (DataGridViewRow rowAddItem in dataGridView5.Rows)
            {
                ItemID = int.Parse(dataGridView5.Rows[rowAddItem.Index].Cells["ItemPID"].FormattedValue.ToString());

                string QueryAddItem = "INSERT INTO reservation_request_item(ID, ReservationRoomID, ItemID, Qty, TotalPrice) VALUES (NULL,@ReservationRID,@ItemID,@Qty,@TotalPrice)";
                MySqlCommand cmdAddItem = new MySqlCommand(QueryAddItem, conn);
                cmdAddItem.Parameters.AddWithValue("@ReservationRID", GetNewItemID);
                cmdAddItem.Parameters.AddWithValue("@itemID", ItemID);
                cmdAddItem.Parameters.AddWithValue("@Qty", QtyBox.Value);
                cmdAddItem.Parameters.AddWithValue("@TotalPrice", Total[TotalIndex]);
                cmdAddItem.ExecuteNonQuery();
                TotalIndex++;
            }
            hargaItemInc = 0;
            conn.Close();
            //Koneksi ditutup dan akhir dari kodingan
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
