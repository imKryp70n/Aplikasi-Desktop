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

        private void MasterRoom_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            string Query = "SELECT RoomTypeID, RoomNumber, RoomFloor, Description FROM room";
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter(Query,conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;

        }
    }
}
