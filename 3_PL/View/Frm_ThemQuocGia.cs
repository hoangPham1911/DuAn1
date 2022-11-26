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
    public partial class Frm_ThemQuocGia : Form
    {
        public IQuocGiaServices quocGiaServices;
        public Frm_ThemQuocGia()
        {
            InitializeComponent();
            quocGiaServices = new QuocGiaServices();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rd_ch.Checked && !rd_hh.Checked)
            {
                MessageBox.Show("Mời chọn trạng thái");
            }
            QuocGiaViewModels qg = new QuocGiaViewModels();
            qg.Id = new Guid();
            qg.Ma = tb_Ma.Text;
            qg.Ten = tb_ten.Text;
            qg.TrangThai = rd_ch.Checked ? 1 : 0;
            MessageBox.Show(quocGiaServices.add(qg));
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
