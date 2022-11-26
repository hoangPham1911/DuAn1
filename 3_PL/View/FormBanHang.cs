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
        List<Guid> _IDSPInCart;
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
            _IDSPInCart = new List<Guid>();
            _ListGioHang = new List<GioHangViewModel>();
            _SanPhamService = new SanPhamService();
            _ListProduct = new List<SanPhamView>();
            _ListReceiptProduct = new List<SanPhamTrongHoaDonViewModels>();
            loadProduct();
            loadGioHang();
            LoadCbxRank();
            load();
            loadhoadonduyet();

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
              item.IdHangHoaChiTiet, item.SoLuongTon
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
        private void loadGioHang()
        {
            dgv_GioHang.Rows.Clear();
            dgv_GioHang.ColumnCount = 7;
            dgv_GioHang.Columns[0].Name = "STT";
            dgv_GioHang.Columns[1].Name = "Mã SP";
            dgv_GioHang.Columns[2].Name = "Tên SP";
            dgv_GioHang.Columns[3].Name = "Số Lượng";
            dgv_GioHang.Columns[4].Name = "Đơn Gía";
            dgv_GioHang.Columns[5].Name = "Thanh Tiền";
            dgv_GioHang.Columns[6].Name = "IDSPCT";
            dgv_GioHang.Columns[6].Visible = false;
            int n = 1;
            foreach (var item in _ListGioHang)
            {
                dgv_GioHang.Rows.Add(n++, item.MaSp, item.TenSp,
                item.SoLuong, item.DonGia, item.ThanhTien, item.IdCTSP
                );
            }
            dgv_GioHang.AllowUserToAddRows = false;

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
        string MaHd = "";
        private Guid addHoaDon()
        {
            ThemHoaDonModels ThemHoaDon = new ThemHoaDonModels();
            ThemHoaDon.Ma = "HD0000" + (_HoaDonService.GetAllHoaDonDB().Count + 1).ToString();
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
        private void btnsender_Click(object sender, EventArgs e)
        {
            dgv_GioHang.Rows.Clear();
            Guid acbc = ((sender as Button).Tag as SuaHoaDonModels).IdHoaDon;
            IdHoaDon = acbc;

            dgv_GioHang.Rows.Clear();
            dgv_GioHang.ColumnCount = 7;
            dgv_GioHang.Columns[0].Name = "STT";
            dgv_GioHang.Columns[1].Name = "Mã SP";
            dgv_GioHang.Columns[2].Name = "Tên SP";
            dgv_GioHang.Columns[3].Name = "Số Lượng";
            dgv_GioHang.Columns[4].Name = "Đơn Gía";
            dgv_GioHang.Columns[5].Name = "Thanh Tiền";
            dgv_GioHang.Columns[6].Name = "IDSPCT";
            dgv_GioHang.Columns[0].Visible = false;
            dgv_GioHang.Columns[6].Visible = false;
            int n = 1;
            _ListReceiptProduct = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == acbc).ToList();
            foreach (var item in _ListReceiptProduct)
            {
                dgv_GioHang.Rows.Add(item.IdHoaDon, n++, item.MaSP, item.TenSp, item.SoLuong, item.ThanhTien, item.IdSpCt);
            }


            IdHoaDon = Guid.Parse(dgv_GioHang.CurrentRow.Cells[0].Value.ToString());
            maHd = dgv_GioHang.CurrentRow.Cells[2].Value.ToString();
            decimal? tien = 0;
            var price = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == IdHoaDon);

            foreach (var item in price)
            {
                tien += item.ThanhTien;
            }
            txt_tongTienHoaDon.Text = tien.ToString();

            status = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon).TinhTrang;
            //   MessageBox.Show(status);
            if (status == 1)
            {
                radioButton10.Checked = true;
                btn_ThanhToan.Enabled = false;
            }

            else if (status == 2) radioButton6.Checked = true;
            if (_HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.Ma == maHd) != null)
            {

            }

        }
        public void loadhoadonduyet()
        {
            try
            {
                flhoadon.Controls.Clear();
                foreach (var x in _HoaDonService.GetAllHoaDonDB().Where(c => c.TinhTrang == 2))
                {
                    Button btn = new Button();

                    btn.Text = x.Ma + Environment.NewLine + (x.TinhTrang == 2
                        ? "Chưa Thanh Toán"
                        : (x.TinhTrang == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"));
                    btn.Tag = x;
                    btn.Location = new Point(60, 60);
                    btn.Size = new Size(65, 75);
                    btn.Visible = true;
                    btn.Click += btnsender_Click;
                    btn.ForeColor = Color.Aquamarine;
                    switch (x.TinhTrang)
                    {
                        case 2:
                            {
                                btn.BackColor = Color.Red;
                                break;
                            }
                        case 3:
                            btn.BackColor = Color.BlueViolet;
                            break;
                    }

                    flhoadon.Controls.Add(btn);
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
        private void button9_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.SignalToStop();
            refreshcam();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            HoaDonChiTietThemViewModel HoaDonCT = new HoaDonChiTietThemViewModel();
            HoaDonCT.IdHoaDon = addHoaDon();
            if (_ListGioHang.Any())
            {

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
                MessageBox.Show("Tao hoa don thanh cong");
                loadhoadonduyet();

            }
            else
            {
                MessageBox.Show("Loi");
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            SuaHoaDonModels suaHoaDonModels = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);
            suaHoaDonModels.TinhTrang = 1;
            suaHoaDonModels.NgayThanhToan = DateTime.Now;
            MessageBox.Show(_HoaDonService.SuaHoaDon(suaHoaDonModels));
            loadGioHang();

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
        Guid IDSpCt;
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDSpCt = Guid.Parse(dgv_product.CurrentRow.Cells[5].Value.ToString());
        }

        private void btn_FormHoaDon_Click(object sender, EventArgs e)
        {
            pn_dathang.Visible = true;
        }
        Guid IdHoaDon; int? status; string maHd = "";
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
        private void addProductToCart()
        {
            {
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
                    try
                    {
                        if (_IdCTSP.Count == 0)
                        {
                            MessageBox.Show("Bạn cần tích vào ô vuông để chọn sản phẩm");
                        }
                        else
                        {

                            foreach (var idSpCt in _IdCTSP)
                            {
                                
                                dgv_product.CurrentRow.Cells[6].Value = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == idSpCt).SoLuongTon - 1;

                                var donGia = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == idSpCt).GiaBan;
                                var thanhTien = donGia;
                                var sp = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == idSpCt);
                                var MaSp = sp.Ma;
                                var TenSp = sp.Ten;
                                GioHangViewModel gioHang = new GioHangViewModel();
                                gioHang.SoLuong = 1;
                                gioHang.IdCTSP = idSpCt;
                                gioHang.DonGia = donGia;
                                gioHang.MaSp = MaSp;
                                gioHang.TenSp = TenSp;
                                gioHang.ThanhTien = donGia;
                                _ListGioHang.Add(gioHang);

                            }
                            MessageBox.Show("Them Thanh Cong");
                            _IdCTSP.RemoveRange(0, _IdCTSP.Count);
                            loadGioHang();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Loi");
                        throw;
                    }

                }
                else if (strResults == 0 || strResults == 1)
                {

                    var soLuong = int.Parse(tb_count.Text);
                    var donGia = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt).GiaBan;
                    if (soLuong == 0)
                    {
                        MessageBox.Show("Bạn Chưa Nhập Số Lượng");
                    }
                    else
                    {
                        dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) - int.Parse(tb_count.Text);
                        var sp = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IDSpCt);
                        var MaSp = sp.Ma;
                        var TenSp = sp.Ten;
                        GioHangViewModel gioHang = new GioHangViewModel();
                        gioHang.SoLuong = soLuong;
                        gioHang.DonGia = donGia;
                        gioHang.MaSp = MaSp;
                        gioHang.IdCTSP = IDSpCt;
                        gioHang.TenSp = TenSp;
                        gioHang.ThanhTien = donGia * soLuong;
                        if (_ListGioHang.Count() == 0)
                        {
                            _ListGioHang.Add(gioHang);
                        }
                        else if (_ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt) != null)
                        {
                            _ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt).SoLuong = _ListGioHang.FirstOrDefault(p => p.IdCTSP == IDSpCt).SoLuong + int.Parse(tb_count.Text);
                        }
                        else
                        {
                            _ListGioHang.Add(gioHang);
                        }
                        if (sp.SoLuongTon <= 0)
                        {
                            MessageBox.Show("Sản Phẩm này đã hết trong kho");
                        }
                        else
                        {
                            MessageBox.Show("Them Thanh Cong");

                        }

                    }

                    loadGioHang();
                }

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            addProductToCart();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Số Lượng Bạn Nhập Sản Phẩm Trong Gio Hàng Này Là 0 (xóa) \n Bạn có muốn tiếp tục cập nhật chứ ???", "Thông Báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _ListGioHang.RemoveAll(p => p.IdCTSP == IdReceiptInCart);
                    _ListProduct.FirstOrDefault(p => p.IdHangHoaChiTiet == IdReceiptInCart).SoLuongTon
                    = _ListProduct.FirstOrDefault(p => p.IdHangHoaChiTiet == IdReceiptInCart).SoLuongTon + int.Parse(textBox2.Text);
                }

            }
            else if (textBox2.Text == dgv_GioHang.CurrentRow.Cells[3].Value.ToString())
            {
                return;
            }
            else
            {
                var sp = _SanPhamService.GetSanPham().FirstOrDefault(p => p.IdHangHoaChiTiet == IdReceiptInCart);
                var soLuongTon = sp.SoLuongTon;
                soLuongTon = soLuongTon - int.Parse(textBox2.Text);
                dgv_GioHang.CurrentRow.Cells[3].Value = int.Parse(textBox2.Text);
                //   if ()

                MessageBox.Show("Cập Nhật Thành Công");

            }
            //     loadGioHang();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            n++;
            textBox2.Text = n.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            n--;
            textBox2.Text = n.ToString();
            if (n <= 0)
            {
                n = 0;
                tb_count.Text = n.ToString();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);
        }
        Guid IdReceiptInCart;
        private void dgv_GioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdReceiptInCart = Guid.Parse(dgv_GioHang.CurrentRow.Cells[6].Value.ToString());
            // MessageBox.Show(IdReceiptInCart.ToString());
            textBox2.Text = dgv_GioHang.CurrentRow.Cells[3].Value.ToString();

        }
    }
}


