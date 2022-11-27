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
        List<Guid> _IdSpInCart;
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
            _ListGioHang = new List<GioHangViewModel>();
            _SanPhamService = new SanPhamService();
            _ListProduct = new List<SanPhamView>();
            _IdSpInCart = new List<Guid>();
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
            dgv_product.Columns[2].Width = 50;
            dgv_product.Columns[3].Width = 100;
            dgv_product.Columns[4].Width = 100;
            dgv_product.Columns[5].Width = 100;

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
            dgv_GioHang1.Rows.Clear();
            Guid acbc = ((sender as Button).Tag as SuaHoaDonModels).IdHoaDon;
            IdHoaDon = acbc;

            dgv_GioHang1.Rows.Clear();
            dgv_GioHang1.ColumnCount = 7;
            dgv_GioHang1.Columns[0].Name = "STT";
            dgv_GioHang1.Columns[1].Name = "Mã SP";
            dgv_GioHang1.Columns[2].Name = "Tên SP";
            dgv_GioHang1.Columns[3].Name = "Số Lượng";
            dgv_GioHang1.Columns[4].Name = "Đơn Gía";
            dgv_GioHang1.Columns[5].Name = "Thanh Tiền";
            dgv_GioHang1.Columns[6].Name = "IDSPCT";
            dgv_GioHang1.Columns[0].Visible = false;
            dgv_GioHang1.Columns[6].Visible = false;
            int n = 1;
            _ListReceiptProduct = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == acbc).ToList();
            foreach (var item in _ListReceiptProduct)
            {
                dgv_GioHang1.Rows.Add(item.IdHoaDon, n++, item.MaSP, item.TenSp, item.SoLuong, item.ThanhTien, item.IdSpCt);
            }


            IdHoaDon = Guid.Parse(dgv_GioHang1.CurrentRow.Cells[0].Value.ToString());
            maHd = dgv_GioHang1.CurrentRow.Cells[2].Value.ToString();
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
                btn_ThanhToan.Enabled = false;
            }
            else if (status == 2) radioButton6.Checked = true;
            if (_HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.Ma == maHd) != null)
            {

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

                foreach (var x in _HoaDonService.GetAllHoaDonDB())
                {
                    Button button = createButton();
                    button.Location = new Point(62, 62);
                    button.Size = new Size(63, 90);
                    button.Visible = true;
                    button.Click += btnsender_Click;
                    button.ForeColor = Color.Aquamarine;
                    button.Text = x.Ma + Environment.NewLine + (x.TinhTrang == 2
                        ? "Chưa Thanh Toán"
                        : (x.TinhTrang == 3 ? "Đang Chờ Giao Hàng" : "Đã Hủy"));
                    button.Tag = x;

                    switch (x.TinhTrang)
                    {
                        case 2:
                            {
                                button.BackColor = Color.Red;
                                flhoadon.Controls.Add(button);
                                break;
                            }
                        case 3:
                            button.BackColor = Color.BlueViolet;
                            flhd3.Controls.Add(button);
                            break;
                    }

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
                _ListGioHang.RemoveRange(0, _ListGioHang.Count);
                loadGioHang();
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
            flhoadon.Controls.Remove(createButton());
            loadGioHang();
            loadhoadonduyet();

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
                    dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) + int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString());
                }
                loadGioHang();
            }
            else if (textBox2.Text == dgv_GioHang1.CurrentRow.Cells[3].Value.ToString())
            {
                return;
            }
            else
            {
                if (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) < int.Parse(textBox2.Text) && _ListGioHang.FirstOrDefault(p => p.IdCTSP == IdReceiptInCart) != null)
                {
                    dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) - int.Parse(textBox2.Text);
                    dgv_GioHang1.CurrentRow.Cells[3].Value = int.Parse(textBox2.Text);
                }
                else if (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) > int.Parse(textBox2.Text) && _ListGioHang.FirstOrDefault(p => p.IdCTSP == IdReceiptInCart) != null)
                {
                    dgv_product.CurrentRow.Cells[6].Value = int.Parse(dgv_product.CurrentRow.Cells[6].Value.ToString()) + (int.Parse(dgv_GioHang1.CurrentRow.Cells[3].Value.ToString()) - int.Parse(textBox2.Text));
                    dgv_GioHang1.CurrentRow.Cells[3].Value = int.Parse(textBox2.Text);
                }

                MessageBox.Show("Cập Nhật Thành Công");

            }
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
            IdReceiptInCart = Guid.Parse(dgv_GioHang1.CurrentRow.Cells[6].Value.ToString());
            // MessageBox.Show(IdReceiptInCart.ToString());
            textBox2.Text = dgv_GioHang1.CurrentRow.Cells[3].Value.ToString();

        }

        private void btn_DatHang_Click(object sender, EventArgs e)
        {
            loadhoadonduyet();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text).DiemTichDiem == null)
            {
                textBox7.Text = 0.ToString();
            }
            else
                textBox7.Text = _KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text).DiemTichDiem.ToString();

        }

        private void tb_TienKhachCanTra_TextChanged(object sender, EventArgs e)
        {
            tb_TienKhachCanTra.Text = (int.Parse(txt_tongTienHoaDon.Text) + int.Parse(tb_thue.Text) - int.Parse(textBox7.Text)).ToString();
        }

        private void cbxRank_TextChanged(object sender, EventArgs e)
        {
            if (_KhachHangServices.GetAllKhachHangDB().FirstOrDefault(p => p.Ma == cbxKH.Text).DiemTichDiem > 100)
            {

            }
        }
    }
}


