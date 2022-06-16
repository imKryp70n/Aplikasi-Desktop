using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Aplikasi_TiketKeun
{
    public partial class HouseKeeperSupervisor : Form
    {
        public HouseKeeperSupervisor()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HouseKeeperSupervisor_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            string query = "SELECT * FROM employee where JobID=3";
            MySqlCommand cmd = new MySqlCommand(query,conn);
            DataTable table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter("SELECT * FROM cleaningroomdetail",conn);
            DA.Fill(table);
            dataGridView1.DataSource = table;
            MySqlDataReader row;
            cmd.ExecuteNonQuery();
            row = cmd.ExecuteReader();
            try
            {
                while (row.Read())
                {
                    string employee = row["Name"].ToString();
                    gunaComboBox1.Items.Add(employee);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

            var Logout = MessageBox.Show("Apakah anda ingin logout?", "TiketKeun", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Logout == DialogResult.OK)
            {
                this.Close();
                new Login().Show();
            }
            else
            {

            }
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
