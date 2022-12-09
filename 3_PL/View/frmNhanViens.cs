using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using _2_BUS.Service;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using _1_DAL.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using DocumentFormat.OpenXml.Spreadsheet;

namespace _3_PL.View
{
    public partial class frmNhanViens : Form
    {
        private INhanVienServices _iNhanVienService;
        private IChucVuServices _iChucVuService;
        private List<NhanVienViewModels> dataNhanVienViewModels;
        private List<ChucVuViewModels> dataChucVuViewModels;
        private NhanVienViewModels objSelected;

        private ACTION_CLICK _actionClick = ACTION_CLICK.NONE;
        private const string caption = "Thông báo";



        //Mã OTP
        private const string mailAddress = "tranvantien6620@gmail.com";
        private const string fromPass = "iekmmjfguxfgtzia";
        private const string subjectMail = "OTP code";
        private int _code;
        private static int _countSteps = 0;
        private static Timer _timer;
        private static frmNhanViens _instance;


        public frmNhanViens()
        {
            InitializeComponent();
            _instance = this;
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var timKiem = txtTimKiem.Text;
            var rutl = dataNhanVienViewModels.FirstOrDefault(nv => nv.Ma == timKiem);
            dgvNhanVien.DataSource = dataNhanVienViewModels;
            dgvNhanVien.DataSource = dataNhanVienViewModels;
        }

