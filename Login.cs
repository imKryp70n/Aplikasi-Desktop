﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aplikasi_TiketKeun
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(SQLConn);
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                MessageBox.Show("Koneksi Terhubung","Taufik Mulyana",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Taufik Mulyana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsernameLBL_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlDataReader row;
            string Query = "SELECT * FROM user WHERE username=@username and password=@password";
            MySqlCommand cmd = new MySqlCommand(Query,conn);
            cmd.Parameters.AddWithValue("@username", UsernameBox.Text);
            cmd.Parameters.AddWithValue("@password", PasswordBox.Text);
            cmd.ExecuteNonQuery();
            row = cmd.ExecuteReader();
            if (UsernameBox.Text != "" && UsernameBox.Text != "")
            {
                if (row.HasRows)
                {
                    MessageBox.Show("Login Berhasil", "Taufik Mulyana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Beranda().Show();
                }
                else
                {
                    MessageBox.Show("Username dan Password salah", "Taufik Mulyana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                conn.Close();
            } else
            {
                MessageBox.Show("Kolom Username dan Password Kosong", "Taufik Mulyana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gunaLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Register().Show();
        }
    }
}
