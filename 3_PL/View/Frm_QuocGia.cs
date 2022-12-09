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
    public partial class Frm_QuocGia : Form
    {
        private IQuocGiaServices iqg;
        private QuocGiaViewModels viewqg;
        public Frm_QuocGia()
        {
            InitializeComponent();
            iqg = new QuocGiaServices();
            viewqg = new QuocGiaViewModels();
            loadData();
        }

        public void loadData()
        {
            dgv_show.Rows.Clear();
            dgv_show.ColumnCount = 5;
            dgv_show.Columns[0].Name = "ID";
            dgv_show.Columns[0].Visible = false;
            dgv_show.Columns[1].Name = "Mã";
            dgv_show.Columns[2].Name = "Tên quốc gia";
            dgv_show.Columns[3].Name = "Trạng thái";
            var lstqg = iqg.GetQuocGia();
            if (tb_timkiem.Text != "")
            {
                lstqg = lstqg.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower())
                || x.Ten.ToLower().Contains(tb_timkiem.Text.ToLower())).ToList();
            }
            foreach (var item in lstqg)
            {
                dgv_show.Rows.Add(item.Id, item.Ma, item.Ten, item.TrangThai == 1 ? "Còn hàng" : "Ngừng hết hàng");
            }
            dgv_show.AllowUserToAddRows = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa Nhà Sản Xuất Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (viewqg == null)
                {
                    MessageBox.Show("bạn chưa chọn nsx");
                }
                else
                {
                    MessageBox.Show(iqg.remove(viewqg));
                    loadData();
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
         
        }
        private void dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgv_show.Rows[e.RowIndex];
                viewqg = iqg.GetQuocGia().FirstOrDefault(x => x.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
                tb_ma.Text = viewqg.Ma;
                tb_ten.Text = viewqg.Ten;
                if (dgvr.Cells[3].Value.ToString() == "hiển thị")
                {
                    rdb_con.Checked = true;
                }
                else
                {
                    rdb_ngung.Checked = true;
                }
            }
        }

        private void btn_them_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (iqg.GetQuocGia().Any(c => c.Ma == tb_ma.Text))
                {
                    MessageBox.Show("Mã bị trùng");
                }
                else if (string.IsNullOrWhiteSpace(tb_ten.Text))
                {
                    MessageBox.Show("Tên quốc gia không được bỏ trống");
                }
                else if (rdb_con.Checked == false && rdb_ngung.Checked == false)
                {

                    MessageBox.Show("Vui lòng chọn trạng thái");
                }
                else
                {
                    QuocGiaViewModels x = new QuocGiaViewModels()
                    {
                        Id = Guid.NewGuid(),
                        Ma = tb_ma.Text,
                        Ten = tb_ten.Text,
                        TrangThai = rdb_con.Checked ? 1 : 0
                    };
                    MessageBox.Show(iqg.add(x));
                    loadData();
                }
            }
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa Nhà Sản Xuất Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                viewqg.Ma = tb_ma.Text;
                viewqg.Ten = tb_ten.Text;
                viewqg.TrangThai = rdb_con.Checked ? 1 : 0;
                MessageBox.Show(iqg.update(viewqg));
                loadData();
            }
        }

        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
