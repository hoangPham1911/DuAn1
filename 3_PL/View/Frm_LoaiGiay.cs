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
    public partial class Frm_LoaiGiay : Form
    {
        private ILoaiGiayServices iloaigiay;
        private LoaiGiayViewModels viewloaigiay;
       
        public Frm_LoaiGiay()
        {
            InitializeComponent();
            iloaigiay = new LoaiGiayServices();
            viewloaigiay = new LoaiGiayViewModels();
            loadData();
        }

        public void loadData()
        {
            dgv_show.Rows.Clear();
            dgv_show.ColumnCount = 5;
            dgv_show.Columns[0].Name = "ID";
            dgv_show.Columns[0].Visible = false;
            dgv_show.Columns[1].Name = "Mã";
            dgv_show.Columns[2].Name = "Tên loại giày";
            dgv_show.Columns[3].Name = "Trạng thái";
            var lstloaigiay = iloaigiay.GetLoaiGiay();
            if (tb_timkiem.Text != "")
            {
                lstloaigiay = lstloaigiay.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower())
                || x.Ten.ToString().Contains(tb_timkiem.Text.ToLower())).ToList();
            }
            foreach (var item in lstloaigiay)
            {
                dgv_show.Rows.Add(item.Id, item.Ma, item.Ten, item.TrangThai == 1 ? "Còn hàng" : "Ngừng hết hàng");
            }
            dgv_show.AllowUserToAddRows = false;
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (iloaigiay.GetLoaiGiay().Any(c => c.Ma == tb_ma.Text))
                {
                    MessageBox.Show("Mã bị trùng");
                }
                else if (string.IsNullOrWhiteSpace(tb_ten.Text))
                {
                    MessageBox.Show("Tên không được bỏ trống");
                }
                else if (rdb_con.Checked == false && rdb_ngung.Checked == false)
                {

                    MessageBox.Show("Vui lòng chọn trạng thái");
                }
                else
                {
                    LoaiGiayViewModels x = new LoaiGiayViewModels()
                    {
                        Id = Guid.NewGuid(),
                        Ma = tb_ma.Text,
                        Ten = tb_ten.Text,
                        TrangThai = rdb_con.Checked ? 1 : 0
                    };
                    MessageBox.Show(iloaigiay.add(x));
                    loadData();

                }
            }
                
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Xóa Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (viewloaigiay == null)
                {
                    MessageBox.Show("bạn chưa chọn loại");
                }
                else
                {
                    MessageBox.Show(iloaigiay.remove(viewloaigiay));
                    loadData();
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn sửa Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                viewloaigiay.Ma = tb_ma.Text;
                viewloaigiay.Ten = tb_ten.Text;
                viewloaigiay.TrangThai = rdb_con.Checked ? 1 : 0;
                MessageBox.Show(iloaigiay.update(viewloaigiay));
                loadData();
            }
        }
        private void dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgv_show.Rows[e.RowIndex];
                viewloaigiay = iloaigiay.GetLoaiGiay().FirstOrDefault(x => x.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
                tb_ma.Text = viewloaigiay.Ma;
                tb_ten.Text = viewloaigiay.Ten;
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

        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
