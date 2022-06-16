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
        int JobID;
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
                if (CodeBox.Text == "1234")
                {
                    if (gunaCheckBox1.Checked == true)
                    {
                        if (UsernameBox.Text != "" && PasswordBox.Text != "" && NamaLengkapBox.Text != "" && EmailBox.Text != "" && AlamatBox.Text != "" && PekerjaanCBox.Text !="")
                        {
                            if (PekerjaanCBox.Text == "Admin")
                            {
                                JobID = 1;
                            } else if (PekerjaanCBox.Text == "House Keeper Supervisor")
                            {
                                JobID = 2;
                            } else if (PekerjaanCBox.Text == "House Keeper")
                            {
                                JobID = 3;
                            } 
                            else 
                            {
                                MessageBox.Show("Form Pekerjaan masih kosong", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            MySqlConnection conn = new MySqlConnection(SQLConn);
                            conn.Open();
                            string RegQuery = "INSERT INTO employee(ID, Username, Password, Name, Email, Address, DateOFBirth, JobID) VALUES (NULL,@username,@password,@name,@email,@alamat,@date,@jobID)";
                            MySqlCommand cmd = new MySqlCommand(RegQuery, conn);
                            var date = Convert.ToDateTime(DateBox.Text).ToString("yyyy-MM-dd");
                            cmd.Parameters.AddWithValue("@username", UsernameBox.Text);
                            cmd.Parameters.AddWithValue("@password", PasswordBox.Text);
                            cmd.Parameters.AddWithValue("@name", NamaLengkapBox.Text);
                            cmd.Parameters.AddWithValue("@email", EmailBox.Text);
                            cmd.Parameters.AddWithValue("@alamat", AlamatBox.Text);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@jobID", JobID);

                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Register Berhasil", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            new Login().Show();
                        }
                        else
                        {
                            MessageBox.Show("Kolom masih kosong, silahkan lengkapi dengan benar", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Setujui Syarat & Ketentuan kami", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else
                {
                    MessageBox.Show("Kode yang anda masukkan salah.", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"TiketKeun",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mintalah kode kepada admin.", "Tiketkeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
