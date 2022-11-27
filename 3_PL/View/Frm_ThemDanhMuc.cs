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
    public partial class Frm_ThemDanhMuc : Form
    {
        public IDanhMucServices danhMucServices;
        public Frm_ThemDanhMuc()
        {
            InitializeComponent();
            danhMucServices = new DanhMucServices();
        }
        public void loadCBB()
        {
            foreach (var item in danhMucServices.GetDanhMuc())
            {
                cb_tenDanhMucKhac.Items.Add(item.Ten);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rd_ch.Checked && !rd_hh.Checked)
            {
                MessageBox.Show("Vui lòng chọn trạng thái");
            }
            else if (danhMucServices.GetDanhMuc().Any(p => p.Ten == tb_ten.Text))
            {
                MessageBox.Show("Tên Danh Mục Đã Tồn Tại");
            }
            else if (danhMucServices.GetDanhMuc().Any(p => p.Ma == tb_Ma.Text))
            {
                MessageBox.Show("Mã Danh Mục Đã Tồn Tại");
            }
            else if (tb_Ma.Text == "" || tb_ten.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập đầy đủ thông tin");
            }
            else
            {
                var dm = new DanhMucViewModels()
                {
                    Id = new Guid(),
                    Ma = tb_Ma.Text,
                    Ten = tb_ten.Text,
                    IdDanhMucKhac = cb_tenDanhMucKhac.Text != "" ? danhMucServices.GetDanhMuc().FirstOrDefault(x => x.Ten == cb_tenDanhMucKhac.Text).Id : null,
                    TrangThai = rd_ch.Checked ? 1 : 0,

                };
                danhMucServices.add(dm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
