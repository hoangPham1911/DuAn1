using _3_PL.View;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_PL
{
    public partial class FrmLayLaiMatKhau : Form
    {
        public FrmLayLaiMatKhau()
        {
            InitializeComponent();
        }
        string username = FormQuenMatKhau.to;
        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            if (textBox1.Text == textBox2.Text)
            {
                SqlConnection conn = new SqlConnection("Data Source=SADBOY\\SQLEXPRESS;" +
           "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=ph27584;Password=123456");
                string q = @"UPDATE [dbo].[NhanVien] set [MatKhau]='" + password + "' where Email='" + username + "'";

                SqlCommand cmd = new SqlCommand(q, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Mật khẩu đã được thay đổi thành công");
                this.Close();
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.Show();

            }
            else
            {
                MessageBox.Show("Xin lỗi Mật khẩu mới và Mật khẩu xác nhận của bạn không khớp");
            }
        }
    }
}
