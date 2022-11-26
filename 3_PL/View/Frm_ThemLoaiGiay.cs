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
    public partial class Frm_ThemLoaiGiay : Form
    {
        public ILoaiGiayServices loaiGiayServices;
        public Frm_ThemLoaiGiay()
        {
            InitializeComponent();
            loaiGiayServices = new LoaiGiayServices();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rd_ch.Checked && !rd_hh.Checked)
            {
                MessageBox.Show("Mời chọn trạng thái");
            }
            LoaiGiayViewModels lg = new LoaiGiayViewModels();
            lg.Id = new Guid();
            lg.Ma = tb_Ma.Text;
            lg.Ten = tb_ten.Text;
            lg.TrangThai = rd_ch.Checked ? 1 : 0;
            MessageBox.Show(loaiGiayServices.add(lg));
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
