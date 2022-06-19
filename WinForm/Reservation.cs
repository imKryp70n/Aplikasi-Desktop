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

        }
        
        private void Reservation_Load(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(SQLConn);
            try
            {
                // -------------------------- MEMUAT DATA RUANGAN -------------------------------

                conn.Open();
                string Query = "SELECT RoomNumber, RoomFloor, Description FROM room";
                string QRoomType = "SELECT * FROM roomtype";
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
            string Query = "SELECT * FROM roomtype WHERE Name=@Name";
            MySqlCommand cmd = new MySqlCommand(Query, conn);

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
    }
}
