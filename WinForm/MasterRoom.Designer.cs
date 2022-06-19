
namespace Aplikasi_TiketKeun.WinForm
{
    partial class MasterRoom
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
            this.Deskripsi = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeCB = new Guna.UI.WinForms.GunaComboBox();
            this.NoRuangan = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gunaButton3 = new Guna.UI.WinForms.GunaButton();
            this.gunaButton2 = new Guna.UI.WinForms.GunaButton();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.LantaiRuangan = new Guna.UI.WinForms.GunaTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReservationBTN = new Guna.UI.WinForms.GunaButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RoomButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gunaGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.Deskripsi);
            this.gunaGroupBox1.Controls.Add(this.label2);
            this.gunaGroupBox1.Controls.Add(this.TypeCB);
            this.gunaGroupBox1.Controls.Add(this.NoRuangan);
            this.gunaGroupBox1.Controls.Add(this.label4);
            this.gunaGroupBox1.Controls.Add(this.gunaButton3);
            this.gunaGroupBox1.Controls.Add(this.gunaButton2);
            this.gunaGroupBox1.Controls.Add(this.gunaButton1);
            this.gunaGroupBox1.Controls.Add(this.LantaiRuangan);
            this.gunaGroupBox1.Controls.Add(this.label3);
            this.gunaGroupBox1.Controls.Add(this.label1);
            this.gunaGroupBox1.Controls.Add(this.ReservationBTN);
            this.gunaGroupBox1.Controls.Add(this.dataGridView1);
            this.gunaGroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaGroupBox1.LineColor = System.Drawing.Color.DodgerBlue;
            this.gunaGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(787, 546);
            this.gunaGroupBox1.TabIndex = 1;
            this.gunaGroupBox1.Text = "Master Room";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // Deskripsi
            // 
            this.Deskripsi.BaseColor = System.Drawing.Color.White;
            this.Deskripsi.BorderColor = System.Drawing.Color.Silver;
            this.Deskripsi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Deskripsi.FocusedBaseColor = System.Drawing.Color.White;
            this.Deskripsi.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Deskripsi.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.Deskripsi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Deskripsi.ForeColor = System.Drawing.Color.Black;
            this.Deskripsi.Location = new System.Drawing.Point(169, 381);
            this.Deskripsi.Name = "Deskripsi";
            this.Deskripsi.PasswordChar = '\0';
            this.Deskripsi.SelectedText = "";
            this.Deskripsi.Size = new System.Drawing.Size(333, 30);
            this.Deskripsi.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Deksripsi";
            // 
            // TypeCB
            // 
            this.TypeCB.BackColor = System.Drawing.Color.Transparent;
            this.TypeCB.BaseColor = System.Drawing.Color.White;
            this.TypeCB.BorderColor = System.Drawing.Color.Silver;
            this.TypeCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCB.FocusedColor = System.Drawing.Color.Empty;
            this.TypeCB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TypeCB.ForeColor = System.Drawing.Color.Black;
            this.TypeCB.FormattingEnabled = true;
            this.TypeCB.Location = new System.Drawing.Point(169, 305);
            this.TypeCB.Name = "TypeCB";
            this.TypeCB.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.TypeCB.OnHoverItemForeColor = System.Drawing.Color.White;
            this.TypeCB.Size = new System.Drawing.Size(333, 26);
            this.TypeCB.TabIndex = 20;
            this.TypeCB.SelectedIndexChanged += new System.EventHandler(this.gunaComboBox1_SelectedIndexChanged);
            // 
            // NoRuangan
            // 
            this.NoRuangan.BaseColor = System.Drawing.Color.White;
            this.NoRuangan.BorderColor = System.Drawing.Color.Silver;
            this.NoRuangan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NoRuangan.FocusedBaseColor = System.Drawing.Color.White;
            this.NoRuangan.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.NoRuangan.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.NoRuangan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NoRuangan.ForeColor = System.Drawing.Color.Black;
            this.NoRuangan.Location = new System.Drawing.Point(169, 267);
            this.NoRuangan.Name = "NoRuangan";
            this.NoRuangan.PasswordChar = '\0';
            this.NoRuangan.SelectedText = "";
            this.NoRuangan.Size = new System.Drawing.Size(333, 30);
            this.NoRuangan.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nomor ruangan";
            // 
            // gunaButton3
            // 
            this.gunaButton3.Animated = true;
            this.gunaButton3.AnimationHoverSpeed = 0.07F;
            this.gunaButton3.AnimationSpeed = 0.03F;
            this.gunaButton3.BaseColor = System.Drawing.Color.DodgerBlue;
            this.gunaButton3.BorderColor = System.Drawing.Color.Black;
            this.gunaButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton3.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton3.ForeColor = System.Drawing.Color.White;
            this.gunaButton3.Image = null;
            this.gunaButton3.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton3.Location = new System.Drawing.Point(655, 329);
            this.gunaButton3.Name = "gunaButton3";
            this.gunaButton3.OnHoverBaseColor = System.Drawing.Color.RoyalBlue;
            this.gunaButton3.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton3.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton3.OnHoverImage = null;
            this.gunaButton3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton3.Size = new System.Drawing.Size(94, 42);
            this.gunaButton3.TabIndex = 17;
            this.gunaButton3.Text = "Delete";
            this.gunaButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaButton2
            // 
            this.gunaButton2.Animated = true;
            this.gunaButton2.AnimationHoverSpeed = 0.07F;
            this.gunaButton2.AnimationSpeed = 0.03F;
            this.gunaButton2.BaseColor = System.Drawing.Color.DodgerBlue;
            this.gunaButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton2.ForeColor = System.Drawing.Color.White;
            this.gunaButton2.Image = null;
            this.gunaButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton2.Location = new System.Drawing.Point(545, 329);
            this.gunaButton2.Name = "gunaButton2";
            this.gunaButton2.OnHoverBaseColor = System.Drawing.Color.RoyalBlue;
            this.gunaButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton2.OnHoverImage = null;
            this.gunaButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton2.Size = new System.Drawing.Size(94, 42);
            this.gunaButton2.TabIndex = 16;
            this.gunaButton2.Text = "Save";
            this.gunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.gunaButton1.Location = new System.Drawing.Point(654, 268);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.RoyalBlue;
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Size = new System.Drawing.Size(94, 42);
            this.gunaButton1.TabIndex = 15;
            this.gunaButton1.Text = "Update";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LantaiRuangan
            // 
            this.LantaiRuangan.BaseColor = System.Drawing.Color.White;
            this.LantaiRuangan.BorderColor = System.Drawing.Color.Silver;
            this.LantaiRuangan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LantaiRuangan.FocusedBaseColor = System.Drawing.Color.White;
            this.LantaiRuangan.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.LantaiRuangan.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.LantaiRuangan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LantaiRuangan.ForeColor = System.Drawing.Color.Black;
            this.LantaiRuangan.Location = new System.Drawing.Point(169, 343);
            this.LantaiRuangan.Name = "LantaiRuangan";
            this.LantaiRuangan.PasswordChar = '\0';
            this.LantaiRuangan.SelectedText = "";
            this.LantaiRuangan.Size = new System.Drawing.Size(333, 30);
            this.LantaiRuangan.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lantai ruangan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Type ruangan";
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
            this.ReservationBTN.Location = new System.Drawing.Point(545, 268);
            this.ReservationBTN.Name = "ReservationBTN";
            this.ReservationBTN.OnHoverBaseColor = System.Drawing.Color.RoyalBlue;
            this.ReservationBTN.OnHoverBorderColor = System.Drawing.Color.Black;
            this.ReservationBTN.OnHoverForeColor = System.Drawing.Color.White;
            this.ReservationBTN.OnHoverImage = null;
            this.ReservationBTN.OnPressedColor = System.Drawing.Color.Black;
            this.ReservationBTN.Size = new System.Drawing.Size(94, 42);
            this.ReservationBTN.TabIndex = 7;
            this.ReservationBTN.Text = "Insert";
            this.ReservationBTN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReservationBTN.Click += new System.EventHandler(this.ReservationBTN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomButton});
            this.dataGridView1.Location = new System.Drawing.Point(16, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(756, 186);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RoomButton
            // 
            this.RoomButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RoomButton.HeaderText = "Pilih";
            this.RoomButton.Name = "RoomButton";
            this.RoomButton.ReadOnly = true;
            this.RoomButton.Width = 46;
            // 
            // MasterRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gunaGroupBox1);
            this.Name = "MasterRoom";
            this.Size = new System.Drawing.Size(793, 552);
            this.Load += new System.EventHandler(this.MasterRoom_Load);
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI.WinForms.GunaTextBox Deskripsi;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaComboBox TypeCB;
        private Guna.UI.WinForms.GunaTextBox NoRuangan;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaButton gunaButton3;
        private Guna.UI.WinForms.GunaButton gunaButton2;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaTextBox LantaiRuangan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton ReservationBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn RoomButton;
    }
}
