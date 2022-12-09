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

        private SaleViewModel viewsale;
        private ISaleService isale;

        public FrmSale()
        {
            InitializeComponent();
            isale = new SaleService();
            viewsale = new SaleViewModel();
            //loadData();
        }

        public void loadData()
        {
            dgv_show.Rows.Clear();
            dgv_show.ColumnCount = 7;
            dgv_show.Columns[0].Name = "ID";
            dgv_show.Columns[0].Visible = false;
            dgv_show.Columns[1].Name = "Mã giảm giá";
            dgv_show.Columns[2].Name = "Tên chương trình";
            dgv_show.Columns[3].Name = "Giảm giá";
            dgv_show.Columns[4].Name = "Ngày bắt đầu";
            dgv_show.Columns[5].Name = "Ngày kết thúc";
            dgv_show.Columns[6].Name = "Trạng thái";
            var lstsale = isale.GetDanhMuc();
            foreach (var item in lstsale)
            {
                dgv_show.Rows.Add(item.Id, item.MaGiamGia, item.TenChuongTrinh, item.SoTienGiamGia, item.NgayBatDau, item.NgayKetThuc,
                        item.TrangThai == 1 ? "Còn hạn " : "Hết hạn");
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
                if (dgvr.Cells[6].Value.ToString() == "Hết hạn")
                {
                    rdb_con.Checked = true;
                }
                else
                {
                    rdb_ngung.Checked = true;
                }
            }
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
                SoTienGiamGia = Convert.ToInt32(tb_sotiengiamgia.Text),
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
            viewsale.SoTienGiamGia = Convert.ToInt32(tb_sotiengiamgia.Text);
            viewsale.TrangThai = rdb_con.Checked ? 1 : 0;
            if (isale.update(viewsale))
            {
                MessageBox.Show("Sua Thanh Cong");
            };
            loadData();

        }
        private void btn_xoa_Click_1(object sender, EventArgs e)
        {

        }
    }
}

