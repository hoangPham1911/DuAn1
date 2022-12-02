﻿using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using _3_GUI_PresentaionLayers;
using AForge.Video.DirectShow;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3_PL.View
{
    public partial class FrmChiTietHangHoa : Form
    {
        private string mahh = "";
        private string tenhh = "";
        private string nsx = "";
        private string trangthai = "";
        private string mavach = "";
        private string soluong = "";
        private string gianhap = "";
        private string giaban = "";
        private string chatlieu = "";
        private string sizegiay = "";
        private string loaigiay = "";
        private string tenquocgia = "";
        private string anh = "";

        private IQlyHangHoaServices _qlhhser;
        private IAnhService _anhser;
        private INsxServices _nsxser;
        private IChatLieuServices _chatlieuser;
        private ILoaiGiayServices _loaigiayser;
        private IQuocGiaServices _quocgiaser;
        private ISizeGiayServices _sizegiayser;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private Guid zen;
        private Guid? zennsx;
        private Guid zendanhmuc;
        private string ok;
        private Guid id;
        private Guid idcthh;
        public FrmChiTietHangHoa(Guid idcthh, Guid idhh ,string mahh, string tenhh, string nsx, string trangthai, string mavach, string soluong,
            string gianhap, string giaban, string chatlieu, string sizegiay, string loaigiay, string tenquocgia, string anh)
        {
            _qlhhser = new QlyHangHoaServices();
            _anhser = new AnhService();
            //_dmser = new DanhMucServices();
            _nsxser = new NsxServices();
            _chatlieuser = new ChatLieuServices();
            _quocgiaser = new QuocGiaServices();
            _sizegiayser = new SizeGiayServices();
            _loaigiayser = new LoaiGiayServices();
            InitializeComponent();
            //loadsugesstion();
            this.mahh = mahh;
            this.id = idhh;
            this.idcthh = idcthh;
            this.tenhh = tenhh;
            this.nsx = nsx;
            this.trangthai = trangthai;
            this.mavach = mavach;
            this.soluong = soluong;
            this.gianhap = gianhap;
            this.giaban = giaban;
            this.chatlieu = chatlieu;
            this.sizegiay = sizegiay;
            this.loaigiay = loaigiay;
            this.tenquocgia = tenquocgia;
            this.anh = anh;
            cbo_anh.Text = anh;
            cbo_mahh.Text = mahh;
            cbo_nsx.Text = nsx;
            cbo_loaigiay.Text = loaigiay;
            cbo_sizegiay.Text = sizegiay;
            cbo_tencl.Text = chatlieu;
            cbo_tenhh.Text = tenhh;
            chk_conhang.Checked = trangthai == "Còn Hàng";
            chk_hethang.Checked = trangthai == "Hết Hàng";
            txt_mavach.Text = mavach;
            txt_soluong.Text = soluong;
            txt_giaban.Text = giaban;
            txt_gianhap.Text = gianhap;
            cbo_tenquocgia.Text = tenquocgia;
            var request = WebRequest.Create(anh);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pic_anhhanghoa.Image = Bitmap.FromStream(stream);
            }
        }

        //public void loadanhmuc()
        //{
        //    foreach (var x in _dmser.GetDanhMuc())
        //    {
        //        cbo_danhmuc.Items.Add(x.Ten);
        //    }
        //}
        public void loadnsx()
        {
            foreach (var x in _nsxser.GetNhasanxuat())
            {
                cbo_nsx.Items.Add(x.Ten);
            }
        }
        public void loadchatlieu()
        {
            foreach (var x in _chatlieuser.GetChatLieu())
            {
                cbo_tencl.Items.Add(x.Ten);
            }
        }
        public void loadsizegiay()
        {
            foreach (var x in _sizegiayser.GetSizeGiay())
            {
                cbo_sizegiay.Items.Add(x.SoSize);
            }
        }
        public void loadloaigiay()
        {
            foreach (var x in _loaigiayser.GetLoaiGiay())
            {
                cbo_loaigiay.Items.Add(x.Ten);
            }
        }
        public void loadquocgia()
        {
            foreach (var x in _quocgiaser.GetQuocGia())
            {
                cbo_tenquocgia.Items.Add(x.Ten);
            }
        }
        public void loaddpath()
        {
            foreach (var x in _anhser.GetAnh())
            {
                cbo_anh.Items.Add(x.DuongDan);
            }
        }



        public bool check()
        {
            if (string.IsNullOrEmpty(cbo_mahh.Text))
            {
                MessageBox.Show("mã hàng hóa không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Mã Hàng Hóa không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbo_mahh.Text))
            {
                MessageBox.Show("mã hàng hóa không được có khoảng trắng", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cbo_tenhh.Text))
            {
                MessageBox.Show("Tên hàng hóa không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(cbo_tenhh.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Tên hàng hóa không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (string.IsNullOrEmpty(cbo_tencl.Text))
            {
                MessageBox.Show("Tên chất liệu không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_soluong.Text))
            {
                MessageBox.Show("Số lượng không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_soluong.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("Số lượng không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_soluong.Text))
            {
                MessageBox.Show("Số lượng không được có khoảng trắng", "Thông báo");
                return false;
            }
            if (Convert.ToInt32(txt_soluong.Text) <= 0 && Convert.ToInt32(txt_soluong.Text) > 2000)
            {
                MessageBox.Show("Số lượng không được âm hoặc nhỏ hơn không và phải nhỏ hơn 2000", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txt_gianhap.Text))
            {
                MessageBox.Show("giá nhập không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_gianhap.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("giá nhập không được chứa ký tự đặc biệt", "ERR");
                return false;
            }
            if (Convert.ToInt32(txt_gianhap.Text) > Convert.ToInt32(txt_giaban.Text))
            {
                MessageBox.Show("giá nhập không được lớn hơn giá bán", "ERR");
                return false;
            }
            if (Convert.ToInt32(txt_gianhap.Text) <= 0 && Convert.ToInt32(txt_gianhap.Text) < 50000000)
            {
                MessageBox.Show("giá nhập phải lơn hơn 0 và nhỏ hơn 50000000", "ERR");
                return false;
            }
            if (string.IsNullOrEmpty(txt_giaban.Text))
            {
                MessageBox.Show("giá bán không được bỏ trống", "Thông báo");
                return false;
            }
            if (Convert.ToInt32(txt_giaban.Text) <= 0 && Convert.ToInt32(txt_giaban.Text) < 100000000)
            {
                MessageBox.Show("giá bán phải lơn hơn 0 và nhỏ hơn 100000000", "ERR");
                return false;
            }
            //
            if (cbo_mahh.Text.Length <= 3 && cbo_mahh.Text.Length >= 10)
            {
                MessageBox.Show("Mã nước hoa phải trên 3 ký tự và nhỏ hơn 10 kí tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã nước hoa Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_giaban.Text, @"^[a-zA-Z0-9 ]*$") == false)
            {

                MessageBox.Show("giá bán không được chứa ký tự đặc biệt", "ERR");
                return false;
            }

            //check trùng
            //danh mục





            //macl
            if (cbo_tencl.Text.Length <= 3)
            {
                MessageBox.Show("Tên chất liệu nước hóa phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã nước hoa Bắt buộc phải chứa số", "ERR");
                return false;
            }


            //tên
            if (cbo_tenhh.Text.Length <= 3)
            {
                MessageBox.Show("Tên hàng hóa phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tenhh.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên hàng hóa không được chứa số", "ERR");
                return false;
            }


            if (Regex.IsMatch(txt_soluong.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số số lượng  không được chứa chữ cái", "ERR");
                return false;
            }

            if (Regex.IsMatch(txt_gianhap.Text, @"^\d+$") == false)
            {

                MessageBox.Show("đơn giá nhập không được chứa chữ cái", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_giaban.Text, @"^\d+$") == false)
            {

                MessageBox.Show("đơn giá bán không được chứa chữ cái", "ERR");
                return false;
            }
            //danh mục
            //if (cbo_danhmuc.Text.Length <= 3)
            //{
            //    MessageBox.Show("Tên danh mục phải trên 3 ký tự", "ERR");
            //    return false;
            //}
            //if (Regex.IsMatch(cbo_danhmuc.Text, @"^[a-zA-Z]") == false)
            //{

            //    MessageBox.Show("Tên danh mục không được chứa số", "ERR");
            //    return false;
            //}
            //nhà sản xuất
            if (cbo_nsx.Text.Length <= 3)
            {
                MessageBox.Show("Tên Nhà Sản Xuất phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_nsx.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Nhà Sản Xuất không được chứa số", "ERR");
                return false;
            }
            //chất liệu
            if (cbo_tencl.Text.Length <= 3)
            {
                MessageBox.Show("Tên Chất Liệu phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tencl.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Chất Liệu  không được chứa số", "ERR");
                return false;
            }
            //loai giay
            if (cbo_loaigiay.Text.Length <= 3)
            {
                MessageBox.Show("Tên Vật Chứa phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_loaigiay.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Vật Chứa  không được chứa số", "ERR");
                return false;
            }
            // size giay
            if (cbo_sizegiay.Text.Length <= 3)
            {
                MessageBox.Show("Tên Nhóm Hương phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_sizegiay.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Nhóm Hương  không được chứa số", "ERR");
                return false;
            }
            //quốc gia
            if (cbo_tenquocgia.Text.Length <= 3)
            {
                MessageBox.Show("Tên Quốc Gia phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_tenquocgia.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Quốc Gia  không được chứa số", "ERR");
                return false;
            }
            return true;
        }


        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txt_mavach.Invoke(new MethodInvoker(delegate ()
                {
                    txt_mavach.Text = result.ToString();
                }));
            }
            pic_cammera.Image = bitmap;


        }
        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }
        public void AlertErr(string mess)
        {
            FrmThatBaiAlert frmThatBaiAlert = new FrmThatBaiAlert();
            frmThatBaiAlert.showAlert(mess);
        }

        private void btn_cammera_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                this.Alert("Mở Camera Thành Công");
            }

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        void reset()
        {
            cbo_tenhh.Text = "";
            txt_mavach.Text = "";
            txt_soluong.Text = "";
            txt_giaban.Text = "";
            txt_gianhap.Text = "";
        }

        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;
        }

        private void FrmChiTietHangHoa_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbo_webcam.Items.Add(device.Name);
            cbo_webcam.SelectedIndex = 0;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            videoCaptureDevice.SignalToStop();
            refreshcam();
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
                if (pic_cammera.Image != null)
                {
                    pic_cammera.Image = null;
                    pic_cammera.ImageLocation = null;
                    pic_cammera.Update();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;

            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    //if (_dmser.GetDanhMuc().Any(c => c.Ten == cbo_danhmuc.Text) == false)
                    //{
                    //    MessageBox.Show("Tên Danh Mục Không Hợp Lệ", "ERR");
                    //    return;
                    //}

                    // nhà sản xuất

                    if (_nsxser.GetNhasanxuat().Any(c => c.Ten == cbo_nsx.Text) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ", "ERR");
                        return;
                    }

                    //size giay

                    if (_sizegiayser.GetSizeGiay().Any(c => c.SoSize == Convert.ToInt32(cbo_tencl.Text)) == false)
                    {
                        MessageBox.Show("Size giày Không Hợp Lệ", "ERR");
                        return;
                    }

                    //ảnh

                    if (_anhser.GetAnh().Any(c => c.DuongDan == cbo_anh.Text) == false)
                    {
                        MessageBox.Show("Dường Dẫn Không Hợp Lệ", "ERR");
                        return;

                    }
                    //loai giay

                    if (_loaigiayser.GetLoaiGiay().Any(c => c.Ten == cbo_loaigiay.Text) == false)
                    {
                        MessageBox.Show("Tên Loại Giày Không Hợp Lệ", "ERR");
                        return;
                    }

                    // chất liệu
                    if (_chatlieuser.GetChatLieu().Any(c => c.Ten == cbo_tencl.Text) == false)
                    {
                        MessageBox.Show("Tên Nhóm Hương Không Hợp Lệ", "ERR");
                        return;
                    }

                    // quốc gia

                    if (_quocgiaser.GetQuocGia().Any(c => c.Ten == cbo_tenquocgia.Text) == false)
                    {
                        MessageBox.Show("Tên Quốc Gia Không Hợp Lệ", "ERR");
                        return;
                    }


                    if (check() == false)
                    {
                        return;
                    }
                    _qlhhser.addhanghoa(new HangHoaThemViewModels()
                    {
                        Ten = cbo_tenhh.Text,
                        Ma = cbo_mahh.Text,
                        TrangThai = Convert.ToInt32(chk_conhang.Checked),
                        IdNsx = _nsxser.GetNhasanxuat().Where(c => c.Ten == cbo_nsx.Text).Select(c => c.Id).FirstOrDefault()
                    });

                    _qlhhser.addcthanghoa(new ChiTietHangHoaThemViewModels()
                    {
                        SoLuongTon = Convert.ToInt32(txt_soluong.Text),
                        GiaNhap = Convert.ToDecimal(txt_gianhap.Text),
                        GiaBan = Convert.ToDecimal(txt_giaban.Text),
                        IdChatLieu = _chatlieuser.GetChatLieu().Where(c => c.Ten == cbo_tencl.Text).Select(c => c.Id).FirstOrDefault(),
                        IdLoaiGiay = _loaigiayser.GetLoaiGiay().Where(c => c.Ten == cbo_loaigiay.Text).Select(c => c.Id).FirstOrDefault(),
                        IdSp = _qlhhser.GetsListHH().Max(c => c.Id),
                        IdQuocGia = _quocgiaser.GetQuocGia().Where(c => c.Ten == cbo_tenquocgia.Text).Select(c => c.Id).FirstOrDefault(),
                        IdSizeGiay = _sizegiayser.GetSizeGiay().Where(c => c.SoSize == Convert.ToDouble(cbo_sizegiay.Text)).Select(c => c.Id).FirstOrDefault(),
                        IdAnh = _anhser.GetAnh().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.ID).FirstOrDefault(),
                        //Mavach = txt_mavach.Text.Trim()
                    });
                    reset();
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Thêm Thành Công");

                    }

                };

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Quân");
                return;
            }
        }

        private void pic_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                FrmHangHoa frmLogin = new FrmHangHoa();
                frmLogin.Show();
                this.Hide();


                for (int i = 0; i < 2; i++)
                {
                    this.Alert("Done");

                }

            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (_qlhhser.GetsList().Any(c => c.Mavach == txt_mavach.Text) == true)
                    {
                        MessageBox.Show("Mã  Vạch Đã tồn Tại yêu cầu nhập mã khác", "ERR");
                        return;
                    }

                    //if (_dmser.GetDanhMuc().Any(c => c.Ten == cbo_danhmuc.Text) == false)
                    //{
                    //    MessageBox.Show("Tên Danh Mục Không Hợp Lệ", "ERR");
                    //    return;
                    //}

                    // nhà sản xuất

                    if (_nsxser.GetNhasanxuat().Any(c => c.Ten == cbo_nsx.Text) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ", "ERR");
                        return;
                    }

                    //size giay

                    if (_sizegiayser.GetSizeGiay().Any(c => c.SoSize == Convert.ToInt32(cbo_tencl.Text)) == false)
                    {
                        MessageBox.Show("Size giày Không Hợp Lệ", "ERR");
                        return;
                    }

                    //ảnh

                    if (_anhser.GetAnh().Any(c => c.DuongDan == cbo_anh.Text) == false)
                    {
                        MessageBox.Show("Dường Dẫn Không Hợp Lệ", "ERR");
                        return;

                    }
                    //loai giay

                    if (_loaigiayser.GetLoaiGiay().Any(c => c.Ten == cbo_loaigiay.Text) == false)
                    {
                        MessageBox.Show("Tên Loại Giày Không Hợp Lệ", "ERR");
                        return;
                    }

                    // chất liệu
                    if (_chatlieuser.GetChatLieu().Any(c => c.Ten == cbo_tencl.Text) == false)
                    {
                        MessageBox.Show("Tên Nhóm Hương Không Hợp Lệ", "ERR");
                        return;
                    }

                    // quốc gia

                    if (_quocgiaser.GetQuocGia().Any(c => c.Ten == cbo_tenquocgia.Text) == false)
                    {
                        MessageBox.Show("Tên Quốc Gia Không Hợp Lệ", "ERR");
                        return;
                    }


                    if (check() == false)
                    {
                        return;
                    }

                    ChiTietHangHoaUpdateViewModels cthh = new ChiTietHangHoaUpdateViewModels();
                    HangHoaUpdateViewModels hh = new HangHoaUpdateViewModels();
                    QlyHangHoaViewModels qlhh = new QlyHangHoaViewModels();
                    hh.Ma = cbo_mahh.Text;
                    hh.Ten = cbo_tenhh.Text;
                    hh.IdNsx = _nsxser.GetNhasanxuat().Where(c => c.Ten == cbo_nsx.Text).Select(c => c.Id).FirstOrDefault();
                    hh.TrangThai = Convert.ToInt32(chk_conhang.Checked);
                    cthh.SoLuongTon = Convert.ToInt32(txt_soluong.Text);
                    qlhh.Mavach = txt_mavach.Text.Trim();
                    cthh.GiaNhap = Convert.ToDecimal(txt_gianhap.Text);
                    cthh.GiaBan = Convert.ToDecimal(txt_giaban.Text);
                    cthh.IdChatLieu = _chatlieuser.GetChatLieu().Where(c => c.Ten == cbo_tencl.Text).Select(c => c.Id).FirstOrDefault();
                    cthh.IdLoaiGiay = _loaigiayser.GetLoaiGiay().Where(c => c.Ten == cbo_loaigiay.Text).Select(c => c.Id).FirstOrDefault();
                    cthh.IdQuocGia = _quocgiaser.GetQuocGia().Where(c => c.Ten == cbo_tenquocgia.Text).Select(c => c.Id).FirstOrDefault();
                    cthh.IdAnh = _anhser.GetAnh().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.ID).FirstOrDefault();
                    cthh.IdSizeGiay = _sizegiayser.GetSizeGiay().Where(c => c.SoSize == Convert.ToInt32(cbo_sizegiay.Text)).Select(c => c.Id).FirstOrDefault();
                    cthh.IdSp = _qlhhser.GetsListHH().Where(c => c.Ten == cbo_tenhh.Text).Select(c => c.Id).FirstOrDefault();
                    _qlhhser.updatehanghoa(hh);
                    _qlhhser.updatecthanghoa(cthh);
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Đã Xác Nhận Cập Nhật Nếu Đồng Ý Hãy Tiến Hành Lưu");

                    }

                };

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Quân");
                return;
            }
        }

        private void chk_conhang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_conhang.Checked)
            {

                chk_hethang.Checked = false;
            }
        }

        private void chk_hethang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hethang.Checked)
            {

                chk_conhang.Checked = false;
            }
        }

        public bool zenbarcode()
        {

            for (int i = 0; i < _qlhhser.GetsList().Count; i++)
            {
                if (_qlhhser.GetsList()[i].Mavach == txt_mavach.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("Mã Vạch Này Đã Tồn Tại Trong Hệ Thống ! Bạn Có Muốn Sử Dụng 1 Số Thuộc Tính Của Nó Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        zen = _qlhhser.GetsList().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.Id).FirstOrDefault();
                        cbo_tenhh.Text = Convert.ToString(_qlhhser.GetsList().Where(c => c.Id == zen).Select(c => c.Ten).FirstOrDefault());
                        zennsx = _qlhhser.GetsList().Where(c => c.Id == zen).Select(c => c.IdNsx).FirstOrDefault();
                        cbo_nsx.Text = Convert.ToString(_nsxser.GetNhasanxuat().Where(c => c.Id == zennsx).Select(c => c.Ten).FirstOrDefault());
                        txt_giaban.Text = Convert.ToString(_qlhhser.GetsList().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.GiaBan).FirstOrDefault());
                        txt_gianhap.Text = Convert.ToString(_qlhhser.GetsList().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.GiaNhap).FirstOrDefault());
                        for (int a = 0; a < 2; a++)
                        {
                            this.Alert("Sử Dụng Thành Công");
                        }

                        return true;
                    };

                    if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        public void loadsugesstion()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=KIRO\\SQLEXPRESS;" +
            "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=quannh;Password=123456";

            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("select TEN FROM HangHoa", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlDataReader dr = sqlCommand.ExecuteReader();

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }


            cbo_tenhh.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void cbo_danhmuc_Click(object sender, EventArgs e)
        {
            //loadanhmuc();
        }

        private void cbo_nsx_Click(object sender, EventArgs e)
        {
            loadnsx();
        }

        private void cbo_anh_Click(object sender, EventArgs e)
        {
            loaddpath();
        }

        private void cbo_tencl_Click(object sender, EventArgs e)
        {
            loadchatlieu();
        }

        private void cbo_sizegiay_Click(object sender, EventArgs e)
        {
            loadsizegiay();
        }

        private void cbo_tenquocgia_Click(object sender, EventArgs e)
        {
            loadquocgia();
        }

        private void cbo_loaigiay_Click(object sender, EventArgs e)
        {
            loadloaigiay();
        }

        private void pic_mavach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mã Vạch Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    FrmCreateNewBarCode frmCreateNewBarCode = new FrmCreateNewBarCode(Guid.Parse(_qlhhser.GetsList().Where(c=>c.Id == idcthh).Select(c=>c.Id).FirstOrDefault().ToString()), Guid.Parse(_qlhhser.GetsList().Where(c => c.IdSp == id).Select(c => c.Id).FirstOrDefault().ToString()), cbo_mahh.Text, cbo_tenhh.Text, cbo_nsx.Text, chk_conhang.Text, txt_mavach.Text, txt_soluong.Text, txt_gianhap.Text, txt_giaban.Text, cbo_tencl.Text, cbo_loaigiay.Text, cbo_sizegiay.Text, cbo_tenquocgia.Text, cbo_anh.Text);
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mã Vạch Thôi Nào");

                    }
                    frmCreateNewBarCode.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr(" Thất Bại");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với Quân");
                return;

            }
        }

        private void txt_mavach_TextChanged(object sender, EventArgs e)
        {
            if (zenbarcode() == true)
            {

                return;
            }
        }

        private void cbo_tenhh_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < _qlhhser.GetsList().Count; i++)
            {
                if (cbo_tenhh.Text == _qlhhser.GetsList()[i].Ten)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tái Sử Dụng 1 Số Thuộc Tính Cơ Bản Của Sản Phầm Cùng Tên Này Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        zen = _qlhhser.GetsList().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.Id).FirstOrDefault();
                        cbo_tenhh.Text = Convert.ToString(_qlhhser.GetsList().Where(c => c.Id == zen).Select(c => c.Ten).FirstOrDefault());
                        zennsx = _qlhhser.GetsList().Where(c => c.Id == zen).Select(c => c.IdNsx).FirstOrDefault();
                        cbo_nsx.Text = Convert.ToString(_nsxser.GetNhasanxuat().Where(c => c.Id == zennsx).Select(c => c.Ten).FirstOrDefault());
                        txt_giaban.Text = Convert.ToString(_qlhhser.GetsList().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.GiaBan).FirstOrDefault());
                        txt_gianhap.Text = Convert.ToString(_qlhhser.GetsList().Where(c => c.Mavach == txt_mavach.Text).Select(c => c.GiaNhap).FirstOrDefault());
                        for (int a = 0; a < 2; a++)
                        {
                            this.Alert("Bạn Đã Sử Dụng Thành Công");

                        }
                        return;
                    };

                    if (dialogResult == DialogResult.No)
                    {
                        for (int a = 0; a < 2; a++)
                        {
                            this.AlertErr(" Sử Dụng Thất Bại");

                        }
                        return;
                    }

                }
            }
        }
    }
}
