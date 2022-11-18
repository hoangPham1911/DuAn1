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
    public partial class Frm_ThemKhachHang : Form
    {
        public IKhachHangServices khachHangServices;
        
        
        public Frm_ThemKhachHang()
        {
            khachHangServices = new KhachHangServices();
            
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ThemKhachHangViewModels kh = new ThemKhachHangViewModels()
            {
                Ma = txtMaKH.Text + tb_SoCCCD.Text,
                Ten = txtTenKH.Text,
                SoCCCD = tb_SoCCCD.Text,
                Sdt = txtDT.Text,
                DiaChi = txtDiaChi.Text,
                Email = txtEmail.Text,
                GioiTinh = tb_GioiTinh.Text,
                NamSinh = dtp_NamSinh.Value,
                TrangThai = rd_hd.Checked ? 1 : 0,
            };
            MessageBox.Show(khachHangServices.ThemKhachHang(kh));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
