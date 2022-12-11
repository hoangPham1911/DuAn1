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
    public partial class FormMain : Form
    {
        private Form activeForm;
        private Button currentButton;
        private IChucVuServices ichucvu;
        private INhanVienServices inhanvien;
        public FormMain()
        {
            InitializeComponent();

            inhanvien = new NhanVienServices();
            ichucvu = new ChucVuServices();
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
        
                    currentButton = (Button)btnSender;               
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelhome.Controls.Add(childForm);
            this.panelhome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHangHoa(), sender);
            lblTitle.Text = "FormSanPham";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_HoaDon(), sender);
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThongKeDoanhThuNhanVien(), sender);
        }

        private void btn_quanlynhanvien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanViens(), sender);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_KhachHang(), sender);

        }
        private void Reset()
        {
     
            lblTitle.Text = "HOME";
            panelTitle.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            //btnCloseChildForm.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHangHoa(),sender);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormBanHang(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_HoaDon(), sender);
        }

        private void btn_quanlynhanvien_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanViens(), sender);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_KhachHang(), sender);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            var nv = inhanvien.GetAll().FirstOrDefault(p => p.Id == FrmDangNhap._IdStaff);
            if (nv != null)
            {
                textBox1.Text = nv.Ho + " " + nv.TenDem + " " + nv.Ten;
            }

            var cv = ichucvu.GetChucVu().FirstOrDefault(p => p.IdNv == FrmDangNhap._IdStaff);
            if (cv != null)
                textBox2.Text = cv.Ten;
            if (textBox2.Text == "Nhân viên")
            {
                button1.Enabled = btn_thongke.Enabled = false;
            }
            else
            {
                button2.Enabled = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ?", "Cảnh báo!!!", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSale(), sender);
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_NguoiDung(), sender);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLDiem(),sender);
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
