﻿using _2_BUS.IService;
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
            dtg_showKhachHang.Rows.Clear();
            khachHangViews = khachHangServices.GetAllKhachHangDB();
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
                    item.DiemTichDiem,
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
                tb_GioiTinh.Text = r.Cells[8].Value.ToString();
                dtp_namsinh.Text = r.Cells[9].Value.ToString();
                tb_diemtichDiem.Text = r.Cells[10].Value.ToString();
                if (r.Cells[11].Value.ToString() == "1")
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
            if (idKH == Guid.Empty)
            {
                MessageBox.Show("Vui lòng chọn khách hàng");
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
                    GioiTinh = tb_GioiTinh.Text,
                    NamSinh = dtp_namsinh.Value,
                    DiemTichDiem = Convert.ToInt32(tb_diemtichDiem.Text),
                    TrangThai = cb_hoatDong.Checked ? 1 : 0,
                };
                MessageBox.Show(khachHangServices.SuaKhachHang(nv));
                loadDTG();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
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
    }
}
