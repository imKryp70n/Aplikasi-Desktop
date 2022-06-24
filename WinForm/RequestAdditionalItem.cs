using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_TiketKeun.WinForm
{
    public partial class RequestAdditionalItem : UserControl
    {
        public RequestAdditionalItem()
        {
            InitializeComponent();
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }
        string SQLConn = "server=localhost;user id=root;database=db_win;allowuservariables=True";

        private void DataLoader()
        {
            string Query = "SELECT * FROM reservation_request_item WHERE 1";
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter(Query, conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;
        }
        private void RequestAdditionalItem_Load(object sender, EventArgs e)
        {
            DataLoader();
        }
    }
}
