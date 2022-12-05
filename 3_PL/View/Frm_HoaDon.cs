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
        //string connect = @"Data Source=SADBOY\SQLEXPRESS;Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=ph27584;Password=123456";
        public Frm_HoaDon()
        {


            InitializeComponent();
            _HDService = new HoaDonService();
            _NVService = new NhanVienServices();
            _KHService = new KhachHangServices();

            LoadDTG();
        }
        //void nhanviendtg()
        //{
        //    using (SqlConnection sqlCon = new SqlConnection(connect))
        //    {
        //        sqlCon.Open();
        //        SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM HoaDon", sqlCon);
        //        DataTable dtb1 = new DataTable();
        //        sqlDa.Fill(dtb1);
        //        cbb_nhanvien.ValueMember = "IdNV";
        //        cbb_nhanvien.DisplayMember = "NhanVien";
        //        DataRow topItem = dtb1.NewRow();
        //        topItem[0] = 0;
        //        topItem[1] = "-Select-";
        //        dtb1.Rows.InsertAt(topItem, 0);
        //        cbb_nhanvien.DataSource = dtb1;
        //    }
        //}
        private void Frm_Receipt_Load(object sender, EventArgs e)
        {

        }

        int i = 1;

        void LoadDTG()
        {
            dtg_showHD.Rows.Clear();
            dtg_showHD.ColumnCount = 16;
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
            dtg_showHD.Columns[9].Name = "Thue";
            dtg_showHD.Columns[10].Name = "SDT Ship";
            dtg_showHD.Columns[11].Name = "Tên Người Ship";
            dtg_showHD.Columns[12].Name = "Tên Ship";
            dtg_showHD.Columns[13].Name = "Số Tiền Quy Đổi";
            dtg_showHD.Columns[14].Name = "Số Điểm Tiêu Dùng";
            dtg_showHD.Columns[15].Name = "Phần Trăm Giảm Giá";
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
                    x.TenKhachHang,
                    x.TenShip,
                    x.SoTienQuyDoi,
                    x.SoDiemSuDung,
                    x.PhanTramGiamGia);
            }


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


        private void txt_sotienquydoi_TextChanged(object sender, EventArgs e)
        {

        }
        public static Guid Currenid;
        public static Guid tox;
        private void dtg_showHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Currenid = Guid.Parse(dtg_showHD.CurrentRow.Cells[0].Value.ToString());
            var hd = _HDService.GetAllHoaDonDB().FirstOrDefault(c => c.IdHoaDon == Currenid);
            //cbb_MaHoaDon.Text = hd.IdHoaDon != null ? _HDService.GetAllHoaDonDB().FirstOrDefault(c => Currenid == hd.IdHoaDon).Ma.ToString() : null;
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
            txt_tenguoiship.Text = hd.TenKhachHang.ToString();
            txt_tenship.Text = hd.TenShip.ToString();
            txt_sotienquydoi.Text = hd.SoTienQuyDoi.ToString();
            txt_sodiemtieudung.Text = hd.SoDiemSuDung.ToString();
            txt_phantramgiamgia.Text = hd.PhanTramGiamGia.ToString();



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
            suaHoaDon.TenKhachHang = txt_tenguoiship.Text;
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

        private void btn_in_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // excel

            


            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn Xuất Ra File PDF Hay Không", "Thông Báo", MessageBoxButtons.YesNo);

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
    }
}
