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
        public FormMain()
        {
            InitializeComponent();

        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
        
                    currentButton = (Button)btnSender;               
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    btnCloseChildForm.Visible = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new FormBanHang(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_HoaDon(), sender);
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHangHoa(), sender);
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
            btnCloseChildForm.Visible = false;
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
    }
}
