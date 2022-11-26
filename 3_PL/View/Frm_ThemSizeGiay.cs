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
    public partial class Frm_ThemSizeGiay : Form
    {
        public ISizeGiayServices sizeGiayServices;
        public Frm_ThemSizeGiay()
        {
            InitializeComponent();
            sizeGiayServices = new SizeGiayServices();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rd_ch.Checked && !rd_hh.Checked)
            {
                MessageBox.Show("Mời chọn trạng thái");
            }
            SizeGiayViewModels sg = new SizeGiayViewModels();
            sg.Id = new Guid();
            sg.Ma = tb_Ma.Text;
            sg.SoSize = Convert.ToInt32(tb_ten.Text);
            sg.TrangThai = rd_ch.Checked ? 1 : 0;
            MessageBox.Show(sizeGiayServices.add(sg));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
