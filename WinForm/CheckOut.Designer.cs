
namespace Aplikasi_TiketKeun.WinForm
{
    partial class CheckOut
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DeleteItem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.ItemStatusCB = new Guna.UI.WinForms.GunaComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NomorRuanganCB = new Guna.UI.WinForms.GunaComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QTYBox = new Guna.UI.WinForms.GunaNumeric();
            this.ReservationBTN = new Guna.UI.WinForms.GunaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.ListItemBox = new Guna.UI.WinForms.GunaTextBox();
            this.gunaGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gunaGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.dataGridView1);
            this.gunaGroupBox1.Controls.Add(this.gunaGroupBox2);
            this.gunaGroupBox1.Controls.Add(this.gunaButton1);
            this.gunaGroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaGroupBox1.LineColor = System.Drawing.Color.DodgerBlue;
            this.gunaGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(787, 672);
            this.gunaGroupBox1.TabIndex = 3;
            this.gunaGroupBox1.Text = "Check Out";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteItem});
            this.dataGridView1.Location = new System.Drawing.Point(19, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(751, 135);
            this.dataGridView1.TabIndex = 0;
            // 
            // DeleteItem
            // 
            this.DeleteItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DeleteItem.HeaderText = "Hapus";
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Width = 60;
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.BorderSize = 1;
            this.gunaGroupBox2.Controls.Add(this.ListItemBox);
            this.gunaGroupBox2.Controls.Add(this.ItemStatusCB);
            this.gunaGroupBox2.Controls.Add(this.label1);
            this.gunaGroupBox2.Controls.Add(this.NomorRuanganCB);
            this.gunaGroupBox2.Controls.Add(this.label2);
            this.gunaGroupBox2.Controls.Add(this.QTYBox);
            this.gunaGroupBox2.Controls.Add(this.ReservationBTN);
            this.gunaGroupBox2.Controls.Add(this.label3);
            this.gunaGroupBox2.Controls.Add(this.label4);
            this.gunaGroupBox2.LineColor = System.Drawing.Color.DodgerBlue;
            this.gunaGroupBox2.Location = new System.Drawing.Point(19, 38);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Size = new System.Drawing.Size(751, 240);
            this.gunaGroupBox2.TabIndex = 23;
            this.gunaGroupBox2.Text = "Detail";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // ItemStatusCB
            // 
            this.ItemStatusCB.BackColor = System.Drawing.Color.Transparent;
            this.ItemStatusCB.BaseColor = System.Drawing.Color.White;
            this.ItemStatusCB.BorderColor = System.Drawing.Color.Silver;
            this.ItemStatusCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemStatusCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemStatusCB.FocusedColor = System.Drawing.Color.Empty;
            this.ItemStatusCB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ItemStatusCB.ForeColor = System.Drawing.Color.Black;
            this.ItemStatusCB.FormattingEnabled = true;
            this.ItemStatusCB.Location = new System.Drawing.Point(270, 145);
            this.ItemStatusCB.Name = "ItemStatusCB";
            this.ItemStatusCB.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ItemStatusCB.OnHoverItemForeColor = System.Drawing.Color.White;
            this.ItemStatusCB.Size = new System.Drawing.Size(333, 26);
            this.ItemStatusCB.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(120, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Item Status";
            // 
            // NomorRuanganCB
            // 
            this.NomorRuanganCB.BackColor = System.Drawing.Color.Transparent;
            this.NomorRuanganCB.BaseColor = System.Drawing.Color.White;
            this.NomorRuanganCB.BorderColor = System.Drawing.Color.Silver;
            this.NomorRuanganCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.NomorRuanganCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NomorRuanganCB.FocusedColor = System.Drawing.Color.Empty;
            this.NomorRuanganCB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.NomorRuanganCB.ForeColor = System.Drawing.Color.Black;
            this.NomorRuanganCB.FormattingEnabled = true;
            this.NomorRuanganCB.Location = new System.Drawing.Point(270, 41);
            this.NomorRuanganCB.Name = "NomorRuanganCB";
            this.NomorRuanganCB.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.NomorRuanganCB.OnHoverItemForeColor = System.Drawing.Color.White;
            this.NomorRuanganCB.Size = new System.Drawing.Size(333, 26);
            this.NomorRuanganCB.TabIndex = 20;
            this.NomorRuanganCB.SelectedIndexChanged += new System.EventHandler(this.NomorRuanganCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(120, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Item";
            // 
            // QTYBox
            // 
            this.QTYBox.BaseColor = System.Drawing.Color.White;
            this.QTYBox.BorderColor = System.Drawing.Color.Silver;
            this.QTYBox.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.QTYBox.ButtonForeColor = System.Drawing.Color.White;
            this.QTYBox.Enabled = false;
            this.QTYBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.QTYBox.ForeColor = System.Drawing.Color.Black;
            this.QTYBox.Location = new System.Drawing.Point(270, 107);
            this.QTYBox.Maximum = ((long)(9999999));
            this.QTYBox.Minimum = ((long)(0));
            this.QTYBox.Name = "QTYBox";
            this.QTYBox.Size = new System.Drawing.Size(333, 30);
            this.QTYBox.TabIndex = 19;
            this.QTYBox.Text = "gunaNumeric1";
            this.QTYBox.Value = ((long)(0));
            // 
            // ReservationBTN
            // 
            this.ReservationBTN.Animated = true;
            this.ReservationBTN.AnimationHoverSpeed = 0.07F;
            this.ReservationBTN.AnimationSpeed = 0.03F;
            this.ReservationBTN.BaseColor = System.Drawing.Color.DodgerBlue;
            this.ReservationBTN.BorderColor = System.Drawing.Color.Black;
            this.ReservationBTN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ReservationBTN.FocusedColor = System.Drawing.Color.Empty;
            this.ReservationBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservationBTN.ForeColor = System.Drawing.Color.White;
            this.ReservationBTN.Image = null;
            this.ReservationBTN.ImageSize = new System.Drawing.Size(20, 20);
            this.ReservationBTN.Location = new System.Drawing.Point(374, 180);
            this.ReservationBTN.Name = "ReservationBTN";
            this.ReservationBTN.OnHoverBaseColor = System.Drawing.Color.RoyalBlue;
            this.ReservationBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.ReservationBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.ReservationBTN.OnHoverImage = null;
            this.ReservationBTN.OnPressedColor = System.Drawing.Color.Black;
            this.ReservationBTN.Size = new System.Drawing.Size(229, 42);
            this.ReservationBTN.TabIndex = 7;
            this.ReservationBTN.Text = "Tambahkan";
            this.ReservationBTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReservationBTN.Click += new System.EventHandler(this.ReservationBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(120, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Jumlah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(120, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nomor ruangan";
            // 
            // gunaButton1
            // 
            this.gunaButton1.Animated = true;
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BaseColor = System.Drawing.Color.DodgerBlue;
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(541, 433);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.RoyalBlue;
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Size = new System.Drawing.Size(229, 42);
            this.gunaButton1.TabIndex = 15;
            this.gunaButton1.Text = "Bayar";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ListItemBox
            // 
            this.ListItemBox.BaseColor = System.Drawing.Color.White;
            this.ListItemBox.BorderColor = System.Drawing.Color.Silver;
            this.ListItemBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ListItemBox.FocusedBaseColor = System.Drawing.Color.White;
            this.ListItemBox.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ListItemBox.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.ListItemBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ListItemBox.Location = new System.Drawing.Point(270, 71);
            this.ListItemBox.Name = "ListItemBox";
            this.ListItemBox.PasswordChar = '\0';
            this.ListItemBox.SelectedText = "";
            this.ListItemBox.Size = new System.Drawing.Size(333, 30);
            this.ListItemBox.TabIndex = 25;
            this.ListItemBox.TextChanged += new System.EventHandler(this.ListItemBox_TextChanged);
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaGroupBox1);
            this.Name = "CheckOut";
            this.Size = new System.Drawing.Size(793, 654);
            this.Load += new System.EventHandler(this.CheckOut_Load);
            this.gunaGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gunaGroupBox2.ResumeLayout(false);
            this.gunaGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaComboBox ItemStatusCB;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaComboBox NomorRuanganCB;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaNumeric QTYBox;
        private Guna.UI.WinForms.GunaButton ReservationBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteItem;
        private Guna.UI.WinForms.GunaTextBox ListItemBox;
    }
}
