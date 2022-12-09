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
    public partial class Frm_ChatLieu : Form
    {
        private IChatLieuServices ichatlieu;
        private ChatLieuViewModels viewchatlieu;
        public Frm_ChatLieu()
        {
            InitializeComponent();
            ichatlieu = new ChatLieuServices();
            viewchatlieu = new ChatLieuViewModels();
            loadData();
        }

        public void loadData()
        {
            dgv_show.Rows.Clear();
            dgv_show.ColumnCount = 5;
            dgv_show.Columns[0].Name = "ID";
            dgv_show.Columns[0].Visible = false;
            dgv_show.Columns[1].Name = "Mã";
            dgv_show.Columns[2].Name = "Tên chất liệu";
            dgv_show.Columns[3].Name = "Trạng thái";
            var lstchatlieu = ichatlieu.GetChatLieu();
            if (tb_timkiem.Text != "")
            {
                lstchatlieu = lstchatlieu.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower())
                || x.Ten.ToString().Contains(tb_timkiem.Text.ToLower())).ToList();
            }
            foreach (var item in lstchatlieu)
            {
                dgv_show.Rows.Add(item.Id, item.Ma, item.Ten, item.TrangThai == 1 ? "Còn hàng" : "Ngừng hết hàng");
            }
            dgv_show.AllowUserToAddRows = false;
        }



        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (viewchatlieu == null)
                {
                    MessageBox.Show("bạn chưa chọn chất liệu");
                }
                else
                {
                    MessageBox.Show(ichatlieu.remove(viewchatlieu));
                    loadData();
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn Có Muốn Thêm Size Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                viewchatlieu.Ma = tb_ma.Text;
                viewchatlieu.Ten = tb_ten.Text;
                viewchatlieu.TrangThai = rdb_con.Checked ? 1 : 0;
                MessageBox.Show(ichatlieu.update(viewchatlieu));
                loadData();
            }
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn Thêm chất liệu Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ichatlieu.GetChatLieu().Any(c => c.Ma == tb_ma.Text))
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
                    ChatLieuViewModels x = new ChatLieuViewModels()
                    {
                        Id = Guid.NewGuid(),
                        Ma = tb_ma.Text,
                        Ten = tb_ten.Text,
                        TrangThai = rdb_con.Checked ? 1 : 0
                    };
                    MessageBox.Show(ichatlieu.add(x));
                    loadData();
                }
            }
        }


        private void dgv_showsize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dgvr = dgv_show.Rows[e.RowIndex];
                    viewchatlieu = ichatlieu.GetChatLieu().FirstOrDefault(x => x.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
                    tb_ma.Text = viewchatlieu.Ma;
                    tb_ten.Text = viewchatlieu.Ten;
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
