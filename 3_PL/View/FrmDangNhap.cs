using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_PL.View
{
    public partial class FrmDangNhap : Form
    {
        INhanVienServices _NhanVienServices;
        public static Guid _IdStaff;

        public FrmDangNhap()
        {
            InitializeComponent();
            _NhanVienServices = new NhanVienServices();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_dangnhap_Click(object sender, EventArgs e)
        {

            NhanVienViewModels staff = _NhanVienServices.GetAll().FirstOrDefault(p => p.Ma.Contains(tb_tenguoidung.Text));

            try
            {
                var userName = _NhanVienServices.GetAll().FirstOrDefault(p => p.Ma == tb_tenguoidung.Text).Ma;
                var pass = _NhanVienServices.GetAll().FirstOrDefault(p => p.MatKhau == tb_mk.Text).MatKhau;

                if (staff.Ma == userName && staff.MatKhau == pass)
                {
                    _IdStaff = staff.Id;
                    FormMain formMain = new FormMain();
                    formMain.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Mật Khẩu bạn nhập không chính xác");
            }


        }

        private void linklb_quenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormQuenMatKhau frmqmk = new FormQuenMatKhau();
            frmqmk.Show();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDangKy frmdk = new FrmDangKy();
            frmdk.Show();
        }
    }
}