        //Mã OTP//
        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            sendOTP();
        }
        private static void timerTick(object myObject, EventArgs e)
        {
            _countSteps++;
            if (_countSteps > 60)
            {
                stopTimer();
                var confirmMessage = MessageBox.Show("Mã OTP đã hết hiệu lực\nBạn có muốn lấy lại mã OTP không?",
                    "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                if (confirmMessage == DialogResult.Retry)
                {
                    _instance.sendOTP();
                }
            }
        }
        private void sendOTP()
        {
            //try
            //{
            //    var random = new Random();
            //    _code = random.Next(100000, 1000000);
            //    var fromMail = new MailAddress(mailAddress);
            //    var toMail = new MailAddress(txtMailAddress.Text.Trim());

            //    var smtp = new SmtpClient
            //    {
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        EnableSsl = true,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        UseDefaultCredentials = false,
            //        Credentials = new NetworkCredential(fromMail.Address, fromPass),
            //        Timeout = 20000
            //    };
            //    using (var message = new MailMessage(fromMail, toMail)
            //    {
            //        Subject = subjectMail,
            //        Body = $"Mã OTP của bạn là: {_code}\nMã OTP có hiệu lực trong 60s"
            //    })
            //    {
            //        smtp.Send(message);
            //    }
            //    MessageBox.Show($"Send OTP thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    startTimer();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Send OTP thất bại\n{ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    enableControl(false);
            //}
        }

        private void confirmOTP()
        {
         //  var codeConfirm = txtOTP.Text.Trim();
            //if (_code.ToString().Equals(codeConfirm) && _timer != null)
            //{
            ////    // cho phép làm gì đó
            ////    MessageBox.Show("Đăng nhập thành công !!!", "Thông báo",
            ////        MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    stopTimer();
            ////}
            ////else if (_code.ToString().Equals(codeConfirm) && _timer == null)
            ////{
            ////    // OTP đã hết hạn
            ////    var confirmMessage = MessageBox.Show("Mã OTP đã hết hiệu lực !!!\nBạn có muốn nhận lại OTP không?",
            ////        "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
            ////    if (confirmMessage == DialogResult.Retry)
            ////    {
            ////        sendOTP();
            ////    }
            //}
            //else
            //{
            //    MessageBox.Show("Mã OTP không đúng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private static void startTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += timerTick;
            _timer.Start();
            _instance.enableControl(true);
        }

        private static void stopTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer = null;
                _countSteps = 0;
            }
            _instance.enableControl(false);
        }
        private void enableControl(bool isEnable)
        {
     //       txtOTP.Enabled = btnXacNhan.Enabled = isEnable;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            confirmOTP();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            _actionClick = ACTION_CLICK.ADD;
            clearForm();
            cmChucVu.SelectedIndex = 0;
            enableControlInput(true);
            visibleButton(true);
         
        }
        private byte[] ChonAnh()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pckAnh.Image.Save(ms, pckAnh.Image.RawFormat);
                byte[] img = ms.ToArray();
                return img;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            _actionClick = ACTION_CLICK.UPDATE;
            visibleButton(true);
            enableControlInput(true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enableControlInput(bool isEnable)
        {
            txtMa.Enabled = txtCCD.Enabled = txtEmail.Enabled
                = txtHo.Enabled = txtEmail.Enabled
                = txtQueQuan.Enabled = txtSDT.Enabled
                = txtTen.Enabled = txtTenDem.Enabled
                = dtpNamSinh.Enabled = cmChucVu.Enabled
                = cbTrangThai.Enabled = rdNam.Enabled = pckAnh.Enabled
                = rdNu.Enabled = isEnable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void visibleButton(bool isVisible)
        {
            //btnClear.Visible = btnLuu.Visible = isVisible;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearForm()
        {
            txtCCD.Text = txtEmail.Text = txtHo.Text
                = txtMa.Text = txtMatKhau.Text
                = txtQueQuan.Text = txtSDT.Text
                = txtTen.Text = txtTenDem.Text
                = String.Empty;
            dtpNamSinh.Value = DateTime.Now;
            //cmChucVu.SelectedIte
            rdNam.Checked = true;
            txtTen.Focus();
            cmChucVu.SelectedIndex = 0;
            pckAnh.Image = null;

        }

        private void bindingData()
        {
            if (dataNhanVienViewModels != null)
            {
                dataNhanVienViewModels.Clear();
            }
            dataNhanVienViewModels = _iNhanVienService.GetAll();
            this.dgvNhanVien.DataSource = dataNhanVienViewModels;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        public Image ConvertByteArrayToImg(byte[] data)
        {
            if (data == null) return null;
            else
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    if (ms == null) return null;
                    else
                        return Image.FromStream(ms);
                }
            }
        }
        private void bindingDataForControl(NhanVienViewModels obj)
        {
            this.txtMa.Text = obj.Ma;
            this.txtTen.Text = obj.Ten;
            this.txtCCD.Text = obj.CMND;
            this.txtEmail.Text = obj.Email;
            this.txtHo.Text = obj.Ho;
            this.txtMatKhau.Text = obj.MatKhau;
            this.txtSDT.Text = obj.Sdt;
            this.txtTenDem.Text = obj.TenDem;
            this.dtpNamSinh.Text = Convert.ToString(obj.NamSinh);
            this.txtQueQuan.Text = obj.QueQuan;
           

            var chucVu = dataChucVuViewModels.Where(x => x.Id.ToString() == obj.IdCv?.ToString()).FirstOrDefault();
            if (chucVu != null)
            {
                cmChucVu.SelectedItem = chucVu;
            }

            this.rdNam.Checked = obj.GioiTinh == "Nam";
            this.rdNu.Checked = obj.GioiTinh == "Nữ";

            this.cbTrangThai.Checked = (obj.TrangThai != null && obj.TrangThai == 0); // TrangThai = 0 -> nhan vien con hoat dong


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getForm()
        {
            if (objSelected == null)
            {
                objSelected = new NhanVienViewModels();
            }
            objSelected.Ten = txtTen.Text;
            objSelected.Ma = txtMa.Text;
            objSelected.Email = txtEmail.Text;
            objSelected.CMND = txtCCD.Text;
            objSelected.Ho = txtHo.Text;
            objSelected.TenDem = txtTenDem.Text;
            objSelected.QueQuan = txtQueQuan.Text;
            objSelected.MatKhau = txtMatKhau.Text;
            objSelected.Sdt = txtSDT.Text;
            var idChucVu = cmChucVu.SelectedValue;
            objSelected.IdCv = Guid.Parse(idChucVu.ToString());
            objSelected.TrangThai = cbTrangThai.Checked ? 0 : 1;
            objSelected.NamSinh = dtpNamSinh.Value.Date;
            objSelected.GioiTinh = rdNam.Checked ? "Nam" : "Nữ";
            objSelected.Anh = ChonAnh();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            getForm();
            if (objSelected != null)
            {
                var mess = string.Empty;
                var result = true;
                var resultConfirm = DialogResult.No;
                if (_actionClick == ACTION_CLICK.ADD)
                {
                    mess = $"Bạn có chắc chắn muốn thêm mới nhân viên {objSelected.HoTen} không ?";
                    resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultConfirm == DialogResult.Yes)
                    {
                        result = _iNhanVienService.Them(objSelected);
                        if (result)
                        {
                            mess = $"Thêm mới nhân viên {objSelected.HoTen} thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            mess = $"Thêm mới nhân viên {objSelected.HoTen} không thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (_actionClick == ACTION_CLICK.UPDATE)
                {
                    mess = $"Bạn có chắc chắn muốn sửa nhân viên {objSelected.HoTen} không ?";
                    resultConfirm = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultConfirm == DialogResult.Yes)
                    {
                        result = _iNhanVienService.Sua(objSelected);
                        if (result)
                        {
                            mess = $"Sửa nhân viên {objSelected.HoTen} thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            mess = $"Sửa nhân viên {objSelected.HoTen} không thành công !!!";
                            MessageBox.Show(mess, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                if (result)
                {
                    enableControlInput(false);
                    visibleButton(false);
                    _actionClick = ACTION_CLICK.NONE;
                    loadData();
                }
            }
        }

        private void frmNhanViens_Load(object sender, EventArgs e)
        {

            _iNhanVienService = new NhanVienServices();
            _iChucVuService = new ChucVuServices();
            dataNhanVienViewModels = new List<NhanVienViewModels>();
            dataChucVuViewModels = new List<ChucVuViewModels>();

            enableControlInput(false);

            loadDataChucVu();
            loadData();
            var cv = _iChucVuService.GetChucVu().FirstOrDefault(p => p.IdNv == FrmDangNhap._IdStaff);
            if (cv.Ten == "Nhân viên")
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void loadData()
        {
            bindingData();

            if (dataNhanVienViewModels.Count > 0)
            {
                objSelected = dataNhanVienViewModels[0];
                bindingDataForControl(objSelected);
            }
        }

        private void loadDataChucVu()
        {
            dataChucVuViewModels = _iChucVuService.GetAll().Where(x => x.TrangThai == 0).ToList();
            cmChucVu.DataSource = dataChucVuViewModels;
            cmChucVu.ValueMember = "Id";
            cmChucVu.DisplayMember = "Ten";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            this.pckAnh.Image = ConvertByteArrayToImg((byte[])row.Cells[14].Value);
            objSelected = dataNhanVienViewModels[e.RowIndex];
            if (objSelected != null)
            {
                bindingDataForControl(objSelected);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var resultConfirm = MessageBox.Show($"Bạn có chắc chắn muốn giao ca {objSelected.Ten} không?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultConfirm == DialogResult.Yes)
            {
                var result = _iNhanVienService.Xoa(objSelected.Id);
                if (result)
                {
                    MessageBox.Show($"Xoá thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show($"Xoá giao ca không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnGiaoCa_Click(object sender, EventArgs e)
        {
            var formGiaoCa = new frmGIaoCa();
            formGiaoCa.Show();
            this.Close();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opt = new OpenFileDialog();
            opt.Filter = "Chon Anh(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opt.ShowDialog() == DialogResult.OK)
            {
                pckAnh.Image = Image.FromFile(opt.FileName);
            }
        }

        private void pckAnh_Click(object sender, EventArgs e)
        {

        }
    }

    enum ACTION_CLICK
    {
        NONE,
        ADD,
        UPDATE
    }
}