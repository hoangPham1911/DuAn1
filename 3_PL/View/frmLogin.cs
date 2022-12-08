using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Service;
using _2_BUS.Services;
using _2_BUS.ViewModels;

namespace _3_PL.View
{
    public partial class frmLogin : Form
    {
        private string pass = string.Empty;

        private INhanVienServices _iService;
        public frmLogin()
        {
            InitializeComponent();
            _iService = new NhanVienServices();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(pass.Trim()))
            {
                var user = _iService.Login(txtUserName.Text.Trim(), pass.Trim());
                if (user != null)
                {
                    Helpers.AccoutHelper.Instance.SetUserLogin(user);
                    var formNhanVien = new frmNhanViens();
                    formNhanVien.Show();
                    this.Visible = false;
                }
            }
        }

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtHienThiMatKhau.Visible = cbHienThiMatKhau.Checked;
            txtPasswork.Visible = !txtHienThiMatKhau.Visible;

            txtHienThiMatKhau.Text = pass;
            txtPasswork.Text = pass;
        }

        private void llQuanMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void txtPasswork_TextChanged(object sender, EventArgs e)
        {
            pass = txtPasswork.Text;
        }

        private void txtHienThiMatKhau_TextChanged(object sender, EventArgs e)
        {
            pass = txtHienThiMatKhau.Text;
        }

        private void llQuanMatKhau_Click(object sender, EventArgs e)
        {
            var quenMatKhau = new FormQuenMatKhau();
            quenMatKhau.Show();
            this.Visible = false;
        }
    }
}
