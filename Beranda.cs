using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikasi_TiketKeun
{
    public partial class Beranda : Form
    {
        public Beranda()
        {
            InitializeComponent();
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
            
        }

        private void Beranda_Load(object sender, EventArgs e)
        {
            
        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HouseKeeperSupervisor().Show();
        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
