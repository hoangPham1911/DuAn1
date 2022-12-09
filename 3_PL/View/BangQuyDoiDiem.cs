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
            textBox2.Text = _QuyDoiDiemService.GetDiemQuyDoi().FirstOrDefault(p => p.Ten.Contains(1.ToString())).TyLeQuyDoi.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Số Tiền Quy Đổi");
            }
            else
            {
                if (_QuyDoiDiemService.GetDiemQuyDoi().Count() != 0)
                {
                    BangQuyDoiDiemViewModels bangQuyDoi1 = new BangQuyDoiDiemViewModels();
                    bangQuyDoi1.TyLeQuyDoi = decimal.Parse(textBox2.Text);
                    if (Ba.Checked)
                    {
                        bangQuyDoi1.TrangThai = "Áp Dụng";
                    }
                    else
                    {
                        bangQuyDoi1.TrangThai = "Không Áp Dụng";
                    }
                    bangQuyDoi1.Ten = 1.ToString();
                    bangQuyDoi1.Id = _QuyDoiDiemService.GetDiemQuyDoi().FirstOrDefault(p => p.Ten == 1.ToString()).Id;
                    if (_QuyDoiDiemService.update(bangQuyDoi1))
                    {
                        MessageBox.Show("Cap Nhat quy doi thanh cong");
                    }
                }
                else
                {
                    BangQuyDoiDiemViewModels bangQuyDoi = new BangQuyDoiDiemViewModels();
                    bangQuyDoi.TyLeQuyDoi = decimal.Parse(textBox2.Text);
                    bangQuyDoi.Ten = 1.ToString();
                    if (radioButton2.Checked)
                    {
                        bangQuyDoi.TrangThai = "Áp Dụng";
                    }
                    else
                    {
                        bangQuyDoi.TrangThai = "Không Áp Dụng";
                    }
                    if (_QuyDoiDiemService.add(bangQuyDoi))
                    {
                        MessageBox.Show("quy doi thanh cong");
                    }   
                }
                  
            }
          
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
    }
}
