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
    public partial class CheckIn : UserControl
    {
        public CheckIn()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            //string Query = "SELECT * FROM customer WHERE CustomerID=@CSID";
            string Query = "SELECT * FROM customer AS cus INNER JOIN reservation AS res ON cus.CustomerID = res.CustomerID WHERE res.Code=@Code";
            
            string QDataReservation = "SELECT * FROM reservationroom INNER JOIN reservation ON reservation.ID = reservationroom.ReservationID WHERE reservation.Code ='" + BookingCodeBox.Text + "'";
            MySqlCommand cmd = new MySqlCommand(Query,conn);
            MySqlDataAdapter DA = new MySqlDataAdapter(QDataReservation,conn);
            DataTable Table = new DataTable();
            DA.Fill(Table);
            dataGridView1.DataSource = Table;
            
            cmd.Parameters.AddWithValue("@Code", BookingCodeBox.Text);
            cmd.ExecuteNonQuery();
            MySqlDataReader row;
            row = cmd.ExecuteReader();
            while (row.Read())
            {
                string NameCS = row["Name"].ToString();
                string PhoneNumber = row["PhoneNumber"].ToString();
                string CSID = row["CustomerID"].ToString();
                PhoneNumberBox.Text = PhoneNumber;
                NameBox.Text = NameCS;

            }
        }
    }
}
