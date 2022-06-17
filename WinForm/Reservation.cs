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
        int a;
        private void Reservation_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            try
            {
                conn.Open();
                string Query = "SELECT RoomNumber, RoomFloor, Description FROM room";
                string QRoomType = "SELECT * FROM roomtype";

                MySqlCommand cmd = new MySqlCommand(Query, conn);

                DataTable Table = new DataTable();
                MySqlDataAdapter DA = new MySqlDataAdapter(Query,conn);
                DA.Fill(Table);
                dataGridView1.DataSource = Table;
                conn.Close();
                conn.Open();
                MySqlCommand cmdRoomType = new MySqlCommand(QRoomType, conn);
                MySqlDataReader row;
                row = cmdRoomType.ExecuteReader();
                while (row.Read())
                {
                    string RoomType = row["Name"].ToString();
                    RoomTypeCB.Items.Add(RoomType);
                }


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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
     
                
                    int editIndex = dataGridView4.Rows.Add();
                    dataGridView4.Rows[e.RowIndex].Cells[0].Value = dataGridView1.Rows[e.ColumnIndex].Cells[0].Value;
                    dataGridView4.Rows[e.RowIndex].Cells[1].Value = dataGridView1.Rows[e.ColumnIndex].Cells[1].Value;
                    dataGridView4.Rows[e.RowIndex].Cells[2].Value = dataGridView1.Rows[e.ColumnIndex].Cells[2].Value;
                    dataGridView4.Rows[e.RowIndex].Cells[3].Value = dataGridView1.Rows[e.ColumnIndex].Cells[3].Value;

                   
            }
        }
        
    }
}
