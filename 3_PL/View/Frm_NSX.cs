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
    public partial class Frm_NSX : Form
    {
        private INsxServices insx;
        private NsxViewModels viewnsx;

        
        public Frm_NSX()
        {
            InitializeComponent();
            insx = new NsxServices();
            viewnsx = new NsxViewModels();
            loadData();
        }

        public void loadData()
        {
            dgv_showsize.Rows.Clear();
            dgv_showsize.ColumnCount = 5;
            dgv_showsize.Columns[0].Name = "ID";
            dgv_showsize.Columns[0].Visible= false;
            dgv_showsize.Columns[1].Name = "Mã";
            dgv_showsize.Columns[2].Name = "Tên nhà sản xuất";
            dgv_showsize.Columns[3].Name = "Trạng thái";
            var lstnssx = insx.GetNhasanxuat();
            foreach (var item in lstnssx)
            {
                dgv_showsize.Rows.Add(item.Id,item.Ma,item.Ten,item.TrangThai);
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void dgv_showsize_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            NsxViewModels x = new NsxViewModels()
            {
                Id = Guid.NewGuid(),
                Ma = tb_ma.Text,
                Ten = tb_ten.Text
            };
            MessageBox.Show(insx.add(x));
            loadData();
        }

        private void tb_sosize_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
