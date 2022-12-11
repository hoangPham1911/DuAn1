using _2_BUS.IService;
using _2_BUS.Service;
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
    public partial class FrmLichSuDiemTieuDung : Form
    {
        private ILichSuDiemService _lichSuDiemService;
        public FrmLichSuDiemTieuDung()
        {
            InitializeComponent();
            _lichSuDiemService = new LichSuDiemService();
 ;
        }

        void loadata()
        {
            dgridLichSu.ColumnCount = 11;
            dgridLichSu.Columns[0].Name = "IDHD";
            dgridLichSu.Columns[0].Visible = false;
            dgridLichSu.Columns[1].Name = "IDLSD";
            dgridLichSu.Columns[1].Visible = false;
            dgridLichSu.Columns[2].Name = "IDVD";
            dgridLichSu.Columns[2].Visible = false;
            dgridLichSu.Columns[3].Name = "IDKH";
            dgridLichSu.Columns[3].Visible = false;
            dgridLichSu.Columns[4].Name = "Mã khách hàng";
            dgridLichSu.Columns[5].Name = "Tên khách hàng";
            dgridLichSu.Columns[6].Name = "Ngày sử dụng";
            dgridLichSu.Columns[7].Name = "Số điểm tiêu dùng";
            dgridLichSu.Columns[8].Name = "Số điểm cộng";
            dgridLichSu.Columns[9].Name = "Số điểm còn lại";
            dgridLichSu.Columns[10].Name = "Trạng thái";
            dgridLichSu.Rows.Clear();
            foreach (var item in _lichSuDiemService.GetLichSuDiem())
            {
                dgridLichSu.Rows.Add(item.IdHoaDon, item.IdLichSuDiem, item.IdViDiem, item.IdKhachHang, item.MaKH,item.TenKH, item.NgaySuDung, item.SoDiemTieuDung, item.SoDiemCong, item.TongDiem, item.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng");
            }
        }
        private void dgridLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadata();
        }

        private void dgridLichSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgridLichSu.Rows[e.RowIndex];
            txtTenKH.Text = r.Cells[5].Value.ToString();
            txtMa.Text = r.Cells[4].Value.ToString();
            txtDiemConLai.Text = r.Cells[9].Value.ToString();
        }
    }
}
