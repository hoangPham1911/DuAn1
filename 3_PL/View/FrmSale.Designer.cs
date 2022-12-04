namespace _3_PL.View
{
    partial class FrmSale
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.Mã = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdb_con = new System.Windows.Forms.RadioButton();
            this.rdb_ngung = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_sotiengiam = new System.Windows.Forms.TextBox();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_sotiengiamgia = new System.Windows.Forms.TextBox();
            this.dt_ngayketthuc = new System.Windows.Forms.DateTimePicker();
            this.dt_ngaybatdau = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_gia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_ma = new System.Windows.Forms.ComboBox();
            this.tb_tenct = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.HeaderText = "Column1";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_sua.Location = new System.Drawing.Point(29, 120);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(240, 57);
            this.btn_sua.TabIndex = 34;
            this.btn_sua.Text = "     Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_xoa.Location = new System.Drawing.Point(29, 195);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(239, 57);
            this.btn_xoa.TabIndex = 33;
            this.btn_xoa.Text = "     Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            // 
            // btn_them
            // 
            this.btn_them.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_them.BackColor = System.Drawing.Color.DarkSalmon;
            this.btn_them.Location = new System.Drawing.Point(29, 36);
            this.btn_them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(239, 68);
            this.btn_them.TabIndex = 32;
            this.btn_them.Text = "     Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // Mã
            // 
            this.Mã.HeaderText = "Mã";
            this.Mã.MinimumWidth = 8;
            this.Mã.Name = "Mã";
            this.Mã.Width = 150;
            // 
            // dgv_show
            // 
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show.BackgroundColor = System.Drawing.Color.PeachPuff;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Location = new System.Drawing.Point(13, 46);
            this.dgv_show.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersWidth = 62;
            this.dgv_show.RowTemplate.Height = 33;
            this.dgv_show.Size = new System.Drawing.Size(914, 291);
            this.dgv_show.TabIndex = 0;
            this.dgv_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkSalmon;
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.dgv_show);
            this.groupBox3.Location = new System.Drawing.Point(36, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(948, 667);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sản phẩm";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkSalmon;
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Location = new System.Drawing.Point(638, 367);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(289, 273);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên chương trình";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 221);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // rdb_con
            // 
            this.rdb_con.AutoSize = true;
            this.rdb_con.Location = new System.Drawing.Point(186, 221);
            this.rdb_con.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_con.Name = "rdb_con";
            this.rdb_con.Size = new System.Drawing.Size(140, 29);
            this.rdb_con.TabIndex = 7;
            this.rdb_con.TabStop = true;
            this.rdb_con.Text = "Còn sử dụng";
            this.rdb_con.UseVisualStyleBackColor = true;
            // 
            // rdb_ngung
            // 
            this.rdb_ngung.AutoSize = true;
            this.rdb_ngung.Location = new System.Drawing.Point(330, 223);
            this.rdb_ngung.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_ngung.Name = "rdb_ngung";
            this.rdb_ngung.Size = new System.Drawing.Size(164, 29);
            this.rdb_ngung.TabIndex = 8;
            this.rdb_ngung.TabStop = true;
            this.rdb_ngung.Text = "Ngừng sử dụng";
            this.rdb_ngung.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSalmon;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_tenct);
            this.groupBox1.Controls.Add(this.tb_sotiengiam);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tb_ma);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_sotiengiamgia);
            this.groupBox1.Controls.Add(this.dt_ngayketthuc);
            this.groupBox1.Controls.Add(this.dt_ngaybatdau);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdb_ngung);
            this.groupBox1.Controls.Add(this.rdb_con);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 367);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(621, 273);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết giảm giá";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Số tiền giảm";
            // 
            // tb_sotiengiam
            // 
            this.tb_sotiengiam.Location = new System.Drawing.Point(204, 185);
            this.tb_sotiengiam.Name = "tb_sotiengiam";
            this.tb_sotiengiam.Size = new System.Drawing.Size(310, 31);
            this.tb_sotiengiam.TabIndex = 15;
            // 
            // tb_ma
            // 
            this.tb_ma.Location = new System.Drawing.Point(204, 29);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(310, 31);
            this.tb_ma.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Giảm giá";
            // 
            // tb_sotiengiamgia
            // 
            this.tb_sotiengiamgia.Location = new System.Drawing.Point(194, 299);
            this.tb_sotiengiamgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_sotiengiamgia.Name = "tb_sotiengiamgia";
            this.tb_sotiengiamgia.Size = new System.Drawing.Size(300, 31);
            this.tb_sotiengiamgia.TabIndex = 12;
            // 
            // dt_ngayketthuc
            // 
            this.dt_ngayketthuc.Location = new System.Drawing.Point(204, 148);
            this.dt_ngayketthuc.Margin = new System.Windows.Forms.Padding(2);
            this.dt_ngayketthuc.Name = "dt_ngayketthuc";
            this.dt_ngayketthuc.Size = new System.Drawing.Size(310, 31);
            this.dt_ngayketthuc.TabIndex = 11;
            // 
            // dt_ngaybatdau
            // 
            this.dt_ngaybatdau.Location = new System.Drawing.Point(204, 115);
            this.dt_ngaybatdau.Margin = new System.Windows.Forms.Padding(2);
            this.dt_ngaybatdau.Name = "dt_ngaybatdau";
            this.dt_ngaybatdau.Size = new System.Drawing.Size(310, 31);
            this.dt_ngaybatdau.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày kết thúc";
            // 
            // tb_gia
            // 
            this.tb_gia.Location = new System.Drawing.Point(136, 118);
            this.tb_gia.Name = "tb_gia";
            this.tb_gia.Size = new System.Drawing.Size(213, 31);
            this.tb_gia.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 44;
            this.label6.Text = "Giá sản phẩm";
            // 
            // cbb_ma
            // 
            this.cbb_ma.FormattingEnabled = true;
            this.cbb_ma.Location = new System.Drawing.Point(134, 150);
            this.cbb_ma.Margin = new System.Windows.Forms.Padding(2);
            this.cbb_ma.Name = "cbb_ma";
            this.cbb_ma.Size = new System.Drawing.Size(213, 33);
            this.cbb_ma.TabIndex = 15;
            // 
            // tb_tenct
            // 
            this.tb_tenct.Location = new System.Drawing.Point(204, 73);
            this.tb_tenct.Name = "tb_tenct";
            this.tb_tenct.Size = new System.Drawing.Size(310, 31);
            this.tb_tenct.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 51;
            this.label8.Text = "Mã giảm giá";
            // 
            // FrmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1031, 769);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSale";
            this.Text = "FrmSale";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Button btn_sua;
        private Button btn_xoa;
        private Button btn_them;
        private DataGridViewTextBoxColumn Mã;
        private DataGridView dgv_show;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label4;
        private RadioButton rdb_con;
        private RadioButton rdb_ngung;
        private GroupBox groupBox1;
        private Label label5;
        private TextBox tb_sotiengiamgia;
        private DateTimePicker dt_ngayketthuc;
        private DateTimePicker dt_ngaybatdau;
        private Label label3;
 
 
        private TextBox tb_gia;
        private Label label6;
        private ComboBox cbb_ma;
        private Label label7;
        private TextBox tb_sotiengiam;
        private TextBox tb_ma;
        private Label label8;
        private TextBox tb_tenct;
    }
}