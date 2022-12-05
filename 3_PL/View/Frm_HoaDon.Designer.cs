namespace _3_PL.View
{
    partial class Frm_HoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HoaDon));
            this.cbb_khachhang = new System.Windows.Forms.ComboBox();
            this.cbb_MaHoaDon = new System.Windows.Forms.ComboBox();
            this.cbb_nhanvien = new System.Windows.Forms.ComboBox();
            this.rdb_chogiaohang = new System.Windows.Forms.RadioButton();
            this.rdb_dahuy = new System.Windows.Forms.RadioButton();
            this.rdb_dacoc = new System.Windows.Forms.RadioButton();
            this.rdb_chuatt = new System.Windows.Forms.RadioButton();
            this.rdb_datt = new System.Windows.Forms.RadioButton();
            this.dtp_ngaynhan = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngaythanhtoan = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngayship = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngaytao = new System.Windows.Forms.DateTimePicker();
            this.dtg_showHD = new System.Windows.Forms.DataGridView();
            this.btn_in = new System.Windows.Forms.Button();
            this.btn_chitiethoadon = new System.Windows.Forms.Button();
            this.btn_suaHD = new System.Windows.Forms.Button();
            this.txt_phantramgiamgia = new System.Windows.Forms.TextBox();
            this.txt_tenship = new System.Windows.Forms.TextBox();
            this.txt_sotienquydoi = new System.Windows.Forms.TextBox();
            this.txt_sodiemtieudung = new System.Windows.Forms.TextBox();
            this.txt_sdtShip = new System.Windows.Forms.TextBox();
            this.txt_tenguoiship = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_PDF = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_showHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_khachhang
            // 
            this.cbb_khachhang.FormattingEnabled = true;
            this.cbb_khachhang.Location = new System.Drawing.Point(314, 110);
            this.cbb_khachhang.Name = "cbb_khachhang";
            this.cbb_khachhang.Size = new System.Drawing.Size(200, 23);
            this.cbb_khachhang.TabIndex = 93;
            // 
            // cbb_MaHoaDon
            // 
            this.cbb_MaHoaDon.FormattingEnabled = true;
            this.cbb_MaHoaDon.Location = new System.Drawing.Point(314, 31);
            this.cbb_MaHoaDon.Name = "cbb_MaHoaDon";
            this.cbb_MaHoaDon.Size = new System.Drawing.Size(200, 23);
            this.cbb_MaHoaDon.TabIndex = 92;
            // 
            // cbb_nhanvien
            // 
            this.cbb_nhanvien.FormattingEnabled = true;
            this.cbb_nhanvien.Location = new System.Drawing.Point(314, 67);
            this.cbb_nhanvien.Name = "cbb_nhanvien";
            this.cbb_nhanvien.Size = new System.Drawing.Size(200, 23);
            this.cbb_nhanvien.TabIndex = 91;
            // 
            // rdb_chogiaohang
            // 
            this.rdb_chogiaohang.AutoSize = true;
            this.rdb_chogiaohang.ForeColor = System.Drawing.Color.Black;
            this.rdb_chogiaohang.Location = new System.Drawing.Point(1142, 14);
            this.rdb_chogiaohang.Name = "rdb_chogiaohang";
            this.rdb_chogiaohang.Size = new System.Drawing.Size(106, 19);
            this.rdb_chogiaohang.TabIndex = 86;
            this.rdb_chogiaohang.TabStop = true;
            this.rdb_chogiaohang.Text = "Chờ Giao Hàng";
            this.rdb_chogiaohang.UseVisualStyleBackColor = true;
            // 
            // rdb_dahuy
            // 
            this.rdb_dahuy.AutoSize = true;
            this.rdb_dahuy.ForeColor = System.Drawing.Color.Black;
            this.rdb_dahuy.Location = new System.Drawing.Point(993, 43);
            this.rdb_dahuy.Name = "rdb_dahuy";
            this.rdb_dahuy.Size = new System.Drawing.Size(64, 19);
            this.rdb_dahuy.TabIndex = 87;
            this.rdb_dahuy.TabStop = true;
            this.rdb_dahuy.Text = "Đã Hủy";
            this.rdb_dahuy.UseVisualStyleBackColor = true;
            // 
            // rdb_dacoc
            // 
            this.rdb_dacoc.AutoSize = true;
            this.rdb_dacoc.ForeColor = System.Drawing.Color.Black;
            this.rdb_dacoc.Location = new System.Drawing.Point(839, 43);
            this.rdb_dacoc.Name = "rdb_dacoc";
            this.rdb_dacoc.Size = new System.Drawing.Size(63, 19);
            this.rdb_dacoc.TabIndex = 90;
            this.rdb_dacoc.TabStop = true;
            this.rdb_dacoc.Text = "Đã Cọc";
            this.rdb_dacoc.UseVisualStyleBackColor = true;
            // 
            // rdb_chuatt
            // 
            this.rdb_chuatt.AutoSize = true;
            this.rdb_chuatt.ForeColor = System.Drawing.Color.Black;
            this.rdb_chuatt.Location = new System.Drawing.Point(993, 14);
            this.rdb_chuatt.Name = "rdb_chuatt";
            this.rdb_chuatt.Size = new System.Drawing.Size(117, 19);
            this.rdb_chuatt.TabIndex = 89;
            this.rdb_chuatt.TabStop = true;
            this.rdb_chuatt.Text = "Chưa Thanh Toán";
            this.rdb_chuatt.UseVisualStyleBackColor = true;
            // 
            // rdb_datt
            // 
            this.rdb_datt.AutoSize = true;
            this.rdb_datt.ForeColor = System.Drawing.Color.Black;
            this.rdb_datt.Location = new System.Drawing.Point(839, 14);
            this.rdb_datt.Name = "rdb_datt";
            this.rdb_datt.Size = new System.Drawing.Size(103, 19);
            this.rdb_datt.TabIndex = 88;
            this.rdb_datt.TabStop = true;
            this.rdb_datt.Text = "Đã Thanh Toán";
            this.rdb_datt.UseVisualStyleBackColor = true;
            // 
            // dtp_ngaynhan
            // 
            this.dtp_ngaynhan.Location = new System.Drawing.Point(314, 284);
            this.dtp_ngaynhan.Name = "dtp_ngaynhan";
            this.dtp_ngaynhan.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngaynhan.TabIndex = 85;
            // 
            // dtp_ngaythanhtoan
            // 
            this.dtp_ngaythanhtoan.Location = new System.Drawing.Point(314, 202);
            this.dtp_ngaythanhtoan.Name = "dtp_ngaythanhtoan";
            this.dtp_ngaythanhtoan.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngaythanhtoan.TabIndex = 84;
            // 
            // dtp_ngayship
            // 
            this.dtp_ngayship.Location = new System.Drawing.Point(314, 247);
            this.dtp_ngayship.Name = "dtp_ngayship";
            this.dtp_ngayship.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngayship.TabIndex = 83;
            // 
            // dtp_ngaytao
            // 
            this.dtp_ngaytao.Location = new System.Drawing.Point(314, 165);
            this.dtp_ngaytao.Name = "dtp_ngaytao";
            this.dtp_ngaytao.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngaytao.TabIndex = 82;
            // 
            // dtg_showHD
            // 
            this.dtg_showHD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtg_showHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_showHD.Location = new System.Drawing.Point(81, 422);
            this.dtg_showHD.Name = "dtg_showHD";
            this.dtg_showHD.RowTemplate.Height = 25;
            this.dtg_showHD.Size = new System.Drawing.Size(1396, 254);
            this.dtg_showHD.TabIndex = 81;
            this.dtg_showHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_showHD_CellClick);
            // 
            // btn_in
            // 
            this.btn_in.BackColor = System.Drawing.Color.SaddleBrown;
            this.btn_in.FlatAppearance.BorderSize = 0;
            this.btn_in.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_in.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_in.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_in.Location = new System.Drawing.Point(1196, 234);
            this.btn_in.Margin = new System.Windows.Forms.Padding(2);
            this.btn_in.Name = "btn_in";
            this.btn_in.Size = new System.Drawing.Size(53, 50);
            this.btn_in.TabIndex = 80;
            this.btn_in.Text = "In";
            this.btn_in.UseVisualStyleBackColor = false;
            this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
            // 
            // btn_chitiethoadon
            // 
            this.btn_chitiethoadon.BackColor = System.Drawing.Color.SaddleBrown;
            this.btn_chitiethoadon.FlatAppearance.BorderSize = 0;
            this.btn_chitiethoadon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chitiethoadon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_chitiethoadon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_chitiethoadon.Location = new System.Drawing.Point(85, 343);
            this.btn_chitiethoadon.Margin = new System.Windows.Forms.Padding(2);
            this.btn_chitiethoadon.Name = "btn_chitiethoadon";
            this.btn_chitiethoadon.Size = new System.Drawing.Size(96, 50);
            this.btn_chitiethoadon.TabIndex = 79;
            this.btn_chitiethoadon.Text = "CTHD";
            this.btn_chitiethoadon.UseVisualStyleBackColor = false;
            this.btn_chitiethoadon.Click += new System.EventHandler(this.btn_chitiethoadon_Click);
            // 
            // btn_suaHD
            // 
            this.btn_suaHD.BackColor = System.Drawing.Color.SaddleBrown;
            this.btn_suaHD.FlatAppearance.BorderSize = 0;
            this.btn_suaHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_suaHD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_suaHD.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_suaHD.Location = new System.Drawing.Point(1196, 148);
            this.btn_suaHD.Margin = new System.Windows.Forms.Padding(2);
            this.btn_suaHD.Name = "btn_suaHD";
            this.btn_suaHD.Size = new System.Drawing.Size(96, 50);
            this.btn_suaHD.TabIndex = 78;
            this.btn_suaHD.Text = "Sua Hoa Don";
            this.btn_suaHD.UseVisualStyleBackColor = false;
            this.btn_suaHD.Click += new System.EventHandler(this.btn_suaHD_Click);
            // 
            // txt_phantramgiamgia
            // 
            this.txt_phantramgiamgia.Location = new System.Drawing.Point(850, 311);
            this.txt_phantramgiamgia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_phantramgiamgia.Name = "txt_phantramgiamgia";
            this.txt_phantramgiamgia.Size = new System.Drawing.Size(205, 23);
            this.txt_phantramgiamgia.TabIndex = 75;
            // 
            // txt_tenship
            // 
            this.txt_tenship.Location = new System.Drawing.Point(850, 171);
            this.txt_tenship.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tenship.Name = "txt_tenship";
            this.txt_tenship.Size = new System.Drawing.Size(205, 23);
            this.txt_tenship.TabIndex = 74;
            // 
            // txt_sotienquydoi
            // 
            this.txt_sotienquydoi.Location = new System.Drawing.Point(850, 221);
            this.txt_sotienquydoi.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sotienquydoi.Name = "txt_sotienquydoi";
            this.txt_sotienquydoi.Size = new System.Drawing.Size(205, 23);
            this.txt_sotienquydoi.TabIndex = 72;
            // 
            // txt_sodiemtieudung
            // 
            this.txt_sodiemtieudung.Location = new System.Drawing.Point(850, 261);
            this.txt_sodiemtieudung.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sodiemtieudung.Name = "txt_sodiemtieudung";
            this.txt_sodiemtieudung.Size = new System.Drawing.Size(205, 23);
            this.txt_sodiemtieudung.TabIndex = 71;
            // 
            // txt_sdtShip
            // 
            this.txt_sdtShip.Location = new System.Drawing.Point(850, 81);
            this.txt_sdtShip.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sdtShip.Name = "txt_sdtShip";
            this.txt_sdtShip.Size = new System.Drawing.Size(205, 23);
            this.txt_sdtShip.TabIndex = 70;
            // 
            // txt_tenguoiship
            // 
            this.txt_tenguoiship.Location = new System.Drawing.Point(850, 121);
            this.txt_tenguoiship.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tenguoiship.Name = "txt_tenguoiship";
            this.txt_tenguoiship.Size = new System.Drawing.Size(205, 23);
            this.txt_tenguoiship.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(85, 287);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 67;
            this.label9.Text = "Ngày Nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(85, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Ngày Ship";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(85, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 66;
            this.label5.Text = "Ngày Thanh Toán";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(85, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 65;
            this.label6.Text = "Ngày Tạo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(617, 314);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 20);
            this.label16.TabIndex = 63;
            this.label16.Text = "Phần Trăm Giảm Giá";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(617, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 60;
            this.label10.Text = "Tình Trạng";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(617, 174);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 20);
            this.label13.TabIndex = 62;
            this.label13.Text = "Tên Ship";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(617, 264);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 20);
            this.label15.TabIndex = 56;
            this.label15.Text = "Số Điểm Tiêu Dùng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(617, 124);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 20);
            this.label12.TabIndex = 58;
            this.label12.Text = "Tên Người Ship";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(617, 220);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 20);
            this.label14.TabIndex = 55;
            this.label14.Text = "Số Tiền Quy Đổi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(81, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "Khách Hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(617, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 54;
            this.label11.Text = "Số ĐT Ship";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(81, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(81, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Mã Hóa Đơn";
            // 
            // pictureBox_PDF
            // 
            this.pictureBox_PDF.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_PDF.ErrorImage")));
            this.pictureBox_PDF.Image = global::_3_PL.Properties.Resources.icons8_pdf_50;
            this.pictureBox_PDF.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_PDF.InitialImage")));
            this.pictureBox_PDF.Location = new System.Drawing.Point(1232, 371);
            this.pictureBox_PDF.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox_PDF.Name = "pictureBox_PDF";
            this.pictureBox_PDF.Size = new System.Drawing.Size(94, 46);
            this.pictureBox_PDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_PDF.TabIndex = 96;
            this.pictureBox_PDF.TabStop = false;
            this.pictureBox_PDF.Click += new System.EventHandler(this.pictureBox_PDF_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_3_PL.Properties.Resources.icons8_microsoft_excel_2019_48;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1107, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 97;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(264, 369);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 20);
            this.label17.TabIndex = 94;
            this.label17.Text = "Tìm kiếm";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(369, 370);
            this.txt_timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(205, 23);
            this.txt_timkiem.TabIndex = 95;
            // 
            // Frm_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1762, 897);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_PDF);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cbb_khachhang);
            this.Controls.Add(this.cbb_MaHoaDon);
            this.Controls.Add(this.cbb_nhanvien);
            this.Controls.Add(this.rdb_chogiaohang);
            this.Controls.Add(this.rdb_dahuy);
            this.Controls.Add(this.rdb_dacoc);
            this.Controls.Add(this.rdb_chuatt);
            this.Controls.Add(this.rdb_datt);
            this.Controls.Add(this.dtp_ngaynhan);
            this.Controls.Add(this.dtp_ngaythanhtoan);
            this.Controls.Add(this.dtp_ngayship);
            this.Controls.Add(this.dtp_ngaytao);
            this.Controls.Add(this.dtg_showHD);
            this.Controls.Add(this.btn_in);
            this.Controls.Add(this.btn_chitiethoadon);
            this.Controls.Add(this.btn_suaHD);
            this.Controls.Add(this.txt_phantramgiamgia);
            this.Controls.Add(this.txt_tenship);
            this.Controls.Add(this.txt_sotienquydoi);
            this.Controls.Add(this.txt_sodiemtieudung);
            this.Controls.Add(this.txt_sdtShip);
            this.Controls.Add(this.txt_tenguoiship);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_HoaDon";
            this.Text = "Frm_Hoadon";
            this.TransparencyKey = System.Drawing.Color.PaleTurquoise;
            this.Load += new System.EventHandler(this.Frm_Receipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_showHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox cbb_khachhang;
        private ComboBox cbb_MaHoaDon;
        private ComboBox cbb_nhanvien;
        private RadioButton rdb_chogiaohang;
        private RadioButton rdb_dahuy;
        private RadioButton rdb_dacoc;
        private RadioButton rdb_chuatt;
        private RadioButton rdb_datt;
        private DateTimePicker dtp_ngaynhan;
        private DateTimePicker dtp_ngaythanhtoan;
        private DateTimePicker dtp_ngayship;
        private DateTimePicker dtp_ngaytao;
        private DataGridView dtg_showHD;
        private Button btn_in;
        private Button btn_chitiethoadon;
        private Button btn_suaHD;
        private TextBox txt_phantramgiamgia;
        private TextBox txt_tenship;
        private TextBox txt_sotienquydoi;
        private TextBox txt_sodiemtieudung;
        private TextBox txt_sdtShip;
        private TextBox txt_tenguoiship;
        private Label label9;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label16;
        private Label label10;
        private Label label13;
        private Label label15;
        private Label label12;
        private Label label14;
        private Label label4;
        private Label label11;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox_PDF;
        private PictureBox pictureBox1;
        private Label label17;
        private TextBox txt_timkiem;
    }
}