using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using _2_BUS.Services;
using _2_BUS.IServices;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using _2_BUS.Service;
using System.Runtime.CompilerServices;
using _1_DAL.Models;
using System.Globalization;
using ZXing;
using System.IO;
using static System.Resources.ResXFileRef;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;


namespace _3_PL.View
{
    public partial class FormBanHang : Form
    {
        IKhachHangServices _KhachHangServices;
        IHoaDonService _HoaDonService;
        IHoaDonChiTietService _HoaDonChiTietService;
        ISanPhamService _SanPhamService;
        IQlyHangHoaServices _HangHoaChiTietServices;
        INhanVienServices _NhanVienServices;
        List<SanPhamView> _ListProduct;
        IAnhService _AnhService;
        List<Guid> _IdSpInReceipt;
        List<GioHangViewModel> _ListGioHang;
        List<SanPhamTrongHoaDonViewModels> _ListReceiptProduct;
        List<SanPhamTrongHoaDonViewModels> _ListReceiptProduct2;
        IBangQuyDoiDiemServices _QuyDoiDiemService;
        ILichSuDiemService _LichSuDiemService;
        IViDiemService _ViDiemService;

        VideoCaptureDevice videoCaptureDevice;
        // camera dung de ghi hinh
        FilterInfoCollection filterInfoCollection; // check xem co bao nhieu cai camera ket noi voi may tinh
        public FormBanHang()
        {
            InitializeComponent();
            _QuyDoiDiemService = new BangQuyDoiDiemServices();
            _ViDiemService = new ViDiemService();
            _LichSuDiemService = new LichSuDiemService();
            _KhachHangServices = new KhachHangServices();
            _AnhService = new AnhService();
            _HoaDonChiTietService = new HoaDonChiTietService();
            _NhanVienServices = new NhanVienServices();
            _HoaDonService = new HoaDonService();
            _SanPhamService = new SanPhamService();
            _HangHoaChiTietServices = new QlyHangHoaServices();
            _ListGioHang = new List<GioHangViewModel>();
            _SanPhamService = new SanPhamService();
            _ListProduct = new List<SanPhamView>();
            _IdSpInReceipt = new List<Guid>();
            _ListReceiptProduct = new List<SanPhamTrongHoaDonViewModels>();
            _ListReceiptProduct2 = new List<SanPhamTrongHoaDonViewModels>();
            loadProduct();
            loadGioHang();
            LoadCbxRank();
            load();
            //     loadDonDatHang();
            loadDonDatCoc();
            loadDonDatHang();
            loadhoadonduyet();
            radioButton6.Checked = true;
            rbt_chuathanhtoan.Checked = true;
            btn_DatHang.Enabled = false;
            btn_ThanhToan.Enabled = false;
        }

        void LoadCbxRank()
        {
            cbxRank.Items.Add("Bạc");
            cbxRank.Items.Add("Vàng");
            cbxRank.Items.Add("Kim cương");
            cbxRank.SelectedIndex = 0;
        }
        void load()
        {
            var nv = _NhanVienServices.GetAll().FirstOrDefault(p => p.Id == FrmDangNhap._IdStaff);
            string hoTenNV = nv.Ho + " " + nv.TenDem + " " + nv.Ten;
            button4.Text = hoTenNV;
        }

        void image()
        {

            try
            {
                if (InvokeRequired) // Line #1
                {
                    this.Invoke(new MethodInvoker(image));
                    return;
                }
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.HeaderText = "Ảnh";
                img.Name = "img_sp";
                img.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgv_product.Columns.Add(img);

                for (int i = 0; i < dgv_product.RowCount - 1; i++)
                {
                    Image img1 = Image.FromFile(Convert.ToString(dgv_product.Rows[i].Cells["IMG"].Value));

                    dgv_product.Rows[i].Cells["img_sp"].Value = img1;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        private void loadProduct()
        {

            dgv_product.Rows.Clear();
            dgv_product.ColumnCount = 8;
            dgv_product.Columns[0].Name = "IdSp";
            dgv_product.Columns[1].Name = "STT";
            dgv_product.Columns[2].Name = "Mã SP";
            dgv_product.Columns[3].Name = "Tên SP";
            dgv_product.Columns[4].Name = "Gía Bán";
            dgv_product.Columns[5].Name = "IdSpDetail";
            dgv_product.Columns[6].Name = "Số Lượng Ton";
            dgv_product.Columns[7].Name = "IMG";
            dgv_product.Columns[5].Visible = false;
            dgv_product.Columns[7].Visible = false;
            dgv_product.Columns[0].Visible = false;
            int n = 1;
            _ListProduct = _SanPhamService.GetSanPham();
            if (tb_search.Text != "")
                _ListProduct = _SanPhamService.GetSanPham().Where(p => p.Ten.Contains(tb_search.Text)).ToList();

            foreach (var item in _ListProduct)
            {
                AnhViewModels anh = _AnhService.GetAnh().Where(c => c.ID == item.IdAnh).FirstOrDefault();
                dgv_product.Rows.Add(item.IdSp, n++, item.Ma, item.Ten, item.GiaBan,
              item.IdHangHoaChiTiet, item.SoLuongTon, item.IdAnh != null ? anh.DuongDan : null
              );
            }
            image();

            dgv_product.AllowUserToAddRows = false;
            dgv_product.Columns[1].Width = 50;
            dgv_product.Columns[6].Width = 60;
            dgv_product.Columns[7].Width = 70;
            dgv_product.Columns[2].Width = 70;
            dgv_product.Columns[3].Width = 70;
            dgv_product.Columns[4].Width = 70;
            dgv_product.Columns[5].Width = 70;

        }
        private void loadGioHang()
        {
            dgv_GioHang1.Rows.Clear();
            dgv_GioHang1.ColumnCount = 7;
            dgv_GioHang1.Columns[0].Name = "STT";
            dgv_GioHang1.Columns[1].Name = "Mã SP";
            dgv_GioHang1.Columns[2].Name = "Tên SP";
            dgv_GioHang1.Columns[3].Name = "Số Lượng";
            dgv_GioHang1.Columns[4].Name = "Đơn Gía";
            dgv_GioHang1.Columns[5].Name = "Thanh Tiền";
            dgv_GioHang1.Columns[6].Name = "IDSPCT";
            dgv_GioHang1.Columns[6].Visible = false;
            int n = 1;
            foreach (var item in _ListGioHang)
            {
                dgv_GioHang1.Rows.Add(n++, item.MaSp, item.TenSp,
                item.SoLuong, item.DonGia, item.ThanhTien, item.IdCTSP
                );
            }
            dgv_GioHang1.AllowUserToAddRows = false;

        }

        void refreshcam()
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(refreshcam));
                    return;
                }
                if (pic_cam.Image != null)
                {
                    pic_cam.Image = null;
                    pic_cam.ImageLocation = null;
                    pic_cam.Update();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        private void btn_FormdatHang_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            pn_dathang.Visible = true;

        }
        string MaHd = "";
        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
        private Guid addHoaDon()
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "f", "e", "q",
                "w", "r", "t", "y", "u", "i", "o", "p", "h","j","k","l","c","v","b","n","m","o","p","z","x" };


