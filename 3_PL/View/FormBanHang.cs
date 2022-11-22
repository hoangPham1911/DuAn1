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
        List<Guid> _IdCTSP;
        List<HoaDonChiTietViewModel> _ListReceiptDetail;
        List<GioHangViewModel> _ListGioHang;
        List<SanPhamTrongHoaDonViewModels> _ListReceiptProduct;
        VideoCaptureDevice videoCaptureDevice;
        // camera dung de ghi hinh
        FilterInfoCollection filterInfoCollection; // check xem co bao nhieu cai camera ket noi voi may tinh
        public FormBanHang()
        {
            InitializeComponent();
            _KhachHangServices = new KhachHangServices();
            _AnhService = new AnhService();
            _HoaDonChiTietService = new HoaDonChiTietService();
            _NhanVienServices = new NhanVienServices();
            _HoaDonService = new HoaDonService();
            _SanPhamService = new SanPhamService();
            _HangHoaChiTietServices = new QlyHangHoaServices();
            _IdCTSP = new List<Guid>();
            _ListGioHang = new List<GioHangViewModel>();
            _SanPhamService = new SanPhamService();
            _ListProduct = new List<SanPhamView>();
            _ListReceiptProduct = new List<SanPhamTrongHoaDonViewModels>();
            loadProduct();
            LoadReceipt();
            loadReceiptDetail();
            LoadCbxRank();
            load();
            //  loadInformationClinet();
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
            tb_tenNv.Text = hoTenNV;
            foreach (var item in _KhachHangServices.GetAllKhachHangDB().Select(p => p.Ma))
            {
                cbxKH.Items.Add(item);
            }
        }
        private void loadProduct()
        {
            //if (InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(loadProduct));
            //    return;
            //}
            dgv_product.Rows.Clear();
            dgv_product.ColumnCount = 7;
            dgv_product.Columns[0].Name = "IdSp";
            dgv_product.Columns[1].Name = "STT";
            dgv_product.Columns[2].Name = "Mã SP";
            dgv_product.Columns[3].Name = "Tên SP";
            dgv_product.Columns[4].Name = "Gía Bán";
            dgv_product.Columns[5].Name = "IdSpDetail";
            dgv_product.Columns[6].Name = "Số Lượng Ton";
            dgv_product.Columns[5].Visible = false;
            dgv_product.Columns[0].Visible = false;
            int n = 1;
            _ListProduct = _SanPhamService.GetSanPham();
            if (tb_search.Text != "")
                _ListProduct = _SanPhamService.GetSanPham().Where(p => p.Ten.Contains(tb_search.Text)).ToList();
            // anh
            DataGridViewImageColumn dtgImg = new DataGridViewImageColumn();
            dtgImg.Name = "Data Image";
            dtgImg.HeaderText = "IMG";
            dtgImg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgv_product.Columns.Add(dtgImg);
            dgv_product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_product.RowTemplate.Height = 100;
            dtgImg.DataPropertyName = "img";
            // checkbox
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "choose_cb";
            check.HeaderText = "Choose";
            dgv_product.Columns.Add(check);

            foreach (var item in _ListProduct)
            {
                ///   AnhViewModels image = _AnhService.GetAnh().FirstOrDefault(p => p.ID == item.IdAnh);
                dgv_product.Rows.Add(item.IdSp, n++, item.Ma, item.Ten, item.GiaBan,
              item.IdHangHoaChiTiet, item.SoLuongTon, item.img
              );
            }

            dgv_product.AllowUserToAddRows = false;
            dgv_product.Columns[1].Width = 30;
            dgv_product.Columns[6].Width = 50;
            dgv_product.Columns[7].Width = 100;
            dgv_product.Columns[8].Width = 50;
            dgv_product.Columns[2].Width = 50;
            dgv_product.Columns[3].Width = 100;
            dgv_product.Columns[4].Width = 100;
            dgv_product.Columns[5].Width = 100;

        }
        private void loadReceiptDetail()
        {

            //if (InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(loadReceiptDetail));
            //    return;
            //}
            dgv_ReceiptDetail.Rows.Clear();
            dgv_ReceiptDetail.ColumnCount = 6;
            dgv_ReceiptDetail.Columns[0].Name = "STT";
            dgv_ReceiptDetail.Columns[1].Name = "Mã SP";
            dgv_ReceiptDetail.Columns[2].Name = "Tên SP";
            dgv_ReceiptDetail.Columns[3].Name = "Số Lượng";
            dgv_ReceiptDetail.Columns[4].Name = "Đơn Gía";
            dgv_ReceiptDetail.Columns[5].Name = "Thanh Tiền";
            int n = 1;
            _ListReceiptProduct = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == IdHoaDon).ToList();
            foreach (var item in _ListReceiptProduct)
            {
                dgv_ReceiptDetail.Rows.Add(n++, item.MaSP, item.TenSp,
                item.SoLuong, item.DonGia, item.ThanhTien
                );
            }
            dgv_ReceiptDetail.AllowUserToAddRows = false;

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
                img.HeaderText = "IMG";
                img.Name = "img_sp";
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgv_product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_product.RowTemplate.Height = 100;
                dgv_product.Columns[7].Width = 100;
                img.DataPropertyName = "img";
                for (int i = 0; i < dgv_product.RowCount; i++)
                {
                    Image img1 = Image.FromFile(Convert.ToString(dgv_product.Rows[i].Cells["Ảnh"].Value));

                    dgv_product.Rows[i].Cells["img_sp"].Value = img1;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }
        private void LoadReceipt()
        {

            //if (InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(LoadReceipt));
            //    return;
            //}
            //dgv_hoaDon.Rows.Clear();
            //dgv_hoaDon.ColumnCount = 5;
            //dgv_hoaDon.Columns[0].Name = "Id";
            //dgv_hoaDon.Columns[1].Name = "STT";
            //dgv_hoaDon.Columns[2].Name = "Mã Hóa Đơn";
            //dgv_hoaDon.Columns[3].Name = "Ngày Tạo";
            //dgv_hoaDon.Columns[4].Name = "Tình Trạng";
            //dgv_hoaDon.Columns[0].Visible = false;

            //_ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB().ToList();
            //int n = 1;
            //if (rbn_all.Checked) _ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB().ToList();
            //if (rbn_chuaThanhToan.Checked) _ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB().Where(p => p.TinhTrang == 0).ToList();

            //foreach (var item in _ListReceiptDetail)
            //{

            //    string status = "";
            //    if (item.TinhTrang == 0) status = "Chờ Thanh Toán";
            //    else status = "Hủy";
            //    dgv_hoaDon.Rows.Add(item.IdHoaDon, n++, item.Ma, item.NgayTao, status);
            //}
            //dgv_hoaDon.AllowUserToAddRows = false;
            //dgv_hoaDon.Columns[1].Width = 50;
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
            pn_dathang.Visible = false;

        }

        private Guid addHoaDon()
        {
            ThemHoaDonModels ThemHoaDon = new ThemHoaDonModels();

            ThemHoaDon.Ma = (_HoaDonService.GetAllHoaDonDB().Count + 1).ToString();
            ThemHoaDon.NgayTao = DateTime.Today;
            return _HoaDonService.GetIdHoaDon(ThemHoaDon);
        }
        private void FormBanHang_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbo_webcam.Items.Add(device.Name);
            cbo_webcam.SelectedIndex = 0;

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
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pic_cam.Image = bit;


        }
        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    if (videoCaptureDevice != null || videoCaptureDevice.IsRunning)
        //    {
        //        videoCaptureDevice.WaitForStop();
        //        videoCaptureDevice.SignalToStop();
        //        videoCaptureDevice.Stop();
        //    }
        //}
        private void button9_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.SignalToStop();
            refreshcam();
        }
        Guid IDSpCt;
        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow item in dgv_product.Rows)
            {
                bool total = Convert.ToBoolean(item.Cells["choose_cb"].Value);
                if (total)
                {
                    _IdCTSP.Add(Guid.Parse(item.Cells[5].Value.ToString()));
                }
            }

            int strResults = dgv_product.Rows.Cast<DataGridViewRow>()
                                      .Where(c => Convert.ToBoolean(c.Cells[8].Value).Equals(true)).ToList().Count;


            if (strResults > 1)
            {
                tb_count.Enabled = true;
                btn_down.Enabled = true;
                btn_up.Enabled = true;
                try
                {
                    if (_IdCTSP.Count == 0)
                    {
                        MessageBox.Show("Bạn cần tích vào ô vuông để chọn sản phẩm");
                    }
                    else
                    {
                        HoaDonChiTietThemViewModel HoaDonCT = new HoaDonChiTietThemViewModel();
                        HoaDonCT.IdHoaDon = addHoaDon();
                        foreach (var idSpCt in _IdCTSP)
                        {

                            var donGia = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt).GiaBan;
                            var thanhTien = 1 * donGia;
                            HoaDonCT.IdChiTietSp = idSpCt;
                            HoaDonCT.SoLuong = 1;
                            HoaDonCT.ThanhTien = thanhTien;
                            MessageBox.Show(HoaDonCT.IdHoaDon.ToString() + "-->\n" + 1.ToString() + "-->\n" + donGia.ToString() + "-->\n" +
                            HoaDonCT.IdChiTietSp.ToString() + "->\n" + _HoaDonChiTietService.ThemHoaDonChiTiet(HoaDonCT).ToString());
                            HangHoaChiTietUpdateThanhToan hhctUpdate = _HangHoaChiTietServices.GetAllSoLuong().FirstOrDefault(p => p.IdSpCt == idSpCt);
                            var soLuongTon = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt).SoLuongTon;
                            soLuongTon = soLuongTon - 1;
                            hhctUpdate.SoLuong = soLuongTon;
                            _HangHoaChiTietServices.updateSoLuong(hhctUpdate);
                        }
                        MessageBox.Show("Them Thanh Cong");
                        _IdCTSP.RemoveRange(0, _IdCTSP.Count);

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Loi");
                    throw;
                }
                loadProduct();
                LoadReceipt();
                loadReceiptDetail();
            }
            else if (strResults == 1)
            {
                HoaDonChiTietThemViewModel HoaDonCT = new HoaDonChiTietThemViewModel();
                HoaDonCT.IdHoaDon = addHoaDon();
                var soLuong = int.Parse(tb_count.Text);
                var donGia = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt).GiaBan;
                HoaDonCT.IdChiTietSp = IDSpCt;
                HoaDonCT.SoLuong = soLuong;
                HoaDonCT.ThanhTien = soLuong * donGia;
                if (_HoaDonChiTietService.ThemHoaDonChiTiet(HoaDonCT))
                    MessageBox.Show("Them Thanh Cong");
                HangHoaChiTietUpdateThanhToan hhctUpdate = _HangHoaChiTietServices.GetAllSoLuong().FirstOrDefault(p => p.IdSpCt == IDSpCt);
                var soLuongTon = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt).SoLuongTon;
                soLuongTon = soLuongTon - int.Parse(tb_count.Text);
                hhctUpdate.SoLuong = soLuongTon;

                if (soLuongTon <= 0)
                {
                    MessageBox.Show("Sản Phẩm này đã hết trong kho");
                }
                _HangHoaChiTietServices.updateSoLuong(hhctUpdate);
                loadProduct();
                LoadReceipt();
                loadReceiptDetail();
            }

        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            SuaHoaDonModels suaHoaDonModels = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);
            suaHoaDonModels.TinhTrang = 1;
            suaHoaDonModels.NgayThanhToan = DateTime.Now;
            MessageBox.Show(_HoaDonService.SuaHoaDon(suaHoaDonModels));
            loadProduct();
            LoadReceipt();
            loadReceiptDetail();

        }

        private void rbn_DaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            LoadReceipt();
        }

        private void rbn_chuaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            LoadReceipt();

        }

        private void rbn_Huy_CheckedChanged(object sender, EventArgs e)
        {
            LoadReceipt();

        }

        private void rbn_all_CheckedChanged(object sender, EventArgs e)
        {
            LoadReceipt();

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
        }
        public void loaiTienThua()
        {

            if (decimal.TryParse(tb_tienKhachDua.Text, out decimal x))
            {
                tb_tienThua.Text = (decimal.Parse(tb_tienKhachDua.Text) - decimal.Parse(txt_tongTienHoaDon.Text)).ToString();
            }

        }
        private void tb_tienThua_TextChanged(object sender, EventArgs e)
        {
            loaiTienThua();
        }

        private void tb_tienKhachDua_TextChanged(object sender, EventArgs e)
        {
            loaiTienThua();
        }

        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDSpCt = Guid.Parse(dgv_product.CurrentRow.Cells[5].Value.ToString());
        }

        private void btn_FormHoaDon_Click(object sender, EventArgs e)
        {
            pn_dathang.Visible = true;
        }
        Guid IdHoaDon; string status = ""; string maHd = "";
        private void dgv_hoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //IdHoaDon = Guid.Parse(dgv_hoaDon.CurrentRow.Cells[0].Value.ToString());
            //maHd = dgv_hoaDon.CurrentRow.Cells[2].Value.ToString();
            //decimal? n = 0;
            //var price = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == IdHoaDon);
            //foreach (var item in price)
            //{
            //    n += item.ThanhTien;
            //}
            //txt_tongTienHoaDon.Text = n.ToString();

            //status = dgv_hoaDon.CurrentRow.Cells[4].Value.ToString();
            ////   MessageBox.Show(status);
            //if (status == "Đã Thanh Toán")
            //{
            //    radioButton10.Checked = true;
            //    btn_ThanhToan.Enabled = false;
            //}

            //else if (status == "Chờ Thanh Toán") radioButton6.Checked = true;
            //if (_HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.Ma == maHd) != null)
            //{
            //    loadReceiptDetail();
            //}

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }

        private void loadInformationClinet()
        {
            textBox3.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text).Ten;
            textBox1.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text).DiaChi;
            textBox4.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text).Sdt;

        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text) != null)
            {
                loadInformationClinet();
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text) != null)
            {
                loadInformationClinet();
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text) != null)
            {
                loadInformationClinet();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}


