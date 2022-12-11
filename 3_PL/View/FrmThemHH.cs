using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using _3_GUI_PresentaionLayers;
using AForge.Video.DirectShow;
using DocumentFormat.OpenXml.Office2010.Drawing;
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
    public partial class FrmThemHH : Form
    {
        private IQlyHangHoaServices _qlhhser;
        private IAnhService _anhser;
        private INsxServices _nsxser;
        private IChatLieuServices _chatlieuser;
        private ILoaiGiayServices _loaigiayser;
        private IQuocGiaServices _quocgiaser;
        private ISizeGiayServices _sizegiayser;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public FrmThemHH()
        {
            InitializeComponent();
            _qlhhser = new QlyHangHoaServices();
            _anhser = new AnhService();
            //_dmser = new DanhMucServices();
            _nsxser = new NsxServices();
            _chatlieuser = new ChatLieuServices();
            _quocgiaser = new QuocGiaServices();
            _sizegiayser = new SizeGiayServices();
            _loaigiayser = new LoaiGiayServices();
            loadnsx();
            loadchatlieu();
            loadsizegiay();
            loadloaigiay();
            loadquocgia();
            loaddpath();
            //var request = WebRequest.Create(cbo_anh.Text);
            //using (var response = request.GetResponse())
            //using (var stream = response.GetResponseStream())
            //{
            //    pic_anhhanghoa.Image = Bitmap.FromStream(stream);
            //}
        }

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
                MessageBox.Show("Mã hàng hóa phải trên 3 ký tự và nhỏ hơn 10 kí tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_mahh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã Hàng hóa Bắt buộc phải chứa số", "ERR");
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
           
            if (Regex.IsMatch(cbo_mahh.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Mã hàng hóa Bắt buộc phải chứa số", "ERR");
                return false;
            }


            //tên
            if (cbo_tenhh.Text.Length <= 3)
            {
                MessageBox.Show("Tên hàng hóa phải trên 3 ký tự", "ERR");
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
           
            if (Regex.IsMatch(cbo_tencl.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên Chất Liệu  không được chứa số", "ERR");
                return false;
            }
            //loai giay
            if (cbo_loaigiay.Text.Length <= 3)
            {
                MessageBox.Show("Tên loại giày phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(cbo_loaigiay.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên loại giày  không được chứa số", "ERR");
                return false;
            }
            // size giay
            if (Regex.IsMatch(cbo_sizegiay.Text, @"^\d+$") == false)
            {

                MessageBox.Show("Size giày không được chứa chữ cái", "ERR");
                return false;
            }
            //quốc gia
            
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

        private void FrmThemHH_Load(object sender, EventArgs e)
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

        private Guid Sp()
        {
            HangHoaViewModels product = new HangHoaViewModels();
            product.Ma = cbo_mahh.Text;
            product.Ten = cbo_tenhh.Text;
            product.IdNsx = _nsxser.GetNhasanxuat().Where(c => c.Ten == cbo_nsx.Text).Select(c => c.Id).FirstOrDefault();
            if (chk_conhang.Checked)
            {
                product.TrangThai = 1;
            }
            else
            {
                product.TrangThai = 0;
            }
            return _qlhhser.IdSp(product);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    // nhà sản xuất

                    if (_nsxser.GetNhasanxuat().Any(c => c.Ten == cbo_nsx.Text) == false)
                    {
                        MessageBox.Show("Tên Nhà Sản Xuất Không Hợp Lệ", "ERR");
                        return;
                    }

                    //size giay

                    if (_sizegiayser.GetSizeGiay().Any(c => c.SoSize == Convert.ToInt32(cbo_sizegiay.Text)) == false)
                    {
                        MessageBox.Show("Size giày Không Hợp Lệ", "ERR");
                        return;
                    }

                    //ảnh

                    if (_anhser.GetAnh().Any(c => c.DuongDan == cbo_anh.Text) == false)
                    {
                        MessageBox.Show("Đường Dẫn Không Hợp Lệ", "ERR");
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
                        MessageBox.Show("Tên chất liệu Không Hợp Lệ", "ERR");
                        return;
                    }

                    // quốc gia

                    if (_quocgiaser.GetQuocGia().Any(c => c.Ten == cbo_tenquocgia.Text) == false)
                    {
                        MessageBox.Show("Tên Quốc Gia Không Hợp Lệ", "ERR");
                        return;
                    }
                    //Mã
                    if (_qlhhser.GetsList().Any(p => p.Ma == cbo_mahh.Text))
                    {
                        MessageBox.Show("Mã không được trùng", "ERR");
                        return;
                    }

                    if (check() == false)
                    {
                        return;
                    }

                    {
                        _qlhhser.addcthanghoa(new ChiTietHangHoaThemViewModels()

                        {
                            IdSp = Sp(),
                            SoLuongTon = Convert.ToInt32(txt_soluong.Text),
                            GiaNhap = Convert.ToDecimal(txt_gianhap.Text),
                            GiaBan = Convert.ToDecimal(txt_giaban.Text),
                            IdChatLieu = _chatlieuser.GetChatLieu().Where(c => c.Ten == cbo_tencl.Text).Select(c => c.Id).FirstOrDefault(),
                            IdLoaiGiay = _loaigiayser.GetLoaiGiay().Where(c => c.Ten == cbo_loaigiay.Text).Select(c => c.Id).FirstOrDefault(),
                            IdQuocGia = _quocgiaser.GetQuocGia().Where(c => c.Ten == cbo_tenquocgia.Text).Select(c => c.Id).FirstOrDefault(),
                            IdSizeGiay = _sizegiayser.GetSizeGiay().Where(c => c.SoSize == Convert.ToDouble(cbo_sizegiay.Text)).Select(c => c.Id).FirstOrDefault(),
                            IdAnh = _anhser.GetAnh().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.ID).FirstOrDefault(),
                            Mavach = txt_mavach.Text

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
            }
            catch (Exception ex)
            {

                MessageBox.Show("Size giày không hợp lệ", "Liên Hệ Với Quân");
                return;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void pic_anhhanghoa_BackgroundImageChanged(object sender, EventArgs e)
        {
           
        }

        private void cbo_anh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image img1 = Image.FromFile(cbo_anh.Text);
            pic_anhhanghoa.Image = img1;
        }

        private void pic_nsx_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới xuất xứ Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_ThemNSX frm_QuocGia = new Frm_ThemNSX();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Xuất xứ Thôi Nào");

                    }
                    frm_QuocGia.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

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

        private void pic_anhadd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới Ảnh Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_Anh frm_Anh = new Frm_Anh();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Ảnh Thôi Nào");

                    }
                    frm_Anh.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới loại giày Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_ThemLoaiGiay frm_LoaiGiay = new Frm_ThemLoaiGiay();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới loại giày Thôi Nào");

                    }
                    frm_LoaiGiay.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới size giày Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_ThemSizeGiay frm_SizeGiay = new Frm_ThemSizeGiay();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới size giày Thôi Nào");

                    }
                    frm_SizeGiay.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

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

        private void pic_xuatxu_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới xuất xứ Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_ThemQuocGia frm_QuocGia = new Frm_ThemQuocGia();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới Xuất xứ Thôi Nào");

                    }
                    frm_QuocGia.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

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

        private void pic_cl_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới chất liệu Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_ThemChatLieu Frm_ChatLieu = new Frm_ThemChatLieu();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới chất liệu Thôi Nào");

                    }
                    Frm_ChatLieu.Show();


                };

                if (dialogResult == DialogResult.No)
                {
                    for (int a = 0; a < 2; a++)
                    {
                        this.AlertErr("Thất Bại");

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

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            if (txt_soluong.Text.All(Char.IsDigit) == false)
            {
                txt_soluong.Text = txt_soluong.Text.Substring(0, txt_soluong.Text.Length - 1);
            }
        }

        private void txt_gianhap_TextChanged(object sender, EventArgs e)
        {
            if (txt_gianhap.Text.All(Char.IsDigit) == false)
            {
                txt_gianhap.Text = txt_gianhap.Text.Substring(0, txt_gianhap.Text.Length - 1);
            }
        }

        private void txt_giaban_TextChanged(object sender, EventArgs e)
        {
            if (txt_giaban.Text.All(Char.IsDigit) == false)
            {
                txt_giaban.Text = txt_giaban.Text.Substring(0, txt_giaban.Text.Length - 1);
            }
        }
    }
}
