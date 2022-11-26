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
    public partial class Frm_ThemNSX : Form
    {
        public INsxServices nsxServices;
        public Frm_ThemNSX()
        {
            InitializeComponent();
            nsxServices = new NsxServices();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rd_ch.Checked && !rd_hh.Checked)
            {
                MessageBox.Show("Mời chọn trạng thái");
            }
            NsxViewModels nsx = new NsxViewModels();
            nsx.Id = new Guid();
            nsx.Ma = tb_Ma.Text;
            nsx.Ten = tb_ten.Text;
            nsx.TrangThai = rd_ch.Checked ? 1 : 0;
            MessageBox.Show(nsxServices.add(nsx));
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
