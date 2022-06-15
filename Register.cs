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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            new Login().Show();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (gunaCheckBox1.Checked == true)
                {
                    if (UsernameBox.Text != "" && PasswordBox.Text != "" && NamaLengkapBox.Text != "" && EmailBox.Text != "" && AlamatBox.Text != "")
                    {
                        MySqlConnection conn = new MySqlConnection(SQLConn);
                        conn.Open();
                        string RegQuery = "INSERT INTO user(id_user, username, password, name, email, alamat) VALUES (NULL,@username,@password,@name,@email,@alamat)";
                        MySqlCommand cmd = new MySqlCommand(RegQuery, conn);
                        cmd.Parameters.AddWithValue("@username", UsernameBox.Text);
                        cmd.Parameters.AddWithValue("@password", PasswordBox.Text);
                        cmd.Parameters.AddWithValue("@name", NamaLengkapBox.Text);
                        cmd.Parameters.AddWithValue("@email", EmailBox.Text);
                        cmd.Parameters.AddWithValue("@alamat", AlamatBox.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Register Berhasil", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        new Login().Show();
                    } else
                    {
                        MessageBox.Show("Kolom masih kosong, silahkan lengkapi dengan benar", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Setujui Syarat & Ketentuan kami", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"TiketKeun",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
