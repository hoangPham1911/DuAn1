using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Service;
using _2_BUS.Services;
using _2_BUS.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;

namespace _3_PL.View
{
    public partial class Frm_HoaDon : Form
    {
        IHoaDonService _HDService;
        INhanVienServices _NVService;
        IKhachHangServices _KHService;
        IHoaDonChiTietService _HDCTservice;
        IHangHoaServices _HangHoaServices;
        public static Guid Currenid;
        //string connect = @"Data Source=SADBOY\SQLEXPRESS;Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=ph27584;Password=123456";
        public Frm_HoaDon()
        {


            InitializeComponent();
            _HDService = new HoaDonService();
            _NVService = new NhanVienServices();
            _KHService = new KhachHangServices();
            _HDCTservice = new HoaDonChiTietService();
            _HangHoaServices = new HangHoaServices();
            LoadDTG();
            LoadCombobox();
            LoadCTHD(Currenid);
        }
        void LoadCombobox()
        {
            foreach (var c in _HDService.GetAllHoaDonDB())
            {
                cbb_MaHoaDon.Items.Add(c.Ma);
            }
            foreach (var d in _NVService.GetAll())
            {
                cbb_nhanvien.Items.Add(d.Ten);
            }
            foreach (var z in _KHService.GetAllKhachHangDB())
            {
                cbb_khachhang.Items.Add(z.Ten);
            }
        }
        private void Frm_Receipt_Load(object sender, EventArgs e)
        {

        }

        int i = 1;

        void LoadDTG()
        {
            dtg_showHD.Rows.Clear();
            dtg_showHD.ColumnCount = 14;
            dtg_showHD.Columns[0].Name = "ID";
            dtg_showHD.Columns[0].Visible = false;
            dtg_showHD.Columns[1].Name = "MAHD";
            dtg_showHD.Columns[2].Name = "Nhan Vien";
            dtg_showHD.Columns[3].Name = "Khach Hang";
            dtg_showHD.Columns[4].Name = "Ngay Tao";
            dtg_showHD.Columns[5].Name = "Ngay Thanh Toan";
            dtg_showHD.Columns[6].Name = "Ngay Ship";
            dtg_showHD.Columns[7].Name = "Ngay Nhan";
            dtg_showHD.Columns[8].Name = "Tinh Trang";
            dtg_showHD.Columns[9].Name = "SDT Ship";
            dtg_showHD.Columns[10].Name = "Tên Ship";
            dtg_showHD.Columns[11].Name = "Số Tiền Quy Đổi";
            dtg_showHD.Columns[12].Name = "Số Điểm Tiêu Dùng";
            dtg_showHD.Columns[13].Name = "Phần Trăm Giảm Giá";
            foreach (var x in _HDService.GetAllHoaDonDB())
            {
                dtg_showHD.Rows.Add(
                    x.IdHoaDon,
                    x.Ma,
                    x.IdNv != null ? _NVService.GetAll().FirstOrDefault(c => c.Id == x.IdNv).Ten : null,
                    x.IdKh != null ? _KHService.GetAllKhachHangDB().FirstOrDefault(c => c.Idkh == x.IdKh).Ten : null,
                    x.NgayTao,
                    x.NgayThanhToan,
                    x.NgayShip,
                    x.NgayNhan,
                    x.TinhTrang == 1 ? "Da TT" : x.TinhTrang == 0 ? "Chua TT" : x.TinhTrang == 2 ? "Chờ Giao Hàng" : x.TinhTrang == 3 ? "Da Huy" : "Đã Cọc",
                    //x.Thue,
                    x.SDTShip,
                    x.TenShip,
                    x.SoTienQuyDoi,
                    x.SoDiemSuDung,
                    x.PhanTramGiamGia);
            }

        }

        void TimKiemHoaDOnTheoMa(string MaHD)
        {
            dtg_showHD.Rows.Clear();
            foreach (var x in _HDService.timkiemHoadonTheoMa(MaHD))
            {
                dtg_showHD.Rows.Add(
                    x.Id,
                    x.Ma,
                    x.IdNv != null ? _NVService.GetAll().FirstOrDefault(c => c.Id == x.IdNv).Ten : null,
                    x.IdKh != null ? _KHService.GetAllKhachHangDB().FirstOrDefault(c => c.Idkh == x.IdKh).Ten : null,
                    x.NgayTao,
                    x.NgayThanhToan,
                    x.NgayShip,
                    x.NgayNhan,
                    x.TinhTrang == 1 ? "Da TT" : x.TinhTrang == 0 ? "Chua TT" : x.TinhTrang == 2 ? "Chờ Giao Hàng" : x.TinhTrang == 3 ? "Da Huy" : "Đã Cọc",
                    //x.Thue,
                    x.SDTShip,
                    x.TenShip,
                    x.SoTienQuyDoi,
                    x.SoDiemSuDung
                   /* x.PhanTramGiamGia*/);
            }
        }

