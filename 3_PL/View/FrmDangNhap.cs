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
        INhanVienServices inhanvien;
        IChucVuServices ichucVu;
        public static Guid _IdStaff;

        public FrmDangNhap()
        {
            InitializeComponent();
            inhanvien = new NhanVienServices();
            ichucVu = new ChucVuServices();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_dangnhap_Click(object sender, EventArgs e)
        {

            var logiN = inhanvien.GetAll().Where(p => p.Ma == tb_tenguoidung.Text && p.MatKhau == tb_mk.Text).FirstOrDefault();
            if (logiN != null)
            {
                this.Hide();
                FormMain formMain = new FormMain();
                formMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ?", "Cảnh báo!!!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
