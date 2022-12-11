using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Service;
using _2_BUS.Services;
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
    public partial class BangQuyDoiDiem : Form
    {
        IBangQuyDoiDiemServices _QuyDoiDiemService;
        public BangQuyDoiDiem()
        {
            InitializeComponent();
            _QuyDoiDiemService = new BangQuyDoiDiemServices();
            load();
            Ba.Checked = true;
           
        }
        public void load()
        {
            dgv_diem.AllowUserToAddRows = false;
            dgv_diem.Rows.Clear();
            dgv_diem.ColumnCount = 6;
            dgv_diem.Columns[0].Name = "ID";
            dgv_diem.Columns[0].Visible = false;
            dgv_diem.Columns[1].Name = "Tên";
            dgv_diem.Columns[2].Name = "Tỷ Lệ Quy Đổi";
            dgv_diem.Columns[3].Name = "Trạng Thái";
            dgv_diem.Columns[4].Name = "Điểm";
            dgv_diem.Columns[5].Name = "ĐK Áp Điểm";

            foreach (var item in _QuyDoiDiemService.Get())
            {
                dgv_diem.Rows.Add(item.Id, item.Ten,item.TyLeQuyDoi,item.TrangThai,item.Tong,item.DKApDiem);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BangQuyDoiDiemViewModels bangQuyDoi = new BangQuyDoiDiemViewModels();
            bangQuyDoi.TyLeQuyDoi =decimal.Parse(textBox2.Text);
            bangQuyDoi.Ten = textBox1.Text;
            bangQuyDoi.Tong = int.Parse(textBox3.Text);
            bangQuyDoi.DKApDiem = int.Parse(textBox4.Text);
            if (Ba.Checked) bangQuyDoi.TrangThai = "Áp Dụng";
            else bangQuyDoi.TrangThai = "Không Áp Dụng";
            if (_QuyDoiDiemService.add(bangQuyDoi))
            {
                MessageBox.Show("Quy Doi Thanh Cong");
            }else
            {
                MessageBox.Show("Lỗi");
            }
            load();
          
        }
        private void checkNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BangQuyDoiDiemViewModels bangQuyDoi = new BangQuyDoiDiemViewModels();
            bangQuyDoi.TyLeQuyDoi = decimal.Parse(textBox2.Text);
            bangQuyDoi.Id = Id;
            bangQuyDoi.Tong = int.Parse(textBox3.Text);
            bangQuyDoi.Ten = textBox1.Text;
            bangQuyDoi.DKApDiem = int.Parse(textBox4.Text);
            if (Ba.Checked) bangQuyDoi.TrangThai = "Áp Dụng";
            else bangQuyDoi.TrangThai = "Không Áp Dụng";
            if (_QuyDoiDiemService.update(bangQuyDoi))
            {
                MessageBox.Show("Quy Doi Thanh Cong");
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
            load();
        }
        Guid Id;
        private void dgv_diem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = Guid.Parse(dgv_diem.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dgv_diem.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dgv_diem.CurrentRow.Cells[2].Value.ToString();
                if (dgv_diem.CurrentRow.Cells[3].Value.ToString() == "Áp Dụng")
                {
                    Ba.Checked = true;
                }
                else radioButton2.Checked = true;
                textBox3.Text = dgv_diem.CurrentRow.Cells[4].Value.ToString();
                textBox4.Text = dgv_diem.CurrentRow.Cells[5 ].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn Chưa Ấn Chọn");
                throw;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender,e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumber(sender,e);
        }
    }
}
