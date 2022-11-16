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
    public partial class Frm_SizeGiay : Form
    {
        private ISizeGiayServices isize;
        private List<SizeGiayViewModels> lstSG;
        private SizeGiayViewModels sizeviewm;
        private Guid idSz;
        public Frm_SizeGiay()
        {
            InitializeComponent();
            isize = new SizeGiayServices();
            lstSG = new List<SizeGiayViewModels>();
            sizeviewm = new SizeGiayViewModels();
            loadData();
        }

        public void loadData()
        {
            dgv_showsize.Rows.Clear();
            dgv_showsize.ColumnCount = 4;
            dgv_showsize.Columns[0].Name = "Id";
            dgv_showsize.Columns[0].Visible = false;
            dgv_showsize.Columns[1].Name = "Mã";
            dgv_showsize.Columns[2].Name = "Số size";
            dgv_showsize.Columns[3].Name = "Trạng thái ";
            var lst = isize.GetSizeGiay();
            if (tb_timkiem.Text != "")
            {
                lst = lst.Where(p => p.Ma.ToLower().Contains(tb_timkiem.Text)).ToList();
            }
            foreach (var item in lst)
            {
                dgv_showsize.Rows.Add(item.Id, item.Ma, item.SoSize,item.TrangThai);
            }
        }

        

        private void dgv_showsize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgv_showsize.Rows[e.RowIndex];
                sizeviewm = isize.GetSizeGiay().FirstOrDefault(p => p.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
                tb_ma.Text = sizeviewm.Ma;
                   
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            SizeGiayViewModels x = new SizeGiayViewModels()
            {
                Id = idSz,
                Ma = tb_ma.Text,
             
            };
            MessageBox.Show(isize.add(x));
            loadData();
        }

        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void dgv_showsize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_SizeGiay_Load(object sender, EventArgs e)
        {

        }
    }
}
