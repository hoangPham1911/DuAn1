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
    public partial class FrmSale : Form
    {
        private IQlyHangHoaServices iqlhh;
        private SaleViewModel viewsale;
        private QlyHangHoaViewModels viewqlhh;
        private ISaleService isale;

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
                dgv_show.Rows.Add(item.Id, item.Ma, item.Ten, item.IdSizeGiay,
                    item.GiaBan, item.SoLuongTon, item.TrangThai == 1 ? "Còn sản xuất" : "Ngừng sản xuất");
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

        }

        private void cbb_tengiay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            SaleViewModel x = new SaleViewModel()
            {
                Id = Guid.NewGuid(),
                MaGiamGia = tb_ma.Text,
                TenChuongTrinh = tb_tenct.Text,
                NgayBatDau = dt_ngaybatdau.Value,
                NgayKetThuc = dt_ngayketthuc.Value,
                GiamGia = cbb_ma.Text,
                TrangThai = rdb_con.Checked ? 1 : 0
            };
            if (isale.add(x))
            {
                MessageBox.Show("Them Thanh Cong");
            };

            loadData();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            viewsale.MaGiamGia = tb_ma.Text;
            viewsale.TenChuongTrinh = tb_tenct.Text;
            viewsale.NgayBatDau = dt_ngaybatdau.Value;
            viewsale.NgayKetThuc = dt_ngayketthuc.Value;
            viewsale.GiamGia = tb_sotiengiam.Text;
            viewsale.TrangThai = rdb_con.Checked ? 1 : 0;
            if (isale.update(viewsale))
            {
                MessageBox.Show("Sua Thanh Cong");
            };
            loadData();

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (viewsale == null)
            {

            }
        }
    }
}
