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
        char Gender;
        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            //string Query = "SELECT * FROM customer WHERE CustomerID=@CSID";
            string Query = "SELECT * FROM customer AS cus INNER JOIN reservation AS res ON cus.CustomerID = res.CustomerID WHERE res.Code=@Code";
            
            string QDataReservation = "SELECT reservationroom.* FROM reservationroom INNER JOIN reservation ON reservation.ID = reservationroom.ReservationID WHERE reservation.Code ='" + BookingCodeBox.Text + "'";
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

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = 'L';
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(SQLConn);
           /* try
            {*/
                conn.Open();

                string Query = "UPDATE customer SET Name=@Name,NIK=@NIK,Email=@Email,Gender=@Gender,PhoneNumber=@PhoneNumber,Age=@Age WHERE Name=@Name";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                cmd.Parameters.AddWithValue("@NIK", Int64.Parse(NIKBox.Text));
                cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", Int64.Parse(PhoneNumberBox.Text));
                cmd.Parameters.AddWithValue("@Age", int.Parse(UsiaBox.Text));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Check In berhasil", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Check In gagal", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
/*            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }*/
        }

        private void FemaleRB_CheckedChanged(object sender, EventArgs e)
        {
            Gender = 'W';
        }
    }
}
