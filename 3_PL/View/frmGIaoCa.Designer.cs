namespace _3_PL.View
{
    partial class frmGIaoCa
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
            this.components = new System.ComponentModel.Container();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvGiaoCa = new System.Windows.Forms.DataGridView();
            this.giaoCaViewModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongTienBanDau = new System.Windows.Forms.TextBox();
            this.dtpThoiGianNhan = new System.Windows.Forms.DateTimePicker();
            this.dtpThoiGianGiao = new System.Windows.Forms.DateTimePicker();
            this.cbNhanVienNhan = new System.Windows.Forms.ComboBox();
            this.txtNhanVienGiao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTienKhac = new System.Windows.Forms.TextBox();
            this.txtTienMat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTienTrongCa = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaoCaViewModelsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(91, 269);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(712, 23);
            this.txtTimKiem.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox2.Controls.Add(this.btnLuu);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Location = new System.Drawing.Point(808, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(167, 285);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LightSalmon;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(5, 192);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 39);
            this.btnLuu.TabIndex = 56;
            this.btnLuu.Text = "   Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LightSalmon;
            this.btnThem.Location = new System.Drawing.Point(5, 29);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 42);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "   Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSua.Location = new System.Drawing.Point(5, 83);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 43);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "   Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSalmon;
            this.btnClear.Location = new System.Drawing.Point(5, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 43);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "       Làm sạch";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox3.Controls.Add(this.dgvGiaoCa);
            this.groupBox3.Location = new System.Drawing.Point(10, 298);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(965, 255);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách giao ca";
            // 
            // dgvGiaoCa
            // 
            this.dgvGiaoCa.AutoGenerateColumns = false;
            this.dgvGiaoCa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiaoCa.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.dgvGiaoCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoCa.DataSource = this.giaoCaViewModelsBindingSource;
            this.dgvGiaoCa.Location = new System.Drawing.Point(5, 19);
            this.dgvGiaoCa.Name = "dgvGiaoCa";
            this.dgvGiaoCa.RowHeadersVisible = false;
            this.dgvGiaoCa.RowHeadersWidth = 62;
            this.dgvGiaoCa.RowTemplate.Height = 25;
            this.dgvGiaoCa.Size = new System.Drawing.Size(940, 231);
            this.dgvGiaoCa.TabIndex = 33;
            this.dgvGiaoCa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiaoCa_CellClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.SandyBrown;
            this.btnTimKiem.Location = new System.Drawing.Point(10, 267);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 26);
            this.btnTimKiem.TabIndex = 55;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 15);
            this.label13.TabIndex = 61;
            this.label13.Text = "Nhân viên giao:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox1.Controls.Add(this.txtTongTienBanDau);
            this.groupBox1.Controls.Add(this.dtpThoiGianNhan);
            this.groupBox1.Controls.Add(this.dtpThoiGianGiao);
            this.groupBox1.Controls.Add(this.cbNhanVienNhan);
            this.groupBox1.Controls.Add(this.txtNhanVienGiao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(793, 126);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // txtTongTienBanDau
            // 
            this.txtTongTienBanDau.Location = new System.Drawing.Point(109, 94);
            this.txtTongTienBanDau.Name = "txtTongTienBanDau";
            this.txtTongTienBanDau.Size = new System.Drawing.Size(255, 23);
            this.txtTongTienBanDau.TabIndex = 65;
            // 
            // dtpThoiGianNhan
            // 
            this.dtpThoiGianNhan.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpThoiGianNhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianNhan.Location = new System.Drawing.Point(526, 59);
            this.dtpThoiGianNhan.Name = "dtpThoiGianNhan";
            this.dtpThoiGianNhan.Size = new System.Drawing.Size(255, 23);
            this.dtpThoiGianNhan.TabIndex = 64;
            // 
            // dtpThoiGianGiao
            // 
            this.dtpThoiGianGiao.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpThoiGianGiao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianGiao.Location = new System.Drawing.Point(109, 59);
            this.dtpThoiGianGiao.Name = "dtpThoiGianGiao";
            this.dtpThoiGianGiao.Size = new System.Drawing.Size(255, 23);
            this.dtpThoiGianGiao.TabIndex = 64;
            // 
            // cbNhanVienNhan
            // 
            this.cbNhanVienNhan.FormattingEnabled = true;
            this.cbNhanVienNhan.Location = new System.Drawing.Point(526, 26);
            this.cbNhanVienNhan.Name = "cbNhanVienNhan";
            this.cbNhanVienNhan.Size = new System.Drawing.Size(255, 23);
            this.cbNhanVienNhan.TabIndex = 63;
            this.cbNhanVienNhan.SelectedIndexChanged += new System.EventHandler(this.cbNhanVienNhan_SelectedIndexChanged);
            // 
            // txtNhanVienGiao
            // 
            this.txtNhanVienGiao.Enabled = false;
            this.txtNhanVienGiao.Location = new System.Drawing.Point(109, 26);
            this.txtNhanVienGiao.Name = "txtNhanVienGiao";
            this.txtNhanVienGiao.Size = new System.Drawing.Size(255, 23);
            this.txtNhanVienGiao.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 61;
            this.label3.Text = "Thời gian nhận:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 61;
            this.label1.Text = "Nhân viên nhận:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 61;
            this.label7.Text = "Tiền ban đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 61;
            this.label2.Text = "Thời gian ca:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtGhiChu);
            this.groupBox4.Controls.Add(this.txtTienKhac);
            this.groupBox4.Controls.Add(this.txtTienMat);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtTienTrongCa);
            this.groupBox4.Location = new System.Drawing.Point(10, 138);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(793, 126);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin thu chi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 63;
            this.label8.Text = "Ghi chú:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 63;
            this.label6.Text = "Tiền khác:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 63;
            this.label4.Text = "Tiền mặt:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(109, 62);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(255, 59);
            this.txtGhiChu.TabIndex = 64;
            // 
            // txtTienKhac
            // 
            this.txtTienKhac.Location = new System.Drawing.Point(526, 62);
            this.txtTienKhac.Name = "txtTienKhac";
            this.txtTienKhac.Size = new System.Drawing.Size(255, 23);
            this.txtTienKhac.TabIndex = 64;
            // 
            // txtTienMat
            // 
            this.txtTienMat.Location = new System.Drawing.Point(526, 25);
            this.txtTienMat.Name = "txtTienMat";
            this.txtTienMat.Size = new System.Drawing.Size(255, 23);
            this.txtTienMat.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 61;
            this.label5.Text = "Tiền trong ca:";
            // 
            // txtTienTrongCa
            // 
            this.txtTienTrongCa.Location = new System.Drawing.Point(109, 25);
            this.txtTienTrongCa.Name = "txtTienTrongCa";
            this.txtTienTrongCa.Size = new System.Drawing.Size(255, 23);
            this.txtTienTrongCa.TabIndex = 62;
            // 
            // frmGIaoCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTimKiem);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmGIaoCa";
            this.Text = "Quản lý giao ca";
            this.Load += new System.EventHandler(this.frmGIaoCa_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.giaoCaViewModelsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtTimKiem;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView dgvGiaoCa;
        private Button btnThem;
        private Button btnSua;
        private Button btnClear;
        private Button btnTimKiem;
        private Button btnLuu;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tenDemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hoTenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gioiTinhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn namSinhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn queQuanDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sdtDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn matKhauDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cMNDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCvDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn trangThaiDataGridViewTextBoxColumn;
        private DataGridViewImageColumn anhDataGridViewImageColumn;
        private Label label13;
        private GroupBox groupBox1;
        private ComboBox cbNhanVienNhan;
        private TextBox txtNhanVienGiao;
        private Label label1;
        private DateTimePicker dtpThoiGianGiao;
        private Label label2;
        private DateTimePicker dtpThoiGianNhan;
        private Label label3;
        private GroupBox groupBox4;
        private TextBox txtTienTrongCa;
        private Label label5;
        private Label label7;
        private Label label4;
        private TextBox txtTienMat;
        private Label label6;
        private TextBox txtTienKhac;
        private Label label8;
        private TextBox txtGhiChu;
        private BindingSource giaoCaViewModelsBindingSource;
        private TextBox txtTongTienBanDau;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn thoiGianNhanCaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn thoiGianGiaoCaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idNvNhanCaTiepDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idNvTrongCaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tienBanDauDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tongTienTrongCaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tongTienMatDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tongTienKhacDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tienPhatSinhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ghiChuPhatSinhDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tongTienCaTruocDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tongTienMatRutDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn strTrangThaiDataGridViewTextBoxColumn;
    }
}