using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Service;
using _2_BUS.Services;
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
using System.Windows.Forms.Design;

namespace _3_PL.View
{
    public partial class FrmDangNhap : Form
    {
        INhanVienServices inhanvien;
        IChucVuServices ichucVu;
        public static Guid _IdStaff;
        private string pass = string.Empty;
        IHoaDonService _hoaDonService;
        IGiaoCaServices giaoCaServices;
        public FrmDangNhap()
        {
            InitializeComponent();
            inhanvien = new NhanVienServices();
            ichucVu = new ChucVuServices();
            _hoaDonService = new HoaDonService();
            giaoCaServices = new GiaoCaServices();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bt_dangnhap_Click(object sender, EventArgs e)
        {
            //var logiN = inhanvien.GetAll().Where(p => p.Ma == tb_tenguoidung.Text && p.MatKhau == tb_mk.Text).FirstOrDefault();
            //if (logiN != null)
            //{
            //    _IdStaff = logiN.Id;

            //    this.Hide();
            //    FormMain formMain = new FormMain();
            //    formMain.ShowDialog();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Đăng nhập thất bại");
            //}

            if (!string.IsNullOrEmpty(tb_tenguoidung.Text.Trim()) && !string.IsNullOrEmpty(tb_mk.Text.Trim()))
            {
                var user = inhanvien.Login(tb_tenguoidung.Text.Trim(), tb_mk.Text.Trim());
                _IdStaff = user.Id;
                if (user != null)
                {
                    if(giaoCaServices.GetAll().Count() != 0)
                    {
                        GiaoCaViewModels giaoCa = new GiaoCaViewModels();
                        giaoCa.IdNvNhanCaTiep = _IdStaff;
                        giaoCa.IdNvTrongCa = _IdStaff;
                        giaoCa.ThoiGianNhanCa = DateTime.Now;
                        giaoCa.TrangThai = 1;
                        giaoCaServices.Them(giaoCa);

                    }
                    else
                    {
                        GiaoCaViewModels giaoCaa = giaoCaServices.GetAll().FirstOrDefault(p => p.Id == _IdStaff);
                        giaoCaa.IdNvNhanCaTiep = _IdStaff;
                        giaoCaa.ThoiGianNhanCa = DateTime.Now;
                        giaoCaa.ThoiGianGiaoCa = DateTime.Now;
                        giaoCaa.TrangThai = 1;
                        giaoCaServices.Sua(giaoCaa);
                        
                    }
                    
                    foreach (var item in _hoaDonService.Get().Where(p=>p.IdNv == user.Id))
                    {
                        item.TongSoTienTrongCa = 0;
                        _hoaDonService.UpdateSoTienNvTrongCa(item);
                    }
                    this.Hide();
                    Helpers.AccoutHelper.Instance.SetUserLogin(user);
                    var frmMain = new FormMain();
                    frmMain.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
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

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked)
            {
                tb_mk.PasswordChar = '\0';
            }
            else
            {
                tb_mk.PasswordChar = '*';
            }
        }
    }
}
