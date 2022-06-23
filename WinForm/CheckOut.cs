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
    public partial class CheckOut : UserControl
    {
        public CheckOut()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;allowuservariables=True";

        private void LoadItem()
        {
            string QItem = "SELECT Name FROM item";
            MySqlConnection conn = new MySqlConnection(SQLConn);

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
        }

        private void LoadRoomFloor()
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            string Query = "SELECT RoomNumber FROM room";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader row;
            row = cmd.ExecuteReader();
            while (row.Read())
            {
                string NoRuangan = row["RoomNumber"].ToString();
                NomorRuanganCB.Items.Add(NoRuangan);
            }
        }

        private void GetItemID()
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            string QItemID = "SELECT Name FROM item WHERE Name=@Name";
            MySqlCommand cmd = new MySqlCommand(QItemID, conn);
            cmd.Parameters.AddWithValue("@Name", ItemCB.Text);
            cmd.ExecuteNonQuery();
            MySqlDataReader row;
            row = cmd.ExecuteReader();
            while (row.Read())
            {
                int ItemID = int.Parse(row["ID"].ToString());
            }

        }
        private void CheckOut_Load(object sender, EventArgs e)
        {
            LoadItem();
            LoadRoomFloor();
            
        }

        private void NomorRuanganCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            string QDBLoader = "SELECT item.Name, resItem.Qty, item.CompensationFee FROM `reservationroom` INNER JOIN reservation_request_item AS resItem INNER JOIN item INNER JOIN room ON reservationroom.ID = resItem.ReservationRoomID AND resItem.ItemID = item.ID AND room.ID = reservationroom.RoomID WHERE reservationroom.CheckOutDateTime IS NULL AND reservationroom.ID ='" + NomorRuanganCB.Text + "'";
            conn.Open();
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter(QDBLoader, conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;

        }

        private void ReservationBTN_Click(object sender, EventArgs e)
        {
            


        }

        private void ItemCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemID();

        }
    }
}
