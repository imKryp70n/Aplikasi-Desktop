using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplikasi_TiketKeun.WinForm;

namespace Aplikasi_TiketKeun
{
    public partial class Beranda : Form
    {
        public Beranda()
        {
            InitializeComponent();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

            var Logout = MessageBox.Show("Apakah anda ingin logout?", "TiketKeun", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Logout == DialogResult.OK)
            {
                this.Close();
                new Login().Show();
            } else
            {

            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            WinForm.Reservation WF = new WinForm.Reservation();
            addUserControl(WF);
        }

        private void Beranda_Load(object sender, EventArgs e)
        {
            User.Text = Login.GetUserName;
            int UserID = int.Parse(Login.GetUserID);
            if (UserID != 1)
            {
                gunaButton11.Visible = false;
                gunaButton3.Visible = false;
                gunaButton12.Visible = false;
            } else
            {

            }
        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
            WinForm.UserEmployee WF = new UserEmployee();
            addUserControl(WF);
        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            WinForm.CheckIn WF = new WinForm.CheckIn();
            addUserControl(WF);
        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            WinForm.MasterRoomType WF = new WinForm.MasterRoomType();
            addUserControl(WF);
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            WinForm.MasterRoom WF = new WinForm.MasterRoom();
            addUserControl(WF);
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            WinForm.RequestAdditionalItem WF = new WinForm.RequestAdditionalItem();
            addUserControl(WF);
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            WinForm.CheckOut WF = new WinForm.CheckOut();
            addUserControl(WF);
        }


        private void gunaButton10_Click_1(object sender, EventArgs e)
        {
            WinForm.MasterItem WF = new WinForm.MasterItem();
            addUserControl(WF);
        }

        private void User_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton3_Click_1(object sender, EventArgs e)
        {
            new HouseKeeperSupervisor().Show();
            this.Hide();
        }

        private void gunaButton12_Click_1(object sender, EventArgs e)
        {
            new HouseKeeper().Show();
            this.Hide();
        }

        
    }
}
