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
using System.Text.RegularExpressions;
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
            load();
            comboBox1.Enabled = false;
        }
        private void load()
        {
            foreach (var item in bangQuyDoiDiemServices.Get())
            {
                comboBox1.Items.Add(item.Ten);
            }
        }
        private Guid ViDiem()
        {
            ViDiemViewModel vi = new ViDiemViewModel();
            vi.TrangThai = 1;
            vi.TongDiem = 0;
            if (bangQuyDoiDiemServices.Get().FirstOrDefault(p => p.Ten.Contains(1.ToString())) != null)
                vi.IdQuyDoiDiem = bangQuyDoiDiemServices.GetDiemQuyDoi().FirstOrDefault(p => p.Ten.Contains(comboBox1.Text.ToString())).Id;
            //     MessageBox.Show(vi.IdQuyDoiDiem.ToString());
            return viDiemService.getId(vi);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm khách hàng không?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (txtMaKH.Text == "" && txtTenKH.Text == "" && tb_SoCCCD.Text == "" && txtDT.Text == "" && txtDiaChi.Text == "" && txtEmail.Text == "")
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
                else if (!ckb_Nam.Checked && !ckb_nu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính");
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
                    kh.GioiTinh = ckb_Nam.Checked ? "Nam" : "Nữ";
                    kh.NamSinh = dtp_NamSinh.Value;
                    kh.TrangThai = rd_hd.Checked ? 1 : 0;
                    kh.IdVi = ViDiem();
                    MessageBox.Show(khachHangServices.ThemKhachHang(kh));
                }
            }
            else
            {

            }

            //



        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tb_SoCCCD_TextChanged(object sender, EventArgs e)
        {
            if (tb_SoCCCD.Text.All(Char.IsDigit) == false)
            {
                tb_SoCCCD.Text = tb_SoCCCD.Text.Substring(0, tb_SoCCCD.Text.Length - 1);
            }

        }

        private void txtDT_TextChanged(object sender, EventArgs e)
        {
            if (txtDT.Text.All(Char.IsDigit) == false)
            {
                txtDT.Text = txtDT.Text.Substring(0, txtDT.Text.Length - 1);
            }
        }

        private void ckb_Nam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_Nam.Checked)
            {
                ckb_Nam.Checked = true;
                ckb_nu.Checked = false;
            }

        }

        private void ckb_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_nu.Checked)
            {
                ckb_Nam.Checked = false;
                ckb_nu.Checked = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = 0.ToString();
            else if (bangQuyDoiDiemServices.Get().FirstOrDefault(p => p.Tong <= int.Parse(textBox1.Text)) != null)
            {
                if (int.Parse(textBox1.Text) >= bangQuyDoiDiemServices.Get().FirstOrDefault(p => p.Tong <= int.Parse(textBox1.Text)).Tong)
                {
                    comboBox1.Text = bangQuyDoiDiemServices.Get().FirstOrDefault(p => p.Tong <= int.Parse(textBox1.Text)).Ten;

                }
            }
            else
            {
                comboBox1.Text = "";
            }
            
        }
    }
}
