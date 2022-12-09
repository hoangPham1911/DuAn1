using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.ViewModels;
using Org.BouncyCastle.Crypto;
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
            loadData();
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
            viewsale = isale.GetDanhMuc().FirstOrDefault(c => c.Id == Guid.Parse(dgv_show.CurrentRow.Cells[0].Value.ToString()));
            tb_ma.Text = dgv_show.CurrentRow.Cells[1].Value.ToString();
            tb_tenct.Text = dgv_show.CurrentRow.Cells[2].Value.ToString();
            dt_ngaybatdau.Value = Convert.ToDateTime(dgv_show.CurrentRow.Cells[4].Value);
            dt_ngayketthuc.Value = Convert.ToDateTime(dgv_show.CurrentRow.Cells[5].Value);
            tb_sotiengiamgia.Text = dgv_show.CurrentRow.Cells[3].Value.ToString();
            rdb_con.Checked = dgv_show.CurrentRow.Cells[6].Value.ToString() == "Trạng thái";
            rdb_con.Checked = dgv_show.CurrentRow.Cells[6].Value.ToString() == "Trạng thái";
            
        }

        private void cbb_tengiay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm ?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (isale.GetDanhMuc().Any(c => c.MaGiamGia == tb_ma.Text))
                {
                    MessageBox.Show("Tên mã bị trùng");
                }
                else if (string.IsNullOrWhiteSpace(tb_tenct.Text))
                {
                    MessageBox.Show("Tên không được bỏ trống");
                }
                else if (rdb_con.Checked == false && rdb_ngung.Checked == false)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái");
                }
                else if ( Convert.ToDecimal(tb_sotiengiamgia.Text) < 0)
                {
                    MessageBox.Show("Nhập đúng mức giảm");
                } 
                else
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
                        MessageBox.Show("Thêm Mã giảm giá thành công");
                        loadData();
                    };
                    
                }
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm ?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                viewsale.MaGiamGia = tb_ma.Text;
                viewsale.TenChuongTrinh = tb_tenct.Text;
                viewsale.NgayBatDau = dt_ngaybatdau.Value;
                viewsale.NgayKetThuc = dt_ngayketthuc.Value;
                viewsale.SoTienGiamGia = Convert.ToInt32(tb_sotiengiamgia.Text);
                viewsale.TrangThai = rdb_con.Checked ? 1 : 0;
                if (isale.update(viewsale))
                {
                    MessageBox.Show("Sửa thành công");
                };
                loadData();
            }

        }
        private void btn_xoa_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa mã giảm giá này Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (viewsale == null)
                {
                    MessageBox.Show("bạn chưa chọn mã");
                }
                else if(isale.remove(viewsale))
                {
                    MessageBox.Show("Xóa thành công");
                    loadData();
                }
            }
        }
    }
}

