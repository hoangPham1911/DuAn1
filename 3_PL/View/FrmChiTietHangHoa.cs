using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using _3_GUI_PresentaionLayers;
using AForge.Video.DirectShow;
using Microsoft.Data.SqlClient;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Printing;
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
        ChiTietHangHoaUpdateViewModels cthh = new ChiTietHangHoaUpdateViewModels();
        private Guid zen;
        private Guid? zennsx;
        private Guid zendanhmuc;
        private string ok;
        private Guid id;
        private Guid idcthh;
        public FrmChiTietHangHoa(Guid idhh, Guid idcthh, string mahh, string tenhh, string nsx, string trangthai, string soluong,
            string gianhap, string giaban, string chatlieu, string sizegiay, string loaigiay, string tenquocgia, string anh)
        {
            _qlhhser = new QlyHangHoaServices();
            _anhser = new AnhService();
            _nsxser = new NsxServices();
            _chatlieuser = new ChatLieuServices();
            _quocgiaser = new QuocGiaServices();
            _sizegiayser = new SizeGiayServices();
            _loaigiayser = new LoaiGiayServices();
            InitializeComponent();
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
            loadnsx();
            loadchatlieu();
            loadsizegiay();
            loadloaigiay();
            loadquocgia();
            loaddpath();
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;

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
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Mở Camera Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbo_webcam.SelectedIndex].MonikerString);
                    videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                    videoCaptureDevice.Start();

                    tmrTime.Start();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex), "Liên Hệ Với 19008198 để sửa lỗi");
                return;
            }
        }

        void reset()
        {
            cbo_tenhh.Text = "";
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
                            Mavach = createQR()

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

        private void pic_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                
                this.Close();


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
        private string createQR()
        {
            return idcthh + "\n" + tenhh.ToString() + "\n" + mahh.ToString() + "\n" + id + "\n" + nsx.ToString() + "\n" + trangthai.ToString() + "\n" + soluong.ToString() + "\n" +
                decimal.Parse(giaban).ToString() + "\n " + chatlieu.ToString() + "\n" + sizegiay.ToString() + "\n" + loaigiay.ToString() + "\n" + tenquocgia.ToString() + "\n" +anh;
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



        private void pic_loaigiay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới loại giày Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_LoaiGiay frm_LoaiGiay = new Frm_LoaiGiay();
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

        private void pic_xuatxu_DoubleClick(object sender, EventArgs e)
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

        private void pic_sizegiay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới size giày Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_SizeGiay frm_SizeGiay = new Frm_SizeGiay();
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

        private void pic_cl_DoubleClick(object sender, EventArgs e)
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

        private void pic_nsx_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới NSX Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_NSX frm_NSX = new Frm_NSX();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới NSX Thôi Nào");

                    }
                    frm_NSX.Show();


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

        private bool updatehh()
        {
            HangHoaViewModels product = new HangHoaViewModels();
            product.Id = id;
            product.Ma = cbo_mahh.Text;
            product.Ten = cbo_tenhh.Text;
            product.TrangThai = 1;
            product.IdNsx = _nsxser.GetNhasanxuat().Where(c => c.Ten == cbo_nsx.Text).Select(c => c.Id).FirstOrDefault();
            return _qlhhser.updatehanghoa(product);
        }


        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("bạn có muốn sửa hay không", "Thông Báo", MessageBoxButtons.YesNo);

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
                        MessageBox.Show("Tên chất liệu Không Hợp Lệ", "ERR");
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

                    if (updatehh())
                    {
                        cthh.Id = idcthh;
                        cthh.SoLuongTon = Convert.ToInt32(txt_soluong.Text);
                        cthh.Mavach = createQR();
                        cthh.GiaNhap = Convert.ToDecimal(txt_gianhap.Text);
                        cthh.GiaBan = Convert.ToDecimal(txt_giaban.Text);
                        cthh.IdChatLieu = _chatlieuser.GetChatLieu().Where(c => c.Ten == cbo_tencl.Text).Select(c => c.Id).FirstOrDefault();
                        cthh.IdLoaiGiay = _loaigiayser.GetLoaiGiay().Where(c => c.Ten == cbo_loaigiay.Text).Select(c => c.Id).FirstOrDefault();
                        cthh.IdQuocGia = _quocgiaser.GetQuocGia().Where(c => c.Ten == cbo_tenquocgia.Text).Select(c => c.Id).FirstOrDefault();
                        cthh.IdAnh = _anhser.GetAnh().Where(c => c.DuongDan == cbo_anh.Text).Select(c => c.ID).FirstOrDefault();
                        cthh.IdSizeGiay = _sizegiayser.GetSizeGiay().Where(c => c.SoSize == Convert.ToInt32(cbo_sizegiay.Text)).Select(c => c.Id).FirstOrDefault();
                    };
                    _qlhhser.updatehanghoact(cthh);
                    for (int i = 0; i < 2; i++)
                    {
                        this.Alert("Đã Xác Nhận Cập Nhật");

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

        private void pic_nsx_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mới NSX Hay Không  ?", "Thông Báo", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Frm_ThemNSX frm_LoaiGiay = new Frm_ThemNSX();
                    for (int i = 0; i < 1; i++)
                    {
                        this.Alert("Tiến Hành Tạo Mới NSX Thôi Nào");

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(createQR());
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Tạo Mã QR Không ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogResult)
            {
                QRCodeGenerator qRCode = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCode.CreateQrCode(createQR(), QRCodeGenerator.ECCLevel.L);
                QRCode qR = new QRCode(qRCodeData);
                Pic_QRcode.Image = qR.GetGraphic(5);
                for (int a = 0; a < 2; a++)
                {
                    this.Alert("Tạo Mã QR Thành Công");
                }
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;

            }
        }

        private void cbo_mahh_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                cthh.Id = idcthh;
                cthh.Mavach = createQR();
                if (_qlhhser.updateMaQR(cthh))
                {
                    for (int i = 0; i < 2; i++)
                    {

                        this.Alert("Thêm Mã Vạch Thành Công");

                    }
                }
                

            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.Alert("Thêm Mã Vạch Thất Bại ");

                }
                return;
            }
        }
        private void print(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Pic_QRcode.Width, Pic_QRcode.Height);
            Pic_QRcode.DrawToBitmap(bitmap, new Rectangle(0, 0, Pic_QRcode.Width, Pic_QRcode.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
            bitmap.Dispose();

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có in mã QR code thêm hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += print;
                pd.Document = printDocument;

                if (pd.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }


                return;
            }
            if (dialogResult == DialogResult.No)
            {
                for (int i = 0; i < 2; i++)
                {

                    this.AlertErr("Tạo File PDF Thất Bại ");

                }
                return;
            }
        }

        private void cbo_mahh_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void cbo_tenhh_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cbo_nsx_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            if (txt_soluong.Text.All(Char.IsDigit) == false)
            {
                txt_soluong.Text = txt_soluong.Text.Substring(0, txt_soluong.Text.Length - 1);
            }
        }

        private void cbo_anh_TextChanged(object sender, EventArgs e)
        {
            
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

        private void cbo_tencl_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbo_sizegiay_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cbo_tenquocgia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbo_loaigiay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
          
            if (pic_cammera.Image != null)
            {
                Bitmap bitmap = (Bitmap)pic_cammera.Image;
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(bitmap);

                if (result != null)
                {
                    string decoded = result.ToString().Trim();
                    string[] maQR = decoded.Split(new char[] { '\n' });
                    if (_qlhhser.GetsList().FirstOrDefault(p => p.Id == Guid.Parse(maQR[0])) != null)
                    {
                        idcthh = Guid.Parse(maQR[0]);
                        cbo_tenhh.Text = maQR[1].ToString();
                        cbo_mahh.Text = maQR[2].ToString();
                        id = Guid.Parse(maQR[3]);
                        cbo_nsx.Text = maQR[4].ToString();
                        if (maQR[5].ToString() == "Còn Hàng")
                        {
                            chk_conhang.Checked = true;
                        }
                        else
                        {
                            chk_hethang.Checked = true;
                        }
                        txt_soluong.Text = maQR[6];
                        txt_giaban.Text = maQR[7];
                        cbo_tencl.Text = maQR[8];
                        cbo_sizegiay.Text = maQR[9];
                        cbo_loaigiay.Text = maQR[10];
                        cbo_tenquocgia.Text = maQR[11];
                        cbo_anh.Text = maQR[12];
                        MessageBox.Show("Thêm Sp Thành Công");
                    }

                }
            }
        }

        private void pic_anhhanghoa_Click(object sender, EventArgs e)
        {

        }

        private void pic_cl_Click(object sender, EventArgs e)
        {

        }

        private void pic_xuatxu_Click(object sender, EventArgs e)
        {

        }
    }
}
