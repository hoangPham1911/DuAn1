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
    public partial class Frm_KieuDanhMuc : Form
    {
        public IKieuDanhMucServices kieuDanhMucServices;
        public IDanhMucServices danhMucServices;
        public IQlyHangHoaServices hangHoaChiTietServices;
        private Guid iddm;
        public List<KieuDanhMucViewModels> KieuDanhMucViewModels;
        public Frm_KieuDanhMuc()
        {
            InitializeComponent();
            kieuDanhMucServices = new KieuDanhMucService();
            danhMucServices = new DanhMucServices();
            hangHoaChiTietServices = new QlyHangHoaServices();
        }

        public void loadDTG()
        {
            int stt = 1;
            dtg_show.ColumnCount = 5;
            dtg_show.Columns[0].Name = "Iddm";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "STT";
            dtg_show.Columns[2].Name = "Tên danh mục";
            dtg_show.Columns[3].Name = "Tên hàng hóa";
            dtg_show.Columns[4].Name = "Thể loại giới tính";

            dtg_show.Rows.Clear();
            KieuDanhMucViewModels = kieuDanhMucServices.GetallKieuDM();
            foreach (var item in KieuDanhMucViewModels)
            {
                dtg_show.Rows.Add(
                    item.IdDanhMuc,
                    stt++,
                    item.TenDM,
                    item.TenHH,
                    item.TheLoaiGioiTinh == 1 ? "Nam" : "Nữ"
                    );
            }
        }

        public void  lodaCBB()
        {
            foreach (var item in danhMucServices.GetDanhMuc())
            {
                cb_DanhMuc.Items.Add(item.Ten);
            }
            foreach (var item in hangHoaChiTietServices.GetsListHH())
            {
                cb_HangHoa.Items.Add(item.Ten);
            }

        }

        private void dtg_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dtg_show.Rows[e.RowIndex];
                iddm = Guid.Parse(r.Cells[0].Value.ToString());
                cb_DanhMuc.Text = r.Cells[2].Value.ToString();
                cb_HangHoa.Text = r.Cells[3].Value.ToString();

                if (r.Cells[4].Value.ToString() == "1")
                {
                    rd_nam.Checked = true;
                }
                else
                {
                    rd_nu.Checked = true;
                }

            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var iddanhmuc = danhMucServices.GetDanhMuc().FirstOrDefault(x => x.Ten == cb_DanhMuc.Text);
            var idHangHoa = hangHoaChiTietServices.GetsListHH().FirstOrDefault(x => x.Ten == cb_HangHoa.Text);
            KieuDanhMucViewModels kdm = new KieuDanhMucViewModels()
            {
                IdDanhMuc = iddanhmuc.Id,
                IdHangHoa = idHangHoa.Id,
                TheLoaiGioiTinh = rd_nam.Checked ? 1 : 0
            };
            if (cb_DanhMuc.Text == "")
            {
                MessageBox.Show("Mời chọn tên danh mục");
            }
            else if (cb_HangHoa.Text == "")
            {
                MessageBox.Show("Mời chọn tên hàng hóa");
            }
            else
            {
                MessageBox.Show(kieuDanhMucServices.ThemKieuDanhMuc(kdm));
                loadDTG();
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var iddanhmuc = danhMucServices.GetDanhMuc().FirstOrDefault(x => x.Ten == cb_DanhMuc.Text);
            var idHangHoa = hangHoaChiTietServices.GetsListHH().FirstOrDefault(x => x.Ten == cb_HangHoa.Text);
            if (iddm == Guid.Empty)
            {
                MessageBox.Show("Vui lòng chọn kiểu danh mục");
            }
            else
            {
                KieuDanhMucViewModels dm = new KieuDanhMucViewModels()
                {

                    IdDanhMuc = iddm,
                    //IdDanhMuc = iddanhmuc.Id,
                    IdHangHoa = idHangHoa.Id,
                    TheLoaiGioiTinh = rd_nam.Checked ? 1 : 0
                };
                MessageBox.Show(kieuDanhMucServices.SuaKieuDanhMuc(dm));
                loadDTG();
            }
        }
    }
}
