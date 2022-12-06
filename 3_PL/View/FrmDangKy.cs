using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;
using _1_DAL.Models;
using Org.BouncyCastle.Asn1.Cmp;

namespace _3_PL.View
{
    public partial class FrmDangKy : Form
    {
        public INhanVienServices nhanVienServices;
        public IChucVuServices chucVuServices;
        private const string mailAddress = "tranvantien6620@gmail.com";
        private const string fromPass = "iekmmjfguxfgtzia";
        private const string subjectMail = "OTP code";

        private int _code;
        private static int _countSteps = 0;
        private static Timer _timer;

        private static FrmDangKy _instance;
        private int xacnhan = 0;

        public FrmDangKy()
        {
            InitializeComponent();
            nhanVienServices = new NhanVienServices();
            chucVuServices = new ChucVuServices();
            _instance = this;
            loadCBB();
        }
        private void enableControl(bool isEnable)
        {
            tb_otp.Enabled = btn_xacnhan.Enabled = isEnable;
        }
        public void loadCBB()
        {
            foreach (var item in chucVuServices.GetAll())
            {
                cb_ChucVu.Items.Add(item.Ten);
            }
           
        }
        private void bt_dangky_Click(object sender, EventArgs e)
        {
            var chucvu = chucVuServices.GetAll().FirstOrDefault(x => x.Ten == cb_ChucVu.Text);
            var nhanvien = new NhanVienViewModels(){};
            nhanvien.Id = new Guid();
            nhanvien.Ho = tb_ho.Text;
            nhanvien.TenDem = tb_tenDem.Text;
            nhanvien.Ten = tb_ten.Text;
            nhanvien.Email = tb_email.Text;
            nhanvien.Sdt = tb_sdt.Text;
            nhanvien.MatKhau = tb_mk.Text;
            nhanvien.Ma = tb_ma.Text;
            nhanvien.QueQuan = tb_queQuan.Text;
            nhanvien.CMND = tb_cccd.Text;
            nhanvien.NamSinh = dtpNamSinh.Value;
            nhanvien.GioiTinh = rdNam.Checked ? "Nam" : "Nữ";
            nhanvien.IdCv = chucvu.Id;
            nhanvien.Anh = null;
            if (tb_ho.Text == "" && tb_tenDem.Text == "" && tb_ten.Text == "")
            {
                MessageBox.Show("Nhập họ và tên đầy đủ");
            }
            else if (tb_email.Text== "")
            {
                MessageBox.Show("Mời nhập email");
            }else if (tb_mk.Text == "")
            {
                MessageBox.Show("Ko đc để trống mật khẩu");
            }
            else if (tb_queQuan.Text == "")
            {
                MessageBox.Show("Mời nhập quê quán");
            }
            else if (tb_cccd.Text == "")
            {
                MessageBox.Show("Mời nhập cccd");
            }
            else if (cb_ChucVu.Text == "")
            {
                MessageBox.Show("Mời chọn chức vụ");
            }
            else if (tb_mk.Text != tb_nhaplaiMK.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu sai");
            }
            else if (tb_ma.Text == "")
            {
                MessageBox.Show("Mời nhập mã");
            }
            else if (nhanVienServices.GetAll().Any(p => p.Ten == tb_ma.Text))
            {
                MessageBox.Show("Mã đã tồn tại");
            }
            else if (xacnhan == 0)
            {
                MessageBox.Show("Vui lòng nhập và xác nhận mã OTP");
            }
            else if (!rdNam.Checked && !rdNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính");
            }
            else {
                if (nhanVienServices.Them(nhanvien) == true)
                {
                    MessageBox.Show("Đăng ký thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại");
                }
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_chonanh_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        ptb_anh.Image = Image.FromFile(ofd.FileName);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ThongBao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_gui_Click(object sender, EventArgs e)
        {
            sendOTP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            confirmOTP();
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
        private  void startTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += t_thoigian_Tick;
            _timer.Start();
            _instance.enableControl(true);
        }
        private void sendOTP()
        {
            try
            {
                var random = new Random();
                _code = random.Next(100000, 1000000);
                var fromMail = new MailAddress(mailAddress);
                var toMail = new MailAddress(tb_email.Text.Trim());

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromMail.Address, fromPass),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromMail, toMail)
                {
                    Subject = subjectMail,
                    Body = $"Mã OTP của bạn là: {_code}\nMã OTP có hiệu lực trong 60s"
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show($"Send OTP thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                startTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send OTP thất bại\n{ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enableControl(false);
            }
        }
        private void confirmOTP()
        {
            var codeConfirm = tb_otp.Text.Trim();
            if (_code.ToString().Equals(codeConfirm) && _timer != null)
            {
                // cho phép làm gì đó
                xacnhan = 1;
                MessageBox.Show("Đăng nhập thành công !!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                stopTimer();
            }
            else if (_code.ToString().Equals(codeConfirm) && _timer == null)
            {
                // OTP đã hết hạn
                var confirmMessage = MessageBox.Show("Mã OTP đã hết hiệu lực !!!\nBạn có muốn nhận lại OTP không?",
                    "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                if (confirmMessage == DialogResult.Retry)
                {
                    sendOTP();
                }
            }
            else
            {
                // OTP đang nhập không đúng
                MessageBox.Show("Mã OTP không đúng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void t_thoigian_Tick(object sender, EventArgs e)
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

        private void cb_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_cccd_TextChanged(object sender, EventArgs e)
        {
            if (tb_cccd.Text.All(Char.IsDigit) == false)
            {
                tb_cccd.Text = tb_cccd.Text.Substring(0, tb_cccd.Text.Length - 1);
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            if (tb_sdt.Text.All(Char.IsDigit) == false)
            {
                tb_sdt.Text = tb_sdt.Text.Substring(0, tb_sdt.Text.Length - 1);
            }
        }
    }
}
