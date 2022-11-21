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
        IHoaDonService _HoaDonService;
        IHoaDonChiTietService _HoaDonChiTietService;
        ISanPhamService _SanPhamService;
        IHangHoaChiTietServices _HangHoaChiTietServices;
        List<SanPhamView> _ListProduct;
        List<ThemHoaDonModels> _ListReceipt;
        List<Guid> _IdCTSP;
        List<HoaDonChiTietViewModel> _ListReceiptDetail;
        List<SanPhamTrongHoaDonViewModels> _ListReceiptProduct;
        VideoCaptureDevice videoCaptureDevice;
        // camera dung de ghi hinh
        FilterInfoCollection filterInfoCollection; // check xem co bao nhieu cai camera ket noi voi may tinh
        public FormBanHang()
        {
            InitializeComponent();
            _HoaDonChiTietService = new HoaDonChiTietService();
            _HoaDonService = new HoaDonService();
            _SanPhamService = new SanPhamService();
            _HangHoaChiTietServices = new HangHoaChiTietServices();
            _IdCTSP = new List<Guid>();
            _SanPhamService = new SanPhamService();
            _ListProduct = new List<SanPhamView>();
            _ListReceiptProduct = new List<SanPhamTrongHoaDonViewModels>();
            loadProduct();
            LoadReceipt();
            loadReceiptDetail();
            LoadCbxRank();
        }
        void LoadCbxRank()
        {
            cbxRank.Items.Add("Bạc");
            cbxRank.Items.Add("Vàng");
            cbxRank.Items.Add("Kim cương");
            cbxRank.SelectedIndex = 0;
        }
        private void loadProduct()
        {
            //if (InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(loadProduct));
            //    return;
            //}
            dgv_product.Rows.Clear();
            dgv_product.ColumnCount = 14;
            dgv_product.Columns[0].Name = "IdSp";
            dgv_product.Columns[1].Name = "STT";
            dgv_product.Columns[2].Name = "Mã SP";
            dgv_product.Columns[3].Name = "Tên SP";
            dgv_product.Columns[4].Name = "Năm BH";
            dgv_product.Columns[5].Name = "Mô tả";
            dgv_product.Columns[6].Name = "Gía Nhập";
            dgv_product.Columns[7].Name = "Gía Bán";
            dgv_product.Columns[8].Name = "IdSpDetail";
            dgv_product.Columns[9].Name = "Số Lượng Ton";
            dgv_product.Columns[10].Name = "Màu Sắc";
            dgv_product.Columns[11].Name = "Sản Phẩm Tương Tự";
            dgv_product.Columns[12].Name = "Nhà Sản Xuất";
            dgv_product.Columns[13].Name = "Nhà Sản Xuất";
            dgv_product.Columns[8].Visible = false;
            dgv_product.Columns[0].Visible = false;
            int n = 1;
            _ListProduct = _SanPhamService.GetSanPham();
            if (tb_search.Text != "")
                _ListProduct = _SanPhamService.GetSanPham().Where(p => p.Ten.Contains(tb_search.Text)).ToList();
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "choose_cb";
            check.HeaderText = "Choose";
            dgv_product.Columns.Insert(14, check);
            foreach (var item in _ListProduct)
            {
                dgv_product.Rows.Add(item.IdSp, n++, item.Ma, item.Ten,
              item.NamBh, item.MoTa, item.GiaNhap, item.GiaBan,
              item.IdHangHoaChiTiet, item.SoLuongTon, item.IdSizeGiay, item.IdChatLieu, item.IdNsx, item.IdLoaiGiay
              );
            }
            dgv_product.AllowUserToAddRows = false;
            dgv_product.Columns[1].Width = 50;
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
        private void LoadReceipt()
        {

            //if (InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(LoadReceipt));
            //    return;
            //}
            dgv_hoaDon.Rows.Clear();
            dgv_hoaDon.ColumnCount = 5;
            dgv_hoaDon.Columns[0].Visible = false;
            _ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB();
            int n = 1;
            if (rbn_all.Checked) _ListReceiptDetail = _ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB();
            if (rbn_DaThanhToan.Checked) _ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB().Where(p => p.TinhTrang == 1).ToList();
            if (rbn_chuaThanhToan.Checked) _ListReceiptDetail = _HoaDonChiTietService.GetAllHoaDonDB().Where(p => p.TinhTrang == 2).ToList();
            foreach (var item in _ListReceiptDetail)
            {
                string status = "";
                if (item.TinhTrang == 1)
                {
                    status = "Đã Thanh Toán";
                }
                else if (item.TinhTrang == 0) status = "Chờ Thanh Toán";
                else status = "Hủy";
                dgv_hoaDon.Rows.Add(item.IdHoaDon, n++, item.Ma, item.NgayTao, status);
            }
            dgv_hoaDon.AllowUserToAddRows = false;
            dgv_hoaDon.Columns[1].Width = 50;
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
                    //pic_cam.Image = null;
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
            btn_FormdatHang.Visible = true;
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
            if (videoCaptureDevice.IsRunning)
                refreshcam();
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
                    _IdCTSP.Add(Guid.Parse(item.Cells[8].Value.ToString()));
                }
            }

            int strResults = dgv_product.Rows.Cast<DataGridViewRow>()
                                      .Where(c => Convert.ToBoolean(c.Cells[14].Value).Equals(true)).ToList().Count;
            
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
                        HoaDonChiTietThemViewModel HoaDonCT = new HoaDonChiTietThemViewModel();
                        HoaDonCT.IdHoaDon = addHoaDon();
                        foreach (var idSpCt in _IdCTSP)
                        {
                            var soLuong = 1;
                            var donGia = _HangHoaChiTietServices.GetAllHoaDonDB().FirstOrDefault(p => p.Id == IDSpCt).GiaBan;
                            var thanhTien = soLuong * donGia;
                            HoaDonCT.IdChiTietSp = idSpCt;
                            HoaDonCT.SoLuong = soLuong;
                            HoaDonCT.ThanhTien = thanhTien;
                            MessageBox.Show(HoaDonCT.IdHoaDon.ToString() + "-->\n" + soLuong.ToString() + "-->\n" + donGia.ToString() + "-->\n" +
                                HoaDonCT.IdChiTietSp.ToString() + "->\n" + _HoaDonChiTietService.ThemHoaDonChiTiet(HoaDonCT).ToString());
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

            {
                HoaDonChiTietThemViewModel HoaDonCT = new HoaDonChiTietThemViewModel();
                HoaDonCT.IdHoaDon = addHoaDon();
                var soLuong = int.Parse(tb_count.Text);
                var donGia = _HangHoaChiTietServices.GetAllHoaDonDB().FirstOrDefault(p => p.Id == IDSpCt).GiaBan;
                var thanhTien = soLuong * donGia;
                HoaDonCT.IdChiTietSp = IDSpCt;
                HoaDonCT.SoLuong = soLuong;
                HoaDonCT.ThanhTien = thanhTien;
                MessageBox.Show(HoaDonCT.IdHoaDon.ToString() + "-->\n" + soLuong.ToString() + "-->\n" + donGia.ToString() + "-->\n" +
            
                HoaDonCT.IdChiTietSp.ToString() + "->\n" + _HoaDonChiTietService.ThemHoaDonChiTiet(HoaDonCT).ToString());
                MessageBox.Show("Them Thanh Cong");
                HangHoaChiTietUpdateViewModels hhctUpdate = new HangHoaChiTietUpdateViewModels();
                var soLuongTon = _HangHoaChiTietServices.GetAllHoaDonDB().FirstOrDefault(p => p.Id == IDSpCt).SoLuongTon;
                soLuongTon = soLuongTon - int.Parse(tb_count.Text);
                hhctUpdate.SoLuongTon = soLuongTon;
                if (soLuongTon == 0)
                {
                    MessageBox.Show("Sản Phẩm này đã hết trong kho");
                }
                _HangHoaChiTietServices.SuaHangHoaChiTiet(hhctUpdate);

            }
        }
        Guid IdHoaDon; string status = ""; string maHd = "";
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            SuaHoaDonModels suaHoaDonModels = _HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.IdHoaDon == IdHoaDon);
            if (radioButton10.Checked) suaHoaDonModels.TinhTrang = 1;
            suaHoaDonModels.NgayThanhToan = DateTime.Now;
            MessageBox.Show(_HoaDonService.SuaHoaDon(suaHoaDonModels));
            loadProduct();
            LoadReceipt();
            loadReceiptDetail();

        }

        private void dgv_hoaDon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            IdHoaDon = Guid.Parse(dgv_hoaDon.CurrentRow.Cells[0].Value.ToString());
            maHd = dgv_hoaDon.CurrentRow.Cells[2].Value.ToString();
            decimal? n = 0;
            var price = _HoaDonChiTietService.GetAllProductInReceipt().Where(p => p.IdHoaDon == IdHoaDon);
            foreach (var item in price)
            {
                n += item.ThanhTien;
            }
            txt_tongTienHoaDon.Text = n.ToString();

            status = dgv_hoaDon.CurrentRow.Cells[4].Value.ToString();
            if (status == "Đã Thanh Toán")
            {
                radioButton10.Checked = true;
                btn_ThanhToan.Enabled = false;
            }

            else if (status == "Chờ Thanh Toán") radioButton6.Checked = true;
            if (_HoaDonService.GetAllHoaDonDB().FirstOrDefault(p => p.Ma == maHd) != null)
            {
                loadReceiptDetail();
            }

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
            IDSpCt = Guid.Parse(dgv_product.CurrentRow.Cells[8].Value.ToString());
        }
    }
}


