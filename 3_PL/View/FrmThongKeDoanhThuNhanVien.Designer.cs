namespace _3_PL.View
{
    partial class FrmThongKeDoanhThuNhanVien
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongKeDoanhThuNhanVien));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrid_doanhthu = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_nam = new System.Windows.Forms.ComboBox();
            this.cbo_loc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_ngay = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_doanhthu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgrid_doanhthu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 403);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1220, 219);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê Doanh Thu Nhân Viên";
            // 
            // dgrid_doanhthu
            // 
            this.dgrid_doanhthu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_doanhthu.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgrid_doanhthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_doanhthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_doanhthu.Location = new System.Drawing.Point(3, 18);
            this.dgrid_doanhthu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrid_doanhthu.Name = "dgrid_doanhthu";
            this.dgrid_doanhthu.RowHeadersWidth = 51;
            this.dgrid_doanhthu.RowTemplate.Height = 29;
            this.dgrid_doanhthu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_doanhthu.Size = new System.Drawing.Size(1214, 199);
            this.dgrid_doanhthu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Sienna;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 104);
            this.panel1.TabIndex = 16;
            // 
            // pictureBox3
            // 
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(533, 10);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(255, 93);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(1001, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Theo Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(705, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Theo Tháng :";
            // 
            // cbo_nam
            // 
            this.cbo_nam.FormattingEnabled = true;
            this.cbo_nam.Location = new System.Drawing.Point(1077, 377);
            this.cbo_nam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_nam.Name = "cbo_nam";
            this.cbo_nam.Size = new System.Drawing.Size(133, 23);
            this.cbo_nam.TabIndex = 12;
            this.cbo_nam.SelectedIndexChanged += new System.EventHandler(this.cbo_nam_SelectedIndexChanged);
            //this.cbo_nam.TextChanged += new System.EventHandler(this.cbo_nam_TextChanged);
            // 
            // cbo_loc
            // 
            this.cbo_loc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_loc.FormattingEnabled = true;
            this.cbo_loc.Location = new System.Drawing.Point(803, 375);
            this.cbo_loc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_loc.Name = "cbo_loc";
            this.cbo_loc.Size = new System.Drawing.Size(133, 23);
            this.cbo_loc.TabIndex = 13;
            this.cbo_loc.SelectedIndexChanged += new System.EventHandler(this.cbo_loc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(433, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Theo Ngày:";
            // 
            // cbo_ngay
            // 
            this.cbo_ngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ngay.FormattingEnabled = true;
            this.cbo_ngay.Location = new System.Drawing.Point(522, 375);
            this.cbo_ngay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_ngay.Name = "cbo_ngay";
            this.cbo_ngay.Size = new System.Drawing.Size(133, 23);
            this.cbo_ngay.TabIndex = 17;
            this.cbo_ngay.SelectedValueChanged += new System.EventHandler(this.cbo_ngay_SelectedValueChanged);
            // 
            // FrmThongKeDoanhThuNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 622);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_nam);
            this.Controls.Add(this.cbo_loc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_ngay);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmThongKeDoanhThuNhanVien";
            this.Text = "FrmThongKeDoanhThuNhanVien";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_doanhthu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgrid_doanhthu;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label2;
        private Label label1;
        private ComboBox cbo_nam;
        private ComboBox cbo_loc;
        private Label label3;
        private ComboBox cbo_ngay;
    }
}