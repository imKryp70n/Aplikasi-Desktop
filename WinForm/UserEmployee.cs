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
    public partial class UserEmployee : UserControl
    {
        public UserEmployee()
        {
            InitializeComponent();
        }
        string SQLConn = "server=localhost;user id=root;database=db_win;sslmode=Disabled";
        int JobPID;
        private void UserEmployee_Load(object sender, EventArgs e)
        {
            string Query = "SELECT Username, Name, Email, Address, DateOfBirth, JobID FROM employee";
            MySqlConnection conn = new MySqlConnection(SQLConn);
            conn.Open();
            DataTable Table = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter(Query,conn);
            DA.Fill(Table);
            dataGridView1.DataSource = Table;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var gridSender = (DataGridView)sender;
            if (gridSender.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var GetUser = dataGridView1.Rows[e.RowIndex].Cells["Username"].FormattedValue.ToString();
                string Query = "SELECT * FROM employee WHERE Username=@Username";
                MySqlConnection conn = new MySqlConnection(SQLConn);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Username", GetUser);
                cmd.ExecuteNonQuery();
                MySqlDataReader row;
                row = cmd.ExecuteReader();
                while (row.Read())
                {
                    var Username = row["Username"].ToString();
                    var Password = row["Password"].ToString();
                    var Name = row["Name"].ToString();
                    var Email = row["Email"].ToString();
                    var DateOfBirth = row["DateOfBirth"].ToString();
                    var JobID = row["JobID"].ToString();
                    var Address = row["Address"].ToString();
                    //var Date = TimeSpan.Parse(DateOfBirth);
                    UsernameBox.Text = Username;
                    PasswordBox.Text = Password;
                    CPasswordBox.Text = Password;
                    NameBox.Text = Name;
                    EmailBox.Text = Email;
/*                    DOBBox.CustomFormat = "yyyy-MM-dd";
                    DOBBox.Value = Date;*/
                    //JobIDBox.Items.Add(JobID);
                    AddressBox.Text = Address;
                    //var date = Convert.ToDateTime(DateBox.Text).ToString("yyyy-MM-dd");

                }
                
            }
        }

        private void ReservationBTN_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            if (UsernameBox.Text != "" && PasswordBox.Text != "" && NameBox.Text != "" && EmailBox.Text != "" &&
                DOBBox.Text != "" && JobIDBox.Text != "" && AddressBox.Text != "")
            {
                try
                {



                    if (JobIDBox.Text == "Admin")
                    {
                        JobPID = 1;
                    }
                    else if (JobIDBox.Text == "House Keeper Supervisor")
                    {
                        JobPID = 2;
                    }
                    else if (JobIDBox.Text == "House Keeper")
                    {
                        JobPID = 3;
                    }
                    else
                    {
                        MessageBox.Show("ERROR : Tidak ada pekerjaan itu", "TiketKeun", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    MySqlConnection conn = new MySqlConnection(SQLConn);
                    string Query =
                        "UPDATE employee SET Username=@Username,Password=@Password,Name=@Name,Email=@Email,Address=@Address,DateOfBirth=@DateOfBirth,JobID=@JobID WHERE Username=@Username";
                    string QueryData = "SELECT Username, Name, Email, Address, DateOfBirth, JobID FROM employee";
                    conn.Open();



                    MySqlCommand cmd = new MySqlCommand(Query, conn);

                    var date = Convert.ToDateTime(DOBBox.Text).ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@Username", UsernameBox.Text);
                    cmd.Parameters.AddWithValue("@Password", PasswordBox.Text);
                    cmd.Parameters.AddWithValue("@Name", NameBox.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                    cmd.Parameters.AddWithValue("@Address", AddressBox.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", date);
                    cmd.Parameters.AddWithValue("@JobID", JobPID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User berhasil di update", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable Table = new DataTable();
                    MySqlDataAdapter DA = new MySqlDataAdapter(QueryData, conn);
                    DA.Fill(Table);
                    dataGridView1.DataSource = Table;
                    conn.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            else
            {
                    MessageBox.Show("Form masih kosong", "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(SQLConn);
            string Query = "DELETE FROM employee WHERE Username=@Username";

            if (UsernameBox.Text != "")
            {
                try
                {

                    var confirm = MessageBox.Show("Apakah Anda yakin?", "TiketKeun", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);
                    if (confirm == DialogResult.OK)
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        cmd.Parameters.AddWithValue("@Username", UsernameBox.Text);
                        //cmd.ExecuteNonQuery();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Akun telah dihapus", "TiketKeun", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            DataTable Table = new DataTable();
                            string DataQuery = "SELECT Username, Name, Email, Address, DateOfBirth, JobID FROM employee";
                            MySqlDataAdapter DA = new MySqlDataAdapter(DataQuery, conn);
                            DA.Fill(Table);
                            dataGridView1.DataSource = Table;
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Akun gagal dihapus", "TiketKeun", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                        }


                    }
                    else
                    {

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "TiketKeun", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }   
    }
}
