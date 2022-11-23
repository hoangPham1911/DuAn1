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
    public partial class FrmDangKy : Form
    {
        public INhanVienServices nhanVienServices;
        public IChucVuServices chucVuServices;


        public FrmDangKy()
        {
            InitializeComponent();
            nhanVienServices = new NhanVienServices();
            chucVuServices = new ChucVuServices();
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
            var nhanvien = new NhanVienViewModels()
            {
                Id = new Guid(),
                Ho = tb_ho.Text,
                TenDem = tb_tenDem.Text,
                Ten = tb_ten.Text,
                Email = tb_email.Text,
                Sdt = tb_sdt.Text,
                MatKhau = tb_mk.Text,
                Ma = tb_ma.Text,
                QueQuan = tb_queQuan.Text,
                CMND = tb_cccd.Text,
                NamSinh = dtpNamSinh.Value,
                GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                IdCv = chucvu.Id,
            };
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
            else if (tb_mk.Text == tb_nhaplaiMK.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu sai");
            }
            else
            {
                if (nhanVienServices.Them(nhanvien) == true)
                {
                    MessageBox.Show("Đăng ký thành công");
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại");
                }
            }


        }
    }
}