            ThemHoaDonModels ThemHoaDon = new ThemHoaDonModels();
            ThemHoaDon.Ma = "HD" + GenerateRandomOTP(4, saAllowedCharacters);
            ThemHoaDon.NgayTao = DateTime.Today;
            maHd = ThemHoaDon.Ma;
            ThemHoaDon.TinhTrang = 2;

            ThemHoaDon.IdNv = FrmDangNhap._IdStaff;
            return _HoaDonService.GetIdHoaDon(ThemHoaDon);
        }
        private void FormBanHang_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbo_webcam.Items.Add(device.Name);
            cbo_webcam.SelectedIndex = 0;
        }
        int checkHD = 0;
        private void btnsender_Click(object sender, EventArgs e)
        {

            button2.Enabled = false;
            if (_ListReceiptProduct2.Count() != 0)
            {
                btn_ThanhToan.Enabled = true;
                btn_DatHang.Enabled = true;
            }
            else
            {
                btn_ThanhToan.Enabled = false;
                btn_DatHang.Enabled = false;
            }
            dgv_GioHang1.Rows.Clear();
            Guid acbc = ((sender as Button).Tag as SuaHoaDonModels).IdHoaDon;
            {
                IdHoaDon = acbc;
                dgv_GioHang1.ColumnCount = 8;
                dgv_GioHang1.Columns[0].Name = "STT";
                dgv_GioHang1.Columns[1].Name = "Mã SP";
                dgv_GioHang1.Columns[2].Name = "Tên SP";
                dgv_GioHang1.Columns[3].Name = "Số Lượng";
                dgv_GioHang1.Columns[4].Name = "Đơn Gía";
                dgv_GioHang1.Columns[5].Name = "Thanh Tiền";
                dgv_GioHang1.Columns[6].Name = "IDSPCT";
                dgv_GioHang1.Columns[7].Name = "IDHD";
                dgv_GioHang1.Columns[6].Visible = false;
                dgv_GioHang1.Columns[7].Visible = false;
                int n = 1;
                {
                    _ListReceiptProduct = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == acbc).ToList();

                    foreach (var item in _ListReceiptProduct)
                    {
                        dgv_GioHang1.Rows.Add(n++, item.MaSP, item.TenSp, item.SoLuong, item.DonGia, item.ThanhTien, item.IdSpCt, item.IdHoaDon);
                    }
                    if (_ListReceiptProduct2.Count() == 0)
                        _ListReceiptProduct2.AddRange(_ListReceiptProduct);
                    else if (_ListReceiptProduct2.Count() > 0)
                    {
                        _ListReceiptProduct2.RemoveRange(0, _ListReceiptProduct2.Count());
                    }
                    decimal? tien = 0;
                    var price = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == IdHoaDon);
                    foreach (var item in price)
                    {
                        tien += item.ThanhTien;
                    }
                    if (tien != 0)
                    {
                        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                        txt_tongTienHoaDon.Text = Convert.ToInt32(tien).ToString("#,###", cul.NumberFormat);
                        txt_dathangtongtien.Text = Convert.ToInt32(tien).ToString("#,###", cul.NumberFormat);
                        status = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon).TinhTrang;
                    }
                    if (status == 2)
                    {
                        radioButton6.Checked = true;
                        rbt_chuathanhtoan.Checked = true;

                    }
                    else if (status == 3)
                    {
                        rbt_giaohang.Checked = true;

                    }
                    else if (status == 7)
                    {
                        rbt_dacoc.Checked = true;

                    }
                    else if (status == 6)
                    {
                        rbt_dahuy.Checked = true;
                        radioButton8.Checked = true;
                    }
                }
            }

        }
        private void btnsender_Click1(object sender, EventArgs e)
        {
            checkHD++;
            button2.Enabled = false;
            if (_ListReceiptProduct2.Count() != 0)
            {
                btn_ThanhToan.Enabled = true;
                btn_DatHang.Enabled = true;

            }
            else
            {
                btn_ThanhToan.Enabled = false;
                btn_DatHang.Enabled = false;
            }

            dgv_GioHang1.Rows.Clear();
            Guid acbc = ((sender as Button).Tag as SuaHoaDonModels).IdHoaDon;
            {
                IdHoaDon = acbc;
                dgv_GioHang1.ColumnCount = 8;
                dgv_GioHang1.Columns[0].Name = "STT";
                dgv_GioHang1.Columns[1].Name = "Mã SP";
                dgv_GioHang1.Columns[2].Name = "Tên SP";
                dgv_GioHang1.Columns[3].Name = "Số Lượng";
                dgv_GioHang1.Columns[4].Name = "Đơn Gía";
                dgv_GioHang1.Columns[5].Name = "Thanh Tiền";
                dgv_GioHang1.Columns[6].Name = "IDSPCT";
                dgv_GioHang1.Columns[7].Name = "IDHD";
                dgv_GioHang1.Columns[6].Visible = false;
                dgv_GioHang1.Columns[7].Visible = false;
                int n = 1;
                {
                    _ListReceiptProduct = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == acbc).ToList();

                    foreach (var item in _ListReceiptProduct)
                    {
                        dgv_GioHang1.Rows.Add(n++, item.MaSP, item.TenSp, item.SoLuong, item.DonGia, item.ThanhTien, item.IdSpCt, item.IdHoaDon);
                    }
                    if (_ListReceiptProduct2.Count() == 0)
                        _ListReceiptProduct2.AddRange(_ListReceiptProduct);
                    else
                        _ListReceiptProduct2.RemoveRange(0, _ListReceiptProduct2.Count());
                    decimal? tien = 0;
                    var price = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == IdHoaDon);
                    foreach (var item in price)
                    {
                        tien += item.ThanhTien;
                    }
                    if (tien != 0)
                    {
                        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                        txt_tongTienHoaDon.Text = Convert.ToInt32(tien).ToString("#,###", cul.NumberFormat);
                        txt_dathangtongtien.Text = Convert.ToInt32(tien).ToString("#,###", cul.NumberFormat);
                        status = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon).TinhTrang;
                    }


                    if (status == 2)
                    {
                        radioButton6.Checked = true;
                        rbt_chuathanhtoan.Checked = true;

                    }
                    else if (status == 3)
                    {
                        rbt_giaohang.Checked = true;

                    }
                    else if (status == 7)
                    {
                        rbt_dacoc.Checked = true;

                    }
                    else if (status == 6)
                    {
                        rbt_dahuy.Checked = true;
                        radioButton8.Checked = true;
                    }
                }
            }

        }
        void loadReceipt()
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(loadReceipt));
                    return;
                }
                dgv_GioHang1.Rows.Clear();
                dgv_GioHang1.ColumnCount = 8;
                dgv_GioHang1.Columns[0].Name = "STT";
                dgv_GioHang1.Columns[1].Name = "Mã SP";
                dgv_GioHang1.Columns[2].Name = "Tên SP";
                dgv_GioHang1.Columns[3].Name = "Số Lượng";
                dgv_GioHang1.Columns[4].Name = "Đơn Gía";
                dgv_GioHang1.Columns[5].Name = "Thanh Tiền";
                dgv_GioHang1.Columns[6].Name = "IDSPCT";
                dgv_GioHang1.Columns[7].Name = "IDHD";
                dgv_GioHang1.Columns[7].Visible = false;
                dgv_GioHang1.Columns[6].Visible = false;
                int n = 1;
                foreach (var item in _ListReceiptProduct2)
                {
                    dgv_GioHang1.Rows.Add(n++, item.MaSP, item.TenSp, item.SoLuong, item.DonGia, item.ThanhTien, item.IdSpCt, item.IdHoaDon);
                }
            }

            catch (Exception)
            {

                throw;
            }

        }
        public Button createButton()
        {
            Button btn = new Button();
            return btn;
        }

        public void loadhoadonduyet()
        {
            try
            {
                flhoadon.Controls.Clear();

                foreach (var x in _HoaDonService.GetAllHoaDonDB().Where(p => p.TinhTrang == 2))
                {
                    Button button = createButton();
                    button.Location = new Point(62, 62);
                    button.Size = new Size(63, 90);
                    button.Visible = true;
                    button.Click += btnsender_Click;
                    //   button.DoubleClick = loadGioHang();
                    button.ForeColor = Color.Aquamarine;
                    button.Text = x.Ma + Environment.NewLine + (x.TinhTrang == 2
                        ? "Chưa Thanh Toán"
                        : (x.TinhTrang == 3 ? "Đang Chờ Giao Hàng" : (x.TinhTrang == 7 ? "Đã Cọc" : "Đã Hủy")));
                    button.Tag = x;

                    switch (x.TinhTrang)
                    {
                        case 2:
                            {
                                button.BackColor = Color.Orange;
                                break;
                            }
                        case 3:
                            button.BackColor = Color.BlueViolet;
                            break;
                        case 6:
                            button.BackColor = Color.Red;
                            break;
                        case 7:
                            button.BackColor = Color.CadetBlue;
                            break;
                    }
                    flhoadon.Controls.Add(button);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        public void loadDonDatHang()
        {
            try
            {
                flhoadon.Controls.Clear();

                foreach (var x in _HoaDonService.GetAllHoaDonDB().Where(p => p.TinhTrang == 3))
                {
                    Button button = createButton();
                    button.Location = new Point(62, 62);
                    button.Size = new Size(63, 90);
                    button.Visible = true;
                    button.Click += btnsender_Click1;

                    //   button.DoubleClick = loadGioHang();
                    button.ForeColor = Color.Aquamarine;
                    button.Text = x.Ma + Environment.NewLine + (x.TinhTrang == 2
                       ? "Chưa Thanh Toán"
                       : (x.TinhTrang == 3 ? "Chờ Giao Hàng(đặt hàng)" : (x.TinhTrang == 7 ? "Đã Cọc" : "Đã Hủy")));
                    button.Tag = x;

                    switch (x.TinhTrang)
                    {
                        case 2:
                            {
                                button.BackColor = Color.Orange;
                                break;
                            }
                        case 3:
                            button.BackColor = Color.BlueViolet;
                            break;
                        case 6:
                            button.BackColor = Color.Red;
                            break;
                        case 7:
                            button.BackColor = Color.CadetBlue;
                            break;
                    }
                    flhd3.Controls.Add(button);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        public void loadDonDatCoc()
        {
            try
            {
                flhoadon.Controls.Clear();

                foreach (var x in _HoaDonService.GetAllHoaDonDB().Where(p => p.TinhTrang == 7))
                {
                    Button button = createButton();
                    button.Location = new Point(62, 62);
                    button.Size = new Size(63, 90);
                    button.Visible = true;
                    button.Click += btnsender_Click1;

                    //   button.DoubleClick = loadGioHang();
                    button.ForeColor = Color.Aquamarine;
                    button.Text = x.Ma + Environment.NewLine + (x.TinhTrang == 2
                       ? "Chưa Thanh Toán"
                       : (x.TinhTrang == 3 ? "Chờ Giao Hàng(đặt hàng)" : (x.TinhTrang == 7 ? "Đã Cọc" : "Đã Hủy")));
                    button.Tag = x;

                    switch (x.TinhTrang)
                    {
                        case 2:
                            {
                                button.BackColor = Color.Orange;
                                break;
                            }
                        case 3:
                            button.BackColor = Color.BlueViolet;
                            break;
                        case 6:
                            button.BackColor = Color.Red;
                            break;
                        case 7:
                            button.BackColor = Color.CadetBlue;
                            break;
                    }
                    flhd3.Controls.Add(button);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Mở Camera Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();
                    timer1.Start();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            pic_cam.Image = bitmap;

        }
        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Tắt Camera chứ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                videoCaptureDevice.SignalToStop();
                refreshcam();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Tạo Hóa Đơn Chứ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_ListGioHang.Any() && _ListGioHang.Count() != 0 && _ListGioHang.Count() != 0)
                {
                    HoaDonChiTietThemViewModel HoaDonCT = new HoaDonChiTietThemViewModel();
                    HoaDonCT.IdHoaDon = addHoaDon();
                    foreach (var item in _ListGioHang)
                    {
                        HoaDonCT.IdChiTietSp = item.IdCTSP;
                        HoaDonCT.SoLuong = item.SoLuong;
                        HoaDonCT.ThanhTien = item.DonGia * item.SoLuong;
                        HoaDonCT.TinhTrang = 2;
                        _HoaDonChiTietService.ThemHoaDonChiTiet(HoaDonCT);
                        var sp = _HangHoaChiTietServices.GetAllSoLuong().FirstOrDefault(x => x.IdSpCt == item.IdCTSP);
                        sp.SoLuong -= item.SoLuong;
                        _HangHoaChiTietServices.updateSoLuong(sp);
                    }
                    _ListGioHang.RemoveRange(0, _ListGioHang.Count());
                    MessageBox.Show("Tạo Hóa Đơn Thành Công");
                    loadGioHang();
                    loadhoadonduyet();

                }
                //else if(_ListReceiptProduct2.Count() == _ListReceiptProduct.Count())
                //{
                //    foreach (var item in _ListReceiptProduct2)
                //    {
                //        HoaDonChiTietViewModel hd = _HoaDonChiTietService.GetAllHoaDonDB().FirstOrDefault(p => p.IdChiTietSp == item.IdSpCt);
                //        hd.SoLuong = int.Parse(textBox2.Text);                  
                //    }
                //    HangHoaChiTietUpdateThanhToan sp = _HangHoaChiTietServices.GetAllSoLuong().FirstOrDefault(p => p.IdSpCt == IdReceiptInCart);
                //    sp.SoLuong = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString());
                //    _HangHoaChiTietServices.updateSoLuong(sp);
                //}
                else if (_ListReceiptProduct2.Any() || _ListReceiptProduct2.Count() != 0)
                {
                    _HoaDonChiTietService.XoaHoaDonChiTiet(IdHoaDon);
                    HoaDonChiTietThemViewModel HoaDonCT2 = new HoaDonChiTietThemViewModel();
                    foreach (var item in _ListReceiptProduct2)
                    {
                        HoaDonCT2.IdHoaDon = IdHoaDon;
                        HoaDonCT2.IdChiTietSp = item.IdSpCt;
                        HoaDonCT2.SoLuong = item.SoLuong;
                        //MessageBox.Show(item.SoLuong.ToString());
                        HoaDonCT2.ThanhTien = item.DonGia * item.SoLuong;
                        HoaDonCT2.TinhTrang = 2;
                        _HoaDonChiTietService.ThemHoaDonChiTiet(HoaDonCT2);
                        HangHoaChiTietUpdateThanhToan sp = _HangHoaChiTietServices.GetAllSoLuong().FirstOrDefault(p => p.IdSpCt == item.IdSpCt);
                        sp.SoLuong -= item.SoLuong;
                        _HangHoaChiTietServices.updateSoLuong(sp);
                    }
                    _ListReceiptProduct2.RemoveRange(0, _ListReceiptProduct2.Count());
                    loadReceipt();
                    MessageBox.Show("Update Hóa Đơn Thành Công");
                    //  loadReceipt();
                    flhoadon.Controls.Remove(createButton());
                    loadDonDatHang();
                    loadhoadonduyet();

                }
                else
                {
                    MessageBox.Show("Loi");
                }
                //  loadDonDatHang();
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn Đồng Ý Thanh Toán Hóa Đơn Chứ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (checkHD != 0)
                {
                    MessageBox.Show("Bạn Cần vào bên đặt hàng để thực hiện nhé");
                }
                else
                {
                    SuaHoaDonModels suaHoaDonModels = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);
                    HoaDonChiTietViewModel hoaDonCt = _HoaDonChiTietService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);
                    if (radioButton6.Checked)
                    {
                        suaHoaDonModels.TinhTrang = 2;
                        hoaDonCt.TrangThai = 2;

                    }
                    else if (radioButton1.Checked)
                    {
                        suaHoaDonModels.TinhTrang = 3;
                        suaHoaDonModels.TinhTrang = 3;
                    }
                    else if (radioButton8.Checked)
                    {
                        suaHoaDonModels.TinhTrang = 6;
                        suaHoaDonModels.TinhTrang = 6;
                    }
                    else if (radioButton2.Checked)
                    {
                        suaHoaDonModels.TinhTrang = 1;
                        hoaDonCt.TrangThai = 1;

                        flhoadon.Controls.Remove(createButton());
                    }
                    if (textBox11.Text == "")
                    {
                        suaHoaDonModels.SoDiemSuDung = 0;
                        suaHoaDonModels.SoTienQuyDoi = 0;

                    }
                    else
                    {
                        suaHoaDonModels.SoDiemSuDung = int.Parse(textBox11.Text);
                        suaHoaDonModels.SoTienQuyDoi = decimal.Parse(textBox7.Text);
                    }
                    suaHoaDonModels.NgayThanhToan = DateTime.Now;
                    if (_HoaDonChiTietService.SuaHoaDonChiTiet(hoaDonCt))
                    {
                        MessageBox.Show(_HoaDonService.SuaHoaDon(suaHoaDonModels));
                        LichSuDiemViewModels lichSuDiemViewModels = new LichSuDiemViewModels();
                        if (_KhachHangServices.GetAllKhachHangDB().SingleOrDefault(p => p.Sdt.Contains(textBox10.Text)).IdVi != null)
                        {
                            lichSuDiemViewModels.IdViDiem = _KhachHangServices.GetAllKhachHangDB().SingleOrDefault(p => p.Sdt.Contains(textBox10.Text)).IdVi;

                            if (textBox11.Text == "")
                            {
                                lichSuDiemViewModels.SoDiemTieuDung = 0;
                            }
                            else
                            {
                                lichSuDiemViewModels.SoDiemTieuDung = int.Parse(textBox11.Text);
                                lichSuDiemViewModels.NgaySuDung = DateTime.Now;
                                lichSuDiemViewModels.TrangThai = 1;
                                lichSuDiemViewModels.IdHoaDon = IdHoaDon;
                                //MessageBox.Show(lichSuDiemViewModels.IdHoaDon.ToString());
                                _LichSuDiemService.add(lichSuDiemViewModels);
                                ViDiemViewModel viDiem = new ViDiemViewModel();                             
                                viDiem.TongDiem = int.Parse(textBox5.Text) - int.Parse(textBox11.Text);
                                viDiem.TrangThai = 1;
                                var IdKh = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Sdt.Contains(textBox10.Text)).Idkh;
                               // MessageBox.Show(IdKh.ToString());
                                viDiem.IdKhachHang = IdKh;
                                viDiem.Id = _ViDiemService.GetViDiem().FirstOrDefault(p => p.IdKhachHang == IdKh).Id;
                                _ViDiemService.update(viDiem);
                            }
                        }
                    }

                    loadGioHang();
                    loadhoadonduyet();
                    if (radioButton1.Checked)
                        inHoaDon();
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadProduct();
        }
        int n = 0;
        private void btn_up_Click(object sender, EventArgs e)
        {
            n++;
            tb_count.Text = n.ToString();
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            n--;
            tb_count.Text = n.ToString();
            if (n <= 0)
            {
                n = 0;
                tb_count.Text = n.ToString();
            }
        }
        private void checkNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void tb_tienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label17.Text = DateTime.Now.ToLongDateString();

            if (pic_cam.Image != null)
            {
                Bitmap img = (Bitmap)pic_cam.Image;
                BarcodeReader Reader = new BarcodeReader();
                Result result = Reader.Decode(img);
                try
                {

                    string decoded = result.ToString().Trim();
                    string[] maQR = decoded.Split(new char[] { '\n' });

                    if (_SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == Guid.Parse(maQR[0])) != null)
                    {
                        string content = Interaction.InputBox("Mời Bạn Nhập Số Lượng Muốn Thêm Vào Giỏ Hàng ", _SanPhamService.GetSanPham().FirstOrDefault(p => p.Ma.Contains(maQR[2])).Ma, "", 500, 300);
                        if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (Regex.IsMatch(content, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }

                        if (Regex.IsMatch(content, @"^[a-zA-Z0-9 ]*$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa ký tự đặc biệt", "ERR");
                            return;
                        }
                        if (content == "")
                        {
                            MessageBox.Show("Bạn Nhập Số Lượng");
                            return;
                        }
                        if (Regex.IsMatch(content, @"^\d+$") == false)
                        {

                            MessageBox.Show("Số Lượng không được chứa chữ cái", "ERR");
                            return;
                        }
                        if (content.Length > 6)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) < 0)
                        {
                            MessageBox.Show("Số Lượng Không Cho Phép Âm", "ERR");
                            return;
                        }
                        if (Convert.ToInt32(content) > Convert.ToInt32(_SanPhamService.GetSanPham().Where(c => c.Ma == maQR[2]).Select(c => c.SoLuongTon).FirstOrDefault()))
                        {
                            MessageBox.Show("Số Lượng Không Đủ", "ERR");
                            return;
                        }
                        else
                        {
                            var soLuong = int.Parse(content);
                            var donGia = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == Guid.Parse(maQR[0])).GiaBan;

                            dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) - int.Parse(content);
                            var sp = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == Guid.Parse(maQR[0]));
                            var MaSp = sp.Ma;
                            var TenSp = sp.Ten;

                            GioHangViewModel gioHang = new GioHangViewModel();
                            gioHang.SoLuong = soLuong;
                            gioHang.DonGia = donGia;
                            gioHang.MaSp = MaSp;
                            gioHang.IdCTSP = Guid.Parse(maQR[0]);
                            gioHang.TenSp = TenSp;
                            gioHang.ThanhTien = donGia * soLuong;

                            SanPhamTrongHoaDonViewModels SpInHD = new SanPhamTrongHoaDonViewModels();
                            SpInHD.SoLuong = soLuong;
                            SpInHD.DonGia = donGia;
                            SpInHD.MaSP = MaSp;
                            SpInHD.IdSpCt = Guid.Parse(maQR[0]);
                            SpInHD.TenSp = TenSp;
                            SpInHD.ThanhTien = donGia * soLuong;
                            SpInHD.IdHoaDon = IdHoaDon;

                            if (_ListReceiptProduct2.Count() != 0)
                            {
                                if (_ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == Guid.Parse(maQR[0])) != null)
                                {
                                    _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == Guid.Parse(maQR[0])).SoLuong = _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == Guid.Parse(maQR[0])).SoLuong + int.Parse(content);
                                }
                                else
                                {
                                    _ListReceiptProduct2.Add(SpInHD);
                                    MessageBox.Show("Thêm Thành Công123");

                                }

                            }

                            else
                            {
                                if (_ListGioHang.Count() == 0 && _ListReceiptProduct2.Count() == 0)
                                {
                                    _ListGioHang.Add(gioHang);
                                }
                                if (_ListGioHang.FirstOrDefault(p => p.IdCTSP == Guid.Parse(maQR[0])) != null)
                                {
                                    _ListGioHang.FirstOrDefault(p => p.IdCTSP == Guid.Parse(maQR[0])).SoLuong = _ListGioHang.FirstOrDefault(p => p.IdCTSP == Guid.Parse(maQR[0])).SoLuong + int.Parse(content);
                                }
                                else
                                {
                                    _ListGioHang.Add(gioHang);
                                    MessageBox.Show("Thêm Thành Công");
                                }
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Hông Có Sp Này ");
                    }
                    timer1.Stop();
                    loadGioHang();
                    loadReceipt();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "");
                }

            }
        }

        private void tb_tienThua_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_tienKhachDua_TextChanged(object sender, EventArgs e)
        {
            decimal khachdua;
            decimal khachtra;

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string fkhachtra = Convert.ToString(tb_TienKhachCanTra.Text);
            string tkhachtra = fkhachtra.Replace(".", "");

            string fkhachdua = Convert.ToString(tb_tienKhachDua.Text);
            string tkhachdua = fkhachdua.Replace(".", "");
            double ftienthua = Convert.ToDouble(Convert.ToDouble(tkhachdua) - Convert.ToDouble(tkhachtra));

            tb_tienThua.Text = Convert.ToInt32(ftienthua).ToString("#,###", cul.NumberFormat);
            if (ftienthua < 0)
            {
                btn_ThanhToan.Enabled = false;
            }
            else
            {
                btn_ThanhToan.Enabled = true;
            }
        }

        Guid IDSpCt;
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDSpCt = Guid.Parse(dgv_product.CurrentRow.Cells[5].Value.ToString());
        }

        private void btn_FormHoaDon_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;

        }
        Guid IdHoaDon; int? status; string maHd = "";
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Thêm Sp Này Vào Gio Hàng Chứ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (int.Parse(tb_count.Text) == 0)
                {
                    MessageBox.Show("Vui Long Nhap So Luong");
                }
                else
                {
                    var soLuong = int.Parse(tb_count.Text);
                    var donGia = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt).GiaBan;
                    dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) - int.Parse(tb_count.Text);
                    var sp = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt);
                    var MaSp = sp.Ma;
                    var TenSp = sp.Ten;
                    // doi tuong gio hang
                    GioHangViewModel gioHang = new GioHangViewModel();
                    gioHang.SoLuong = soLuong;
                    gioHang.DonGia = donGia;
                    gioHang.MaSp = MaSp;
                    gioHang.IdCTSP = IDSpCt;
                    gioHang.TenSp = TenSp;
                    gioHang.ThanhTien = donGia * soLuong;

                    // doi tuong sp trong hd
                    SanPhamTrongHoaDonViewModels SpInHD = new SanPhamTrongHoaDonViewModels();
                    SpInHD.SoLuong = soLuong;
                    SpInHD.DonGia = donGia;
                    SpInHD.MaSP = MaSp;
                    SpInHD.IdSpCt = IDSpCt;
                    SpInHD.TenSp = TenSp;
                    SpInHD.ThanhTien = donGia * soLuong;
                    SpInHD.IdHoaDon = IdHoaDon;
                    if (_ListReceiptProduct2.Count() != 0)
                    {

                        if (_ListReceiptProduct2.FirstOrDefault(p => p.IdHoaDon == IdHoaDon) != null || _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IDSpCt) != null)
                        {
                            _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IDSpCt).SoLuong = _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IDSpCt).SoLuong + int.Parse(tb_count.Text);
                            MessageBox.Show("Thêm Vào Giỏ Hàng Thành Công");
                            loadReceipt();

                        }
                        else
                        {
                            _ListReceiptProduct2.Add(SpInHD);
                            MessageBox.Show("Thêm Vào Giỏ Hàng Thành Công");
                            tb_count.Text = 0.ToString();
                            loadReceipt();

                        }

                    }
                    else
                    {

                        if (_ListGioHang.Count() == 0)
                        {
                            _ListGioHang.Add(gioHang);
                            MessageBox.Show("Thêm Vào Hóa Đơn Thành Công");
                            tb_count.Text = 0.ToString();
                            loadGioHang();

                        }
                        else if (_ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt) != null)
                        {
                            _ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt).SoLuong = _ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt).SoLuong + int.Parse(tb_count.Text);
                            MessageBox.Show("Thêm Vào Hóa Đơn Thành Công");
                            tb_count.Text = 0.ToString();
                            loadGioHang();

                        }
                        else
                        {
                            _ListGioHang.Add(gioHang);
                            MessageBox.Show("Thêm Vào Hóa Đơn Thành Công");
                            tb_count.Text = 0.ToString();
                            loadGioHang();

                        }
                    }

                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (int.Parse(textBox2.Text) == 0 && _ListGioHang.Count() != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Số Lượng Bạn Nhập Sản Phẩm Trong Gio Hàng Này Là 0 (xóa) \n Bạn có muốn tiếp tục cập nhật chứ ???", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _ListGioHang.RemoveAll(p => p.IdCTSP == IdReceiptInCart);
                    dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) + int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString());
                }
                loadGioHang();
            }
            else if (int.Parse(textBox2.Text) == 0 && _ListReceiptProduct2.Count() != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Số Lượng Bạn Nhập Sản Phẩm Trong Hoa Don Này Là 0 (xóa) \n Bạn có muốn tiếp tục cập nhật chứ ???", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //  MessageBox.Show(IdReceiptInCart.ToString());
                    dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) + int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString());
                    _ListReceiptProduct2.RemoveAll(p => p.IdSpCt == IdReceiptInCart);
                    _HoaDonChiTietService.XoaSpTrongHoaDonChiTiet(IdReceiptInCart, IdHoaDon);
                }
                loadReceipt();

            }
            else
            {
                DialogResult dialogResult1 = MessageBox.Show("Bạn Muốn Thay Đổi Chứ???", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    if (textBox2.Text == dgv_GioHang1.CurrentRow.Cells[3].Value.ToString())
                    {
                        return;
                    }
                    else
                    {
                        if (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) < int.Parse(textBox2.Text) && _ListGioHang.FirstOrDefault(p => p.IdCTSP == IdReceiptInCart) != null)
                        {
                            dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) - (int.Parse(textBox2.Text) - int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()));
                            _ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt).SoLuong = int.Parse(textBox2.Text);
                            loadGioHang();
                        }
                        else if (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) > int.Parse(textBox2.Text) && _ListGioHang.FirstOrDefault(p => p.IdCTSP == IdReceiptInCart) != null)
                        {
                            dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) + (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) - int.Parse(textBox2.Text));
                            _ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt).SoLuong = int.Parse(textBox2.Text);
                            loadGioHang();
                        }
                        else
                        if (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) < int.Parse(textBox2.Text) && _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IdReceiptInCart) != null)
                        {
                            dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) - (int.Parse(textBox2.Text) - int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()));
                            _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IdReceiptInCart).SoLuong = int.Parse(textBox2.Text);
                            //   MessageBox.Show(_ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IdReceiptInCart).SoLuong.ToString());

                            loadReceipt();
                        }
                        else if (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) > int.Parse(textBox2.Text) && _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IdReceiptInCart) != null)

                        {
                            //  _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IDSpCt).SoLuong = _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IDSpCt).SoLuong + int.Parse(tb_count.Text);
                            dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) + (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) - int.Parse(textBox2.Text));
                            _ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IdReceiptInCart).SoLuong = int.Parse(textBox2.Text);
                            //       MessageBox.Show(_ListReceiptProduct2.FirstOrDefault(p => p.IdSpCt == IdReceiptInCart).SoLuong.ToString());
                            loadReceipt();

                        }
                        MessageBox.Show("Cập Nhật Thành Công");


                    }
                }
            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox2.Text);
            n++;
            textBox2.Text = n.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            textBox2.Text = n.ToString();
            if (n <= 0)
            {
                n = 0;
                tb_count.Text = n.ToString();
            }
            else
            {
                n = int.Parse(textBox2.Text);
                n--;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }
        Guid IdReceiptInCart;


        private void btn_DatHang_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn Muốn Thanh Toán Hóa Đơn?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (checkHD != 0)
                {
                    MessageBox.Show("Bạn Cần vào bên Hóa Đơn để thực hiện nhé");
                }
                else
                {
                    if (textBox9.Text.Length != 10)
                    {
                        MessageBox.Show("SĐT Không Đúng Định Dạng");
                    }
                    else if (textBox9.Text == "" || textBox8.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                    {
                        MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Thông Tin");
                    }
                    else
                    {
                        SuaHoaDonModels suaHoaDonModels = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);
                        HoaDonChiTietViewModel hdct = _HoaDonChiTietService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);

                        if (rbt_chuathanhtoan.Checked)
                        {
                            suaHoaDonModels.TinhTrang = 2;
                            hdct.TrangThai = 2;

                        }
                        else if (rbt_giaohang.Checked)
                        {
                            suaHoaDonModels.TinhTrang = 3;
                            hdct.TrangThai = 3;
                            flhoadon.Controls.Remove(createButton());
                            loadhoadonduyet();

                        }
                        else if (rbt_dahuy.Checked) suaHoaDonModels.TinhTrang = 6;
                        else if (rbt_dacoc.Checked)
                        {
                            hdct.TrangThai = 7;
                            suaHoaDonModels.TinhTrang = 7;

                        }
                        else if (radioButton3.Checked)
                        {
                            hdct.TrangThai = 1;
                            suaHoaDonModels.TinhTrang = 1;
                            flhd3.Controls.Remove(createButton());
                        }
                        suaHoaDonModels.TenShip = textBox8.Text;
                        suaHoaDonModels.SDTShip = textBox9.Text;
                        suaHoaDonModels.NgayShip = DateTime.Now;
                        suaHoaDonModels.NgayNhan = DateTime.Now;
                        suaHoaDonModels.NgayThanhToan = DateTime.Now;
                        if (_HoaDonChiTietService.SuaHoaDonChiTiet(hdct))
                        {
                            MessageBox.Show(_HoaDonService.SuaHoaDon(suaHoaDonModels));
                            LichSuDiemViewModels lichSuDiemViewModels = new LichSuDiemViewModels();
                            if (_KhachHangServices.GetAllKhachHangDB().SingleOrDefault(p => p.Sdt.Contains(textBox10.Text)).IdVi != null)
                            {
                                lichSuDiemViewModels.IdViDiem = _KhachHangServices.GetAllKhachHangDB().SingleOrDefault(p => p.Sdt.Contains(textBox10.Text)).IdVi;

                                if (textBox12.Text == "")
                                {
                                    lichSuDiemViewModels.SoDiemTieuDung = 0;
                                }
                                else
                                {

                                    lichSuDiemViewModels.SoDiemTieuDung = int.Parse(textBox12.Text);
                                    lichSuDiemViewModels.NgaySuDung = DateTime.Now;
                                    lichSuDiemViewModels.TrangThai = 1;
                                    lichSuDiemViewModels.IdHoaDon = IdHoaDon;
                                    _LichSuDiemService.add(lichSuDiemViewModels);
                                    ViDiemViewModel viDiem = new ViDiemViewModel();
                                    viDiem.TongDiem = viDiem.TongDiem - int.Parse(textBox12.Text);
                                    _ViDiemService.update(viDiem);
                                }
                            }
                        }
                        _ListReceiptProduct2.RemoveRange(0, _ListReceiptProduct2.Count());
                        _ListReceiptProduct.RemoveRange(0, _ListReceiptProduct.Count());
                        if (radioButton3.Checked)
                        {
                            inHoaDon();
                        }
                    }
                }

            }



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_TienKhachCanTra_TextChanged(object sender, EventArgs e)
        {
            //loaiTienThua();
        }

        private void FormBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                videoCaptureDevice.SignalToStop();
                refreshcam();
            }

        }

        private void txt_dathangthue_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);

        }

        private void tb_point_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_coc_TextChanged(object sender, EventArgs e)
        {
            decimal khachdua;
            decimal khachtra;

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string fkhachtra = Convert.ToString(txt_coc.Text);
            string tkhachtra = fkhachtra.Replace(".", "");

            string fkhachdua = Convert.ToString(txt_dathangkhachtra.Text);
            string tkhachdua = fkhachdua.Replace(".", "");
            double ftienthua = Convert.ToDouble(Convert.ToDouble(tkhachtra) - Convert.ToDouble(tkhachdua));

            textBox6.Text = Convert.ToInt32(ftienthua).ToString("#,###", cul.NumberFormat);
            if (ftienthua < 0)
            {
                btn_DatHang.Enabled = false;
            }
            else btn_DatHang.Enabled = true;
        }

        private void txt_dathangkhachtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void dgv_GioHang1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdReceiptInCart = Guid.Parse(dgv_GioHang1.CurrentRow.Cells[6].Value.ToString());
            //    MessageBox.Show(IdReceiptInCart.ToString());
            textBox2.Text = dgv_GioHang1.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void txt_dathangtongtien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string coc = txt_dathangtongtien.Text;
                string fncoc = coc.Replace(".", "");

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                txt_dathangkhachtra.Text = Convert.ToInt32(fncoc).ToString("#,###", cul.NumberFormat);




            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Nhập Chữ Hoặc Kí Tự Đặc Biệt");
                return;
            }
        }

        private void txt_tongTienHoaDon_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string coc = txt_tongTienHoaDon.Text;
                string fncoc = coc.Replace(".", "");

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

                tb_TienKhachCanTra.Text = Convert.ToInt32(fncoc).ToString("#,###", cul.NumberFormat);





            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Không Được Nhập Chữ Hoặc Kí Tự Đặc Biệt1");
                return;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Sdt.Contains(textBox10.Text)) != null)
                {
                    textBox3.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Sdt.Contains(textBox10.Text)).tongDiem.ToString();
                    textBox1.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Sdt.Contains(textBox10.Text)).DiaChi;
                    textBox4.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Sdt.Contains(textBox10.Text)).Sdt;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Khong Tim Thay SDT");
                throw;
            }
        }

        private void textBox10_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[]
                      {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín"};
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length; // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }

                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }

                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }

                    result = " " + result;
                }
            }

            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");

        }
        void inHoaDon()
        {
            pPreDHoaDon.Document = pDHoaDon;
            pPreDHoaDon.ShowDialog();
        }
        private void pDHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                {
                    var w = pDHoaDon.DefaultPageSettings.PaperSize.Width;
                    //Lấy tên cửa hàng

                    e.Graphics.DrawString(
                        "PerSoft Perfume".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                        new PointF(100, 20));
                    //Mã hóa đơn

                    e.Graphics.DrawString(
                        String.Format("{0}", _HoaDonService.GetAllHoaDonDB().Where(c => c.IdHoaDon == IdHoaDon).Select(c => c.Ma).FirstOrDefault()),
                        new Font("Courier New", 12, FontStyle.Bold),
                        Brushes.Black, new PointF(w / 2 + 200, 20));
                    e.Graphics.DrawString(
                        String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:MM")),
                        new Font("Courier New", 12, FontStyle.Bold),
                        Brushes.Black, new PointF(w / 2 + 200, 45));

                    Pen blackPEn = new Pen(Color.Black, 1);
                    var y = 70;

                    Point p1 = new Point(10, y);
                    Point p2 = new Point(w - 10, y);
                    e.Graphics.DrawLine(blackPEn, p1, p2);

                    y += 30;
                    e.Graphics.DrawString(
                        "Phiếu Thanh Toán".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black,
                        new PointF(190, y));


                    y += 80;
                    e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
                    e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(50, y));
                    e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(w / 2, y));
                    e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(w / 2 + 100, y));
                    e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(w - 200, y));
                    var list = _HoaDonChiTietService.GetAllHoaDonDB().Where(x => x.IdHoaDon == IdHoaDon);

                    int i = 1;
                    y += 20;
                    foreach (var x in _HoaDonChiTietService.GetAllProductInReceipt().Where(x => x.IdHoaDon == IdHoaDon))
                    {
                        e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                            new Point(10, y));
                        e.Graphics.DrawString("" + _HangHoaChiTietServices.GetsList()
                                                  .Where(c => c.IdSp == x.IdsP)
                                                  .Select(c => c.Ten).FirstOrDefault() + " " +
                                              _HangHoaChiTietServices.GetsList().Where(c =>
                                                      c.Id == x.IdSpCt)
                                                  .Select(c => c.MoTa).FirstOrDefault(),
                            new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", x.SoLuong), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w / 2, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", x.DonGia), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w / 2 + 100, y));
                        e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToInt32(Convert.ToInt32(x.SoLuong) * Convert.ToInt32(x.DonGia))), new Font("Varial", 8, FontStyle.Bold),
                            Brushes.Black, new Point(w - 200, y));
                        y += 20;
                    }

                    y += 40;
                    p1 = new Point(10, y);
                    p2 = new Point(w - 10, y);
                    e.Graphics.DrawLine(blackPEn, p1, p2);

                    string tt = Convert.ToString(txt_tongTienHoaDon.Text);
                    string fn = tt.Replace(".", "");
                    y += 20;
                    e.Graphics.DrawString(string.Format("Tổng tiền :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                        new Point(w / 2, y));
                    e.Graphics.DrawString(tb_TienKhachCanTra.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                        new Point(w - 200, y));
                    y += 20;
                    e.Graphics.DrawString(string.Format("Tiền khách đưa : "), new Font("Varial", 13, FontStyle.Bold),
                        Brushes.Black, new Point(w / 2, y));
                    e.Graphics.DrawString(tb_tienKhachDua.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                        new Point(w - 200, y));
                    y += 20;
                    e.Graphics.DrawString(string.Format("Trả khách :"), new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                        new Point(w / 2, y));
                    e.Graphics.DrawString(tb_tienThua.Text + "VND", new Font("Varial", 13, FontStyle.Bold), Brushes.Black,
                        new Point(w - 200, y));
                    y += 20;
                    e.Graphics.DrawString(
                        string.Format("Thành chữ : {0} VND", NumberToText(Convert.ToDouble(fn))),
                        new Font("Varial", 13, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 30, y));

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBox5.Text) == 0)
            {
                textBox7.Text = 0.ToString();
                textBox7.Enabled = false;
                textBox11.Enabled = false;

            }
            else
            {
                //textBox7.Enabled = true;
                //textBox11.Enabled = true;
                //string point = textBox7.Text;
                //string fncoc = point.Replace(".", "");

                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                if(_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Sdt.Contains(textBox10.Text)) != null)
                {
                    textBox7.Text = _QuyDoiDiemService.GetDiem().FirstOrDefault(p => p.STD.Contains(textBox10.Text)).TyLeQuyDoi.ToString();
                    textBox13.Text = _QuyDoiDiemService.GetDiem().FirstOrDefault(p => p.STD.Contains(textBox10.Text)).TyLeQuyDoi.ToString();
                }
                
                //    textBox7.Text = Convert.ToInt32(fncoc).ToString("#,###", cul.NumberFormat);               
            }
        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string tongTien2 = textBox11.Text.ToString();
            string fTongTien1 = tongTien2.Replace(".00", "");
            string point = (_QuyDoiDiemService.GetDiem().FirstOrDefault(p => p.STD.Contains(textBox10.Text)).TyLeQuyDoi).ToString();
            string fncoc = point.Replace(".00", "");
            decimal tien = (decimal.Parse(fTongTien1) * decimal.Parse(fncoc));
            textBox7.Text = Convert.ToDouble(tien).ToString("#,###", cul.NumberFormat);

            string tongTien = txt_tongTienHoaDon.Text.ToString();
            string fTongTien = tongTien.Replace(".", "");

            string Point = textBox7.Text.ToString();
            string Fpoint = Point.Replace(".00", "");
            double TienKhachTra = Convert.ToDouble(fTongTien) - Convert.ToDouble(Fpoint);

            tb_TienKhachCanTra.Text = Convert.ToInt32(TienKhachTra).ToString("#,###", cul.NumberFormat);

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string tongTien2 = textBox12.Text.ToString();
            string fTongTien1 = tongTien2.Replace(".00", "");
            string point = (_QuyDoiDiemService.GetDiem().FirstOrDefault(p => p.STD.Contains(textBox10.Text)).TyLeQuyDoi).ToString();
            string fncoc = point.Replace(".00", "");
            decimal tien = (decimal.Parse(fTongTien1) * decimal.Parse(fncoc));
            textBox13.Text = Convert.ToInt32(tien).ToString("#,###", cul.NumberFormat);

            string tongTien = txt_dathangtongtien.Text.ToString();
            string fTongTien = tongTien.Replace(".", "");

            string Point = textBox12.Text.ToString();
            string Fpoint = Point.Replace(".00", "");
            double TienKhachTra = Convert.ToDouble(fTongTien) - Convert.ToDouble(Fpoint);

            txt_dathangkhachtra.Text = Convert.ToInt32(TienKhachTra).ToString("#,###", cul.NumberFormat);


        }
    }
}


