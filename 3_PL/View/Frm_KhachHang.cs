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
    public partial class Frm_KhachHang : Form
    {
        public IKhachHangServices khachHangServices;
        private Guid idKH;
        public List<KhachHangViewModels> khachHangViews;
        public Frm_KhachHang()
        {
            InitializeComponent();
            khachHangServices = new KhachHangServices();
            khachHangViews = new List<KhachHangViewModels>();
            loadDTG();
        }
        public void loadDTG()
        {
            int stt = 1;
            dtg_showKhachHang.ColumnCount = 12;
            dtg_showKhachHang.Columns[0].Name = "Id";
            dtg_showKhachHang.Columns[0].Visible = false;
            dtg_showKhachHang.Columns[1].Name = "STT";
            dtg_showKhachHang.Columns[2].Name = "Mã khách hàng";
            dtg_showKhachHang.Columns[3].Name = "Tên khách hàng";
            dtg_showKhachHang.Columns[4].Name = "Địa chỉ";
            dtg_showKhachHang.Columns[5].Name = "Số điện thoại";
            dtg_showKhachHang.Columns[6].Name = "Email";
            dtg_showKhachHang.Columns[7].Name = "Số CCCD";
            dtg_showKhachHang.Columns[8].Name = "Giới tính";
            dtg_showKhachHang.Columns[9].Name = "Năm Sinh";
            dtg_showKhachHang.Columns[10].Name = "Điểm tích điểm";
            dtg_showKhachHang.Columns[11].Name = "Trạng thái";
            dtg_showKhachHang.AllowUserToAddRows = false;
            dtg_showKhachHang.Rows.Clear();
            khachHangViews = khachHangServices.GetAllKhachHangDB();
            if (tb_timKiem.Text != "")
            {
                khachHangViews = khachHangViews.Where(p => p.Ten.Contains(tb_timKiem.Text)).ToList();
            }
            foreach (var item in khachHangViews)
            {
                dtg_showKhachHang.Rows.Add(
                    item.Idkh,
                    stt++,
                    item.Ma,
                    item.Ten,
                    item.DiaChi,
                    item.Sdt,
                    item.Email,
                    item.SoCCCD,
                    item.GioiTinh,
                    item.NamSinh,
                    item.tongDiem,
                    item.TrangThai == 1 ? "Hoạt động" : "Không hoạt động"
                    );
            }


        }
        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void dtg_showKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_showKhachHang.Rows[e.RowIndex];
                idKH = Guid.Parse(r.Cells[0].Value.ToString());
                tb_maKhachHang.Text = r.Cells[2].Value.ToString();
                tb_tenKhachHang.Text = r.Cells[3].Value.ToString();
                tb_diaChi.Text = r.Cells[4].Value.ToString();
                tb_sDT.Text = r.Cells[5].Value.ToString();
                tb_email.Text = r.Cells[6].Value.ToString();
                tb_cccd.Text = r.Cells[7].Value.ToString();
                if (r.Cells[8].Value.ToString() == "Nam")
                {
                    rd_nam.Checked = true;
                }
                else
                {
                    rd_nu.Checked = true;
                }
             
                dtp_namsinh.Text = r.Cells[9].Value.ToString();
                if (r.Cells[10].Value == null)
                {
                    tb_diemtichDiem.Text = "";
                }
                else
                {
                    tb_diemtichDiem.Text = r.Cells[10].Value.ToString();
                }
               
                if (r.Cells[11].Value.ToString() == "Hoạt động")
                {
                    cb_hoatDong.Checked = true;
                }
                else
                {
                    cb_khongHoatDong.Checked = true;
                }

            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa khách hàng không?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (idKH == Guid.Empty)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng");
                }
                else if (khachHangServices.GetAllKhachHangDB().Any(p => p.Ten == tb_maKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại");
                }
                else if (tb_maKhachHang.Text == "" || tb_tenKhachHang.Text == "" || tb_email.Text == "" || tb_cccd.Text == "" || tb_diaChi.Text== "" || tb_sDT.Text == "")
                {
                    MessageBox.Show("Vui lòng sửa đầy đủ");
                }
                else if (!rd_nam.Checked && !rd_nu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính");
                }
                else if (!cb_khongHoatDong.Checked  && !cb_hoatDong.Checked)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái");
                }
                else
                {
                    SuaKhachHangViewModels nv = new SuaKhachHangViewModels()
                    {
                        Idkh = idKH,
                        Ma = tb_maKhachHang.Text,
                        Ten = tb_tenKhachHang.Text,
                        DiaChi = tb_diaChi.Text,
                        Sdt = tb_sDT.Text,
                        Email = tb_email.Text,
                        SoCCCD = tb_cccd.Text,
                        GioiTinh = rd_nam.Checked ? "Nam" : "Nữ",
                        NamSinh = dtp_namsinh.Value,
                        DiemTichDiem = Convert.ToInt32(tb_diemtichDiem.Text),
                        TrangThai = cb_hoatDong.Checked ? 1 : 0,
                    };
                    MessageBox.Show(khachHangServices.SuaKhachHang(nv));
                    loadDTG();
                }
            }
            else
            {

            }

                //
                
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa khách hàng không?", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (idKH == Guid.Empty)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng");
                }
                else
                {

                    MessageBox.Show(khachHangServices.XoaKhachHang(idKH));
                    loadDTG();
                }
            }
                //
                
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            Frm_ThemKhachHang khachHang = new Frm_ThemKhachHang();
            khachHang.ShowDialog();
        }

        private void tb_cccd_TextChanged(object sender, EventArgs e)
        {
            if (tb_cccd.Text.All(Char.IsDigit) == false)
            {
                tb_cccd.Text = tb_cccd.Text.Substring(0, tb_cccd.Text.Length - 1);
            }
        }

        private void tb_sDT_TextChanged(object sender, EventArgs e)
        {
            if (tb_sDT.Text.All(Char.IsDigit) == false)
            {
                tb_sDT.Text = tb_sDT.Text.Substring(0, tb_sDT.Text.Length - 1);
            }
        }

        private void tb_timKiem_TextChanged(object sender, EventArgs e)
        {
            loadDTG();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void cb_hoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_hoatDong.Checked)
            {
                cb_hoatDong.Checked = true;
                cb_khongHoatDong.Checked = false;
            }
        }

        private void cb_khongHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_khongHoatDong.Checked)
            {
                cb_hoatDong.Checked = false;
                cb_khongHoatDong.Checked = true;
            }
        }
    }
}
