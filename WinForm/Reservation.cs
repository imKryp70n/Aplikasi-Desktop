﻿using System;
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
                conn.Open();
                string Query = "SELECT RoomNumber, RoomFloor, Description FROM room";
                DataTable Table = new DataTable();
                MySqlDataAdapter DA = new MySqlDataAdapter(Query,conn);
                DA.Fill(Table);
                dataGridView1.DataSource = Table;

        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