        public static Guid tox;
        private void dtg_showHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Currenid = Guid.Parse(dtg_showHD.CurrentRow.Cells[0].Value.ToString());
                var hd = _HDService.GetAllHoaDonDB().FirstOrDefault(c => c.IdHoaDon == Currenid);
                cbb_MaHoaDon.Text = hd.Ma.ToString();
                cbb_nhanvien.Text = hd.IdNv != null ? _NVService.GetAll().FirstOrDefault(c => c.Id == hd.IdNv).Ten.ToString() : null;
                cbb_khachhang.Text = hd.IdKh != null ? _KHService.GetAllKhachHangDB().FirstOrDefault(c => c.Idkh == hd.IdKh).Ten.ToString() : null;
                dtp_ngaytao.Text = hd.NgayTao.ToString();
                dtp_ngaythanhtoan.Text = hd.NgayThanhToan.ToString();
                dtp_ngayship.Text = hd.NgayShip.ToString();
                dtp_ngaynhan.Text = hd.NgayNhan.ToString();
                rdb_datt.Checked = hd.TinhTrang == 1;
                rdb_chuatt.Checked = hd.TinhTrang == 0;
                rdb_chogiaohang.Checked = hd.TinhTrang == 2;
                rdb_dahuy.Checked = hd.TinhTrang == 3;
                rdb_dacoc.Checked = hd.TinhTrang == 4;
                txt_sdtShip.Text = hd.SDTShip.ToString();
                txt_tenship.Text = hd.TenShip.ToString();
                txt_sotienquydoi.Text = hd.SoTienQuyDoi.ToString();
                txt_sodiemtieudung.Text = hd.SoDiemSuDung.ToString();
                txt_phantramgiamgia.Text = hd.PhanTramGiamGia.ToString();
                LoadCTHD(Currenid);
            }
            catch (Exception)
            {
                LoadCTHD(Currenid);
                return;
            }
        }

        private void btn_chitiethoadon_Click(object sender, EventArgs e)
        {
            Currenid = Guid.Parse(dtg_showHD.CurrentRow.Cells[0].Value.ToString());
            var hd = _HDService.GetAllHoaDonDB().FirstOrDefault(c => c.IdHoaDon == Currenid);
            tox = Currenid;
            ctspINhoadon ctspINhoadon = new ctspINhoadon();
            ctspINhoadon.Show();
        }
        private void btn_suaHD_Click(object sender, EventArgs e)
        {

            var idkh = _KHService.GetAllKhachHangDB().FirstOrDefault(x => x.Ten == cbb_khachhang.Text);
            var idnv = _NVService.GetAll().FirstOrDefault(x => x.Ten == cbb_nhanvien.Text);
            SuaHoaDonModels suaHoaDon = new SuaHoaDonModels() { };
            suaHoaDon.IdHoaDon = Currenid;
            suaHoaDon.IdKh = _KHService.GetAllKhachHangDB().FirstOrDefault(x => x.Ten == cbb_khachhang.Text).Idkh;
            suaHoaDon.IdNv = idnv.Id;
            suaHoaDon.NgayTao = dtp_ngaytao.Value;
            suaHoaDon.NgayThanhToan = dtp_ngaythanhtoan.Value;
            suaHoaDon.NgayShip = dtp_ngayship.Value;
            suaHoaDon.NgayNhan = dtp_ngaynhan.Value;
            suaHoaDon.TinhTrang = rdb_datt.Checked ? 1 : rdb_chuatt.Checked ? 0 : rdb_chogiaohang.Checked ? 2 : rdb_dahuy.Checked ? 3 : 4;
            suaHoaDon.SDTShip = txt_sdtShip.Text;
            suaHoaDon.TenShip = txt_tenship.Text;
            suaHoaDon.SoTienQuyDoi = Convert.ToDecimal(txt_sotienquydoi.Text);
            suaHoaDon.SoDiemSuDung = Convert.ToInt32(txt_sodiemtieudung.Text);
            suaHoaDon.PhanTramGiamGia = Convert.ToDecimal(txt_phantramgiamgia.Text);

            try
            {
                if (_HDService.SuaHoaDon(suaHoaDon) != null)
                {
                    MessageBox.Show("Chinh Sua Thanh Cong");
                    LoadDTG();
                }
                else MessageBox.Show("Chinh Sua that bai");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chinh Sua that bai");
            }


        }

        void LoadCTHD(Guid Currenid)
        {
            dtgShow_CTHD.Rows.Clear();
            dtgShow_CTHD.ColumnCount = 7;
            dtgShow_CTHD.Columns[0].Name = "ID";
            dtgShow_CTHD.Columns[0].Visible = false;
            dtgShow_CTHD.Columns[1].Name = "MAHD";
            dtgShow_CTHD.Columns[2].Name = "Sản Phẩm";
            dtgShow_CTHD.Columns[3].Name = "Số Lượng";
            dtgShow_CTHD.Columns[4].Name = "Thành Tiền";
            dtgShow_CTHD.Columns[5].Name = "Trạng Thái";
            dtgShow_CTHD.Columns[6].Name = "Giảm Giá";

            foreach (var x in _HDCTservice.timkiemhdtheoid(Currenid))
            {
                dtgShow_CTHD.Rows.Add(
                    x.IdHoaDon,
                    _HDService.GetAllHoaDonDB().FirstOrDefault(c => c.IdHoaDon == x.IdHoaDon).Ma,
                    _HangHoaServices.getlsthanghoafromDB().FirstOrDefault(c => c.Id == x.IdChiTietSp).Ten,
                    x.SoLuong,
                    x.ThanhTien,
                    x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng",
                    x.GiamGia);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // excel


            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn Xuất Ra File Excel Hay Không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    dtg_showHD.SelectAll();
                    DataObject copydata = dtg_showHD.GetClipboardContent();
                    if (copydata != null) Clipboard.SetDataObject(copydata);
                    Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                    xlapp.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook _xlwook;
                    Microsoft.Office.Interop.Excel.Worksheet _xlsheet;
                    object misedadata = System.Reflection.Missing.Value;
                    _xlwook = xlapp.Workbooks.Add(misedadata);

                    _xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)_xlwook.Worksheets.get_Item(1);
                    Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)_xlsheet.Cells[1, 1];
                    xlr.Select();
                    _xlsheet.PasteSpecial(xlr/*,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing*/);
                    for (int i = 0; i < 2; i++)
                    {

                        MessageBox.Show("Xuất Ra File Excel Thành Công");

                    }
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {

                        MessageBox.Show("Xuất Ra File Excel Thất Bại");

                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                for (int i = 0; i < 2; i++)
                {

                    MessageBox.Show("Lỗi Rồi" + ex.Message);

                }

                return;
            }


        }


        public void exportdata(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Add header;
            foreach (DataGridViewColumn col in dtg_showHD.Columns)
            {
                PdfPCell pdfPCell = new PdfPCell(new Phrase(col.HeaderText));
                pdfPTable.AddCell(pdfPCell);
            }
            foreach (DataGridViewRow row in dtg_showHD.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfPTable.AddCell(new Phrase(Convert.ToString(cell.Value), text));
                }
            }
            var savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = filename;
            savefiledialog.DefaultExt = ".pdf";
            if (savefiledialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialog.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A1, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfPTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }


        }

        private void pictureBox_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn Xuất Ra File PDF Hay Không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    exportdata(dtg_showHD, "test");
                    for (int i = 0; i < 2; i++)
                    {

                        MessageBox.Show("Xuất Ra File PDF Thành Công");

                    }
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    for (int i = 0; i < 2; i++)
                    {

                        MessageBox.Show("Xuất Ra File PDF Thất Bại");

                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                for (int i = 0; i < 2; i++)
                {

                    MessageBox.Show("Lỗi Rồi" + ex.Message);

                }
                return;
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemHoaDOnTheoMa(txt_timkiem.Text);
        }

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox_PDF;
        private PictureBox pictureBox1;
        private TextBox txt_timkiem;
        private Label label17;
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
        private DataGridView dtgShow_CTHD;
        private DataGridView dtg_showHD;
        private Button btn_suaHD;
        private TextBox txt_phantramgiamgia;
        private TextBox txt_tenship;
        private TextBox txt_sotienquydoi;
        private TextBox txt_sodiemtieudung;
        private TextBox txt_sdtShip;
        private Label label9;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label16;
        private Label label10;
        private Label label13;
        private Label label15;
        private Label label14;
        private Label label4;
        private Label label11;
        private Label label2;
        private Label label1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HoaDon));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox_PDF = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.dtgShow_CTHD = new System.Windows.Forms.DataGridView();
            this.dtg_showHD = new System.Windows.Forms.DataGridView();
            this.btn_suaHD = new System.Windows.Forms.Button();
            this.txt_phantramgiamgia = new System.Windows.Forms.TextBox();
            this.txt_tenship = new System.Windows.Forms.TextBox();
            this.txt_sotienquydoi = new System.Windows.Forms.TextBox();
            this.txt_sodiemtieudung = new System.Windows.Forms.TextBox();
            this.txt_sdtShip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgShow_CTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_showHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_PDF
            // 
            this.pictureBox_PDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureBox_PDF.ErrorImage = null;
            this.pictureBox_PDF.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_PDF.Image")));
            this.pictureBox_PDF.InitialImage = null;
            this.pictureBox_PDF.Location = new System.Drawing.Point(1344, 361);
            this.pictureBox_PDF.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox_PDF.Name = "pictureBox_PDF";
            this.pictureBox_PDF.Size = new System.Drawing.Size(70, 70);
            this.pictureBox_PDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_PDF.TabIndex = 133;
            this.pictureBox_PDF.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1267, 360);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 134;
            this.pictureBox1.TabStop = false;
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(517, 384);
            this.txt_timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(205, 23);
            this.txt_timkiem.TabIndex = 132;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(412, 383);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 20);
            this.label17.TabIndex = 131;
            this.label17.Text = "Tìm kiếm";
            // 
            // cbb_khachhang
            // 
            this.cbb_khachhang.FormattingEnabled = true;
            this.cbb_khachhang.Location = new System.Drawing.Point(462, 124);
            this.cbb_khachhang.Name = "cbb_khachhang";
            this.cbb_khachhang.Size = new System.Drawing.Size(200, 23);
            this.cbb_khachhang.TabIndex = 130;
            // 
            // cbb_MaHoaDon
            // 
            this.cbb_MaHoaDon.FormattingEnabled = true;
            this.cbb_MaHoaDon.Location = new System.Drawing.Point(462, 45);
            this.cbb_MaHoaDon.Name = "cbb_MaHoaDon";
            this.cbb_MaHoaDon.Size = new System.Drawing.Size(200, 23);
            this.cbb_MaHoaDon.TabIndex = 129;
            // 
            // cbb_nhanvien
            // 
            this.cbb_nhanvien.FormattingEnabled = true;
            this.cbb_nhanvien.Location = new System.Drawing.Point(462, 81);
            this.cbb_nhanvien.Name = "cbb_nhanvien";
            this.cbb_nhanvien.Size = new System.Drawing.Size(200, 23);
            this.cbb_nhanvien.TabIndex = 128;
            // 
            // rdb_chogiaohang
            // 
            this.rdb_chogiaohang.AutoSize = true;
            this.rdb_chogiaohang.ForeColor = System.Drawing.Color.Black;
            this.rdb_chogiaohang.Location = new System.Drawing.Point(1290, 28);
            this.rdb_chogiaohang.Name = "rdb_chogiaohang";
            this.rdb_chogiaohang.Size = new System.Drawing.Size(106, 19);
            this.rdb_chogiaohang.TabIndex = 123;
            this.rdb_chogiaohang.TabStop = true;
            this.rdb_chogiaohang.Text = "Chờ Giao Hàng";
            this.rdb_chogiaohang.UseVisualStyleBackColor = true;
            // 
            // rdb_dahuy
            // 
            this.rdb_dahuy.AutoSize = true;
            this.rdb_dahuy.ForeColor = System.Drawing.Color.Black;
            this.rdb_dahuy.Location = new System.Drawing.Point(1141, 57);
            this.rdb_dahuy.Name = "rdb_dahuy";
            this.rdb_dahuy.Size = new System.Drawing.Size(64, 19);
            this.rdb_dahuy.TabIndex = 124;
            this.rdb_dahuy.TabStop = true;
            this.rdb_dahuy.Text = "Đã Hủy";
            this.rdb_dahuy.UseVisualStyleBackColor = true;
            // 
            // rdb_dacoc
            // 
            this.rdb_dacoc.AutoSize = true;
            this.rdb_dacoc.ForeColor = System.Drawing.Color.Black;
            this.rdb_dacoc.Location = new System.Drawing.Point(987, 57);
            this.rdb_dacoc.Name = "rdb_dacoc";
            this.rdb_dacoc.Size = new System.Drawing.Size(63, 19);
            this.rdb_dacoc.TabIndex = 127;
            this.rdb_dacoc.TabStop = true;
            this.rdb_dacoc.Text = "Đã Cọc";
            this.rdb_dacoc.UseVisualStyleBackColor = true;
            // 
            // rdb_chuatt
            // 
            this.rdb_chuatt.AutoSize = true;
            this.rdb_chuatt.ForeColor = System.Drawing.Color.Black;
            this.rdb_chuatt.Location = new System.Drawing.Point(1141, 28);
            this.rdb_chuatt.Name = "rdb_chuatt";
            this.rdb_chuatt.Size = new System.Drawing.Size(117, 19);
            this.rdb_chuatt.TabIndex = 126;
            this.rdb_chuatt.TabStop = true;
            this.rdb_chuatt.Text = "Chưa Thanh Toán";
            this.rdb_chuatt.UseVisualStyleBackColor = true;
            // 
            // rdb_datt
            // 
            this.rdb_datt.AutoSize = true;
            this.rdb_datt.ForeColor = System.Drawing.Color.Black;
            this.rdb_datt.Location = new System.Drawing.Point(987, 28);
            this.rdb_datt.Name = "rdb_datt";
            this.rdb_datt.Size = new System.Drawing.Size(103, 19);
            this.rdb_datt.TabIndex = 125;
            this.rdb_datt.TabStop = true;
            this.rdb_datt.Text = "Đã Thanh Toán";
            this.rdb_datt.UseVisualStyleBackColor = true;
            // 
            // dtp_ngaynhan
            // 
            this.dtp_ngaynhan.Location = new System.Drawing.Point(462, 298);
            this.dtp_ngaynhan.Name = "dtp_ngaynhan";
            this.dtp_ngaynhan.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngaynhan.TabIndex = 122;
            // 
            // dtp_ngaythanhtoan
            // 
            this.dtp_ngaythanhtoan.Location = new System.Drawing.Point(462, 216);
            this.dtp_ngaythanhtoan.Name = "dtp_ngaythanhtoan";
            this.dtp_ngaythanhtoan.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngaythanhtoan.TabIndex = 121;
            // 
            // dtp_ngayship
            // 
            this.dtp_ngayship.Location = new System.Drawing.Point(462, 261);
            this.dtp_ngayship.Name = "dtp_ngayship";
            this.dtp_ngayship.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngayship.TabIndex = 120;
            // 
            // dtp_ngaytao
            // 
            this.dtp_ngaytao.Location = new System.Drawing.Point(462, 179);
            this.dtp_ngaytao.Name = "dtp_ngaytao";
            this.dtp_ngaytao.Size = new System.Drawing.Size(200, 23);
            this.dtp_ngaytao.TabIndex = 119;
            // 
            // dtgShow_CTHD
            // 
            this.dtgShow_CTHD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtgShow_CTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgShow_CTHD.Location = new System.Drawing.Point(229, 696);
            this.dtgShow_CTHD.Name = "dtgShow_CTHD";
            this.dtgShow_CTHD.RowTemplate.Height = 25;
            this.dtgShow_CTHD.Size = new System.Drawing.Size(1396, 205);
            this.dtgShow_CTHD.TabIndex = 118;
            // 
            // dtg_showHD
            // 
            this.dtg_showHD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtg_showHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_showHD.Location = new System.Drawing.Point(229, 436);
            this.dtg_showHD.Name = "dtg_showHD";
            this.dtg_showHD.RowTemplate.Height = 25;
            this.dtg_showHD.Size = new System.Drawing.Size(1396, 254);
            this.dtg_showHD.TabIndex = 117;
            // 
            // btn_suaHD
            // 
            this.btn_suaHD.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_suaHD.FlatAppearance.BorderSize = 0;
            this.btn_suaHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_suaHD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_suaHD.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_suaHD.Location = new System.Drawing.Point(1318, 298);
            this.btn_suaHD.Margin = new System.Windows.Forms.Padding(2);
            this.btn_suaHD.Name = "btn_suaHD";
            this.btn_suaHD.Size = new System.Drawing.Size(96, 50);
            this.btn_suaHD.TabIndex = 116;
            this.btn_suaHD.Text = "Sửa Hóa Đơn";
            this.btn_suaHD.UseVisualStyleBackColor = false;
            this.btn_suaHD.Click += new System.EventHandler(this.btn_suaHD_Click);
            // 
            // txt_phantramgiamgia
            // 
            this.txt_phantramgiamgia.Location = new System.Drawing.Point(998, 275);
            this.txt_phantramgiamgia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_phantramgiamgia.Name = "txt_phantramgiamgia";
            this.txt_phantramgiamgia.Size = new System.Drawing.Size(205, 23);
            this.txt_phantramgiamgia.TabIndex = 115;
            // 
            // txt_tenship
            // 
            this.txt_tenship.Location = new System.Drawing.Point(998, 135);
            this.txt_tenship.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tenship.Name = "txt_tenship";
            this.txt_tenship.Size = new System.Drawing.Size(205, 23);
            this.txt_tenship.TabIndex = 114;
            // 
            // txt_sotienquydoi
            // 
            this.txt_sotienquydoi.Location = new System.Drawing.Point(998, 185);
            this.txt_sotienquydoi.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sotienquydoi.Name = "txt_sotienquydoi";
            this.txt_sotienquydoi.Size = new System.Drawing.Size(205, 23);
            this.txt_sotienquydoi.TabIndex = 113;
            // 
            // txt_sodiemtieudung
            // 
            this.txt_sodiemtieudung.Location = new System.Drawing.Point(998, 225);
            this.txt_sodiemtieudung.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sodiemtieudung.Name = "txt_sodiemtieudung";
            this.txt_sodiemtieudung.Size = new System.Drawing.Size(205, 23);
            this.txt_sodiemtieudung.TabIndex = 112;
            // 
            // txt_sdtShip
            // 
            this.txt_sdtShip.Location = new System.Drawing.Point(998, 95);
            this.txt_sdtShip.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sdtShip.Name = "txt_sdtShip";
            this.txt_sdtShip.Size = new System.Drawing.Size(205, 23);
            this.txt_sdtShip.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(233, 301);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 110;
            this.label9.Text = "Ngày Nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(233, 259);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 107;
            this.label3.Text = "Ngày Ship";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(233, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 109;
            this.label5.Text = "Ngày Thanh Toán";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(233, 177);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 108;
            this.label6.Text = "Ngày Tạo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(765, 278);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 20);
            this.label16.TabIndex = 106;
            this.label16.Text = "Phần Trăm Giảm Giá";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(765, 44);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 103;
            this.label10.Text = "Tình Trạng";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(765, 138);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 20);
            this.label13.TabIndex = 105;
            this.label13.Text = "Tên Ship";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(765, 228);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 20);
            this.label15.TabIndex = 101;
            this.label15.Text = "Số Điểm Tiêu Dùng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(765, 184);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 20);
            this.label14.TabIndex = 100;
            this.label14.Text = "Số Tiền Quy Đổi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(229, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "Khách Hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(765, 94);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 99;
            this.label11.Text = "Số ĐT Ship";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(229, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 102;
            this.label2.Text = "Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(229, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 98;
            this.label1.Text = "Mã Hóa Đơn";
            // 
            // Frm_HoaDon
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1854, 929);
            this.Controls.Add(this.pictureBox_PDF);
            this.Controls.Add(this.pictureBox1);
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
            this.Controls.Add(this.dtgShow_CTHD);
            this.Controls.Add(this.dtg_showHD);
            this.Controls.Add(this.btn_suaHD);
            this.Controls.Add(this.txt_phantramgiamgia);
            this.Controls.Add(this.txt_tenship);
            this.Controls.Add(this.txt_sotienquydoi);
            this.Controls.Add(this.txt_sodiemtieudung);
            this.Controls.Add(this.txt_sdtShip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_HoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgShow_CTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_showHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
    }
}
