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
    public partial class Frm_SizeGiay : Form
    {
        private ISizeGiayServices isize;
        private SizeGiayViewModels vmsz;
        public Frm_SizeGiay()
        {
            InitializeComponent();
            isize = new SizeGiayServices();
            vmsz = new SizeGiayViewModels();
            loadData();
        }
        public void loadData()
        {
            dgv_showsize.Rows.Clear();
            dgv_showsize.ColumnCount = 4;
            dgv_showsize.Columns[0].Name = "ID";
            dgv_showsize.Columns[0].Visible = false;
            dgv_showsize.Columns[1].Name = "Mã";
            dgv_showsize.Columns[2].Name = "Số size";
            dgv_showsize.Columns[3].Name = "Trạng thái";
            var lstsz = isize.GetSizeGiay();
            foreach (var item in lstsz)
            {
                dgv_showsize.Rows.Add(item.Id, item.Ma, item.SoSize, item.TrangThai == 1 ? "Còn hàng" : "Hết hàng");
            }
            dgv_showsize.AllowUserToAddRows = false;
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

        private void btn_xoa_Click_1(object sender, EventArgs e)
        {
            if (vmsz == null)
            {
                MessageBox.Show("bạn chưa chọn size");
            }
            else
            {
                MessageBox.Show(isize.remove(vmsz));
                loadData();
            }
        }

        private void dgv_showsize_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgv_showsize.Rows[e.RowIndex];
                vmsz = isize.GetSizeGiay().FirstOrDefault(x => x.Id == Guid.Parse(dgvr.Cells[0].Value.ToString()));
                tb_ma.Text = vmsz.Ma;
                //tb_sosize.Text = vmsz.SoSize;
                if (dgvr.Cells[3].Value.ToString() == "Còn hàng")
                {
                    rdb_con.Checked = true;
                }
                else
                {
                    rdb_het.Checked = true;
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            SizeGiayViewModels sz = new SizeGiayViewModels()
            {
                Id = Guid.NewGuid(),
                Ma = tb_ma.Text,
                //SoSize = tb_sosize,
                TrangThai = rdb_con.Checked ? 1 : 0
            };
            MessageBox.Show(isize.add(sz));
            loadData();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            vmsz.Ma = tb_ma.Text;
            vmsz.TrangThai = rdb_con.Checked ? 1 : 0;
            MessageBox.Show(isize.update(vmsz));
            loadData();
        }
    }
    }
