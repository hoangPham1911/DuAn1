using _1_DAL.Models;
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
        public IBangQuyDoiDiemServices bangQuyDoiDiemServices;
        public IViDiemService viDiemService;
        
        public Frm_ThemKhachHang()
        {
            khachHangServices = new KhachHangServices();
            bangQuyDoiDiemServices = new BangQuyDoiDiemServices();
            viDiemService = new ViDiemService();
            InitializeComponent();
        }
        private Guid ViDiem()
        {
            ViDiemViewModel vi = new ViDiemViewModel();
            vi.TrangThai = 1;
            vi.TongDiem = int.Parse(textBox1.Text);
            vi.IdQuyDoiDiem = bangQuyDoiDiemServices.Get().FirstOrDefault(p => p.Ten.Contains(1.ToString())).Id;
            MessageBox.Show(vi.IdQuyDoiDiem.ToString());
            return viDiemService.getId(vi);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" && txtTenKH.Text == "" && tb_SoCCCD.Text == "" && txtDT.Text == "" && txtDiaChi.Text == "" && txtEmail.Text == "" && tb_GioiTinh.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin");
            }
            else if (!rd_hd.Checked && !rd_koHd.Checked)
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
            }
            else if (khachHangServices.GetAllKhachHangDB().Any(p => p.Ten == txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
            }
            else
            {
                ThemKhachHangViewModels kh = new ThemKhachHangViewModels();
                kh.Ma = txtMaKH.Text + tb_SoCCCD.Text;
                kh.Ten = txtTenKH.Text;
                kh.SoCCCD = tb_SoCCCD.Text;
                kh.Sdt = txtDT.Text;
                kh.DiaChi = txtDiaChi.Text;
                kh.Email = txtEmail.Text;
                kh.GioiTinh = tb_GioiTinh.Text;
                kh.NamSinh = dtp_NamSinh.Value;
                kh.TrangThai = rd_hd.Checked ? 1 : 0;
                kh.IdVi = ViDiem();
                MessageBox.Show(khachHangServices.ThemKhachHang(kh));
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
