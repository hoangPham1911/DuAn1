using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.Service;
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
    public partial class FrmSale : Form
    {
        private IQlyHangHoaServices iqlhh;

        public FrmSale()
        {
            InitializeComponent();
            iqlhh = new QlyHangHoaServices();
            loadData();
            loadComboBox();
        }

        public void loadData()
        {
            dgv_show.Rows.Clear();
            dgv_show.ColumnCount = 7;
            dgv_show.Columns[0].Name = "ID";
            dgv_show.Columns[0].Visible = false;
            dgv_show.Columns[1].Name = "Mã";
            dgv_show.Columns[2].Name = "Tên sản phẩm";
            dgv_show.Columns[3].Name = "Size";
            dgv_show.Columns[4].Name = "Giá bán";
            dgv_show.Columns[5].Name = "Số lượng";
            dgv_show.Columns[6].Name = "Trạng thái";
            var lstcthh = iqlhh.GetsList();
            foreach (var item in lstcthh)
            {
                dgv_show.Rows.Add(item.Id, item.Ma, item.Ten,item.IdSizeGiay,
                    item.GiaBan,item.SoLuongTon, item.TrangThai == 1 ? "Còn sản xuất" : "Ngừng sản xuất");
            }
            dgv_show.AllowUserToAddRows = false;
        }

        private void dgv_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgv_show.Rows[e.RowIndex];
              //  vmqlyhanghoa = iqlhh.GetsList().FirstOrDefault(x => x.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
               // cbb_tengiay.Text = vmqlyhanghoa.Ten;
                //vmqlyhanghoa.GiaBan = tb_gia.Text ;
                if (dgvr.Cells[3].Value.ToString() == "Còn sản xuất")
                {
                    rdb_con.Checked = true;
                }
                else
                {
                    rdb_ngung.Checked = true;
                }
            }
        }

        public void loadComboBox()
        {
            foreach (var item in iqlhh.GetsList())
            {
                cbb_tengiay.Items.Add(item.Ten);
            }
            
        }

        private void cbb_tengiay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
