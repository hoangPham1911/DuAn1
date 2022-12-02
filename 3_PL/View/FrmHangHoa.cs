using _2_BUS.IService;
using _2_BUS.Service;
using _3_GUI_PresentaionLayers;
using System;
using System.Collections;
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
    public partial class FrmHangHoa : Form
    {
        private IQlyHangHoaServices qlhhser;
        private IQlyHangHoaServices _qlhhser;
        private IAnhService _anhser;
        private INsxServices _nsxser;
        private IChatLieuServices _chatlieuser;
        private ILoaiGiayServices _loaigiayser;
        private IQuocGiaServices _quocgiaser;
        private ISizeGiayServices _sizegiayser;
        private static FrmHangHoa _sender;
        public FrmHangHoa()
        {
<<<<<<< HEAD
            InitializeComponent();
=======
           
            InitializeComponent();
            _sender = this;
>>>>>>> 6c82abc2e18c0e6a80b82106db9e7f00b3658d0e
            qlhhser = new QlyHangHoaServices();
            _anhser = new AnhService();
            _nsxser = new NsxServices();
            _chatlieuser = new ChatLieuServices();
            _quocgiaser = new QuocGiaServices();
            _sizegiayser = new SizeGiayServices();
            _loaigiayser = new LoaiGiayServices();
<<<<<<< HEAD
            _sender = this;
=======
>>>>>>> 6c82abc2e18c0e6a80b82106db9e7f00b3658d0e
            loaddata();

        }

        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }

        public void loaddata()
        {
<<<<<<< HEAD
=======
            //ArrayList row = new ArrayList();

            //row = new ArrayList();
            //row.Add("Thêm");
            //row.Add("Sửa");
            //row.Add("Xóa");

>>>>>>> 6c82abc2e18c0e6a80b82106db9e7f00b3658d0e
            dgrid_sanpham.ColumnCount = 15;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDCTHH";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[3].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[4].Name = "Mã vạch";
            dgrid_sanpham.Columns[5].Name = "Nhà sản xuất";
            dgrid_sanpham.Columns[6].Name = "Số lượng";
            dgrid_sanpham.Columns[7].Name = "Ảnh";
            dgrid_sanpham.Columns[8].Name = "Trạng thái";
            dgrid_sanpham.Columns[9].Name = "Giá nhập";
            dgrid_sanpham.Columns[10].Name = "Đơn giá bán";
            dgrid_sanpham.Columns[11].Name = "Tên chất liệu chính";
            dgrid_sanpham.Columns[12].Name = "Size giày";
            dgrid_sanpham.Columns[13].Name = "Tên quốc gia";
            dgrid_sanpham.Columns[14].Name = "Loại giày";
            dgrid_sanpham.Rows.Clear();
            foreach (var x in qlhhser.GetsList().Where(c => c.TrangThai == 1))
            {
<<<<<<< HEAD
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, _nsxser.GetNhasanxuat().FirstOrDefault(c => c.Id == x.IdNsx).Ten, x.SoLuongTon, _anhser.GetAnh().FirstOrDefault(c => c.ID == x.IdAnh).DuongDan, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, _chatlieuser.GetChatLieu().FirstOrDefault(c => c.Id == x.IdChatLieu).Ten, _sizegiayser.GetSizeGiay().FirstOrDefault(c => c.Id == x.IdSizeGiay).SoSize, _quocgiaser.GetQuocGia().FirstOrDefault(c => c.Id == x.IdQuocGia).Ten, _loaigiayser.GetLoaiGiay().FirstOrDefault(c => c.Id == x.IdLoaiGiay).Ten);
=======
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, _nsxser.GetNhasanxuat().FirstOrDefault(c => c.Id == x.IdNsx).Ten, x.SoLuongTon, x.IdAnh, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, _chatlieuser.GetChatLieu().FirstOrDefault(c => c.Id == x.IdChatLieu).Ten, _sizegiayser.GetSizeGiay().FirstOrDefault(c => c.Id == x.IdSizeGiay).SoSize, _quocgiaser.GetQuocGia().FirstOrDefault(c => c.Id == x.IdQuocGia).Ten, _loaigiayser.GetLoaiGiay().FirstOrDefault(c => c.Id == x.IdLoaiGiay).Ten);
>>>>>>> 6c82abc2e18c0e6a80b82106db9e7f00b3658d0e
            }
        }

        //string mahh, string nsx, string trangthai, string mavach, string soluong, string gianhap, string giaban, string tenchatlieu, string sizegiay, string loaigiay, string quocgia, string anh
        public static void loaddatasender()
        {
           _sender.dgrid_sanpham.ColumnCount = 15;
           _sender.dgrid_sanpham.Columns[0].Name = "IDHH";
           _sender.dgrid_sanpham.Columns[0].Visible = false;
           _sender.dgrid_sanpham.Columns[1].Name = "IDCTHH";
           _sender.dgrid_sanpham.Columns[1].Visible = false;
           _sender.dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
           _sender.dgrid_sanpham.Columns[3].Name = "Tên Hàng Hóa";
           _sender.dgrid_sanpham.Columns[4].Name = "Mã vạch";
           _sender.dgrid_sanpham.Columns[5].Name = "Nhà sản xuất";
           _sender.dgrid_sanpham.Columns[6].Name = "Số lượng";
           _sender.dgrid_sanpham.Columns[7].Name = "Ảnh";
           _sender.dgrid_sanpham.Columns[8].Name = "Trạng thái";
           _sender.dgrid_sanpham.Columns[9].Name = "Giá nhập";
           _sender.dgrid_sanpham.Columns[10].Name = "Đơn giá bán";
           _sender.dgrid_sanpham.Columns[11].Name = "Tên chất liệu chính";
           _sender.dgrid_sanpham.Columns[12].Name = "Size giày";
           _sender.dgrid_sanpham.Columns[13].Name = "Tên quốc gia";
           _sender.dgrid_sanpham.Columns[14].Name = "Loại giày";
           _sender.dgrid_sanpham.Rows.Clear();
            _sender.dgrid_sanpham.Rows.Clear();
            foreach (var x in _sender.qlhhser.GetsList().Where(c => c.TrangThai == 1))
            {
                _sender.dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, x.TenNsx, x.DuongDanAnh, x.SoLuongTon, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, x.TenChatLieu, x.SoSize, x.TenQuocGia, x.TenLoaiGiay);
            }


        }

        private void dgrid_sanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid idhh = Guid.Parse(dgrid_sanpham.Rows[e.RowIndex].Cells[0].Value.ToString());
            Guid idcthh = Guid.Parse(dgrid_sanpham.Rows[e.RowIndex].Cells[1].Value.ToString());
            string mahh = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[2].Value);
            string tenhh = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[3].Value);
            string mavach = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[4].Value);
            string nsx = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[5].Value);
            string soluong = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[6].Value);
            string anh = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[7].Value);
            string trangthai = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[8].Value);
            string gianhap = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[9].Value);
            string giaban = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[10].Value);
            string chatlieu = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[11].Value);
            string sizegiay = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[12].Value);
            string tenquocgia = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[13].Value);
            string loaigiay = Convert.ToString(dgrid_sanpham.Rows[e.RowIndex].Cells[14].Value);
            this.Alert("Chào Mừng Bạn Đến Với Thông Tin Chi Tiết Sản Phẩm");
            FrmChiTietHangHoa frmBackView = new FrmChiTietHangHoa(idhh, idcthh, mahh, tenhh, nsx, trangthai, mavach, soluong,
            gianhap, giaban, chatlieu, sizegiay, loaigiay, tenquocgia, anh);
            frmBackView.Show();


        }
    }
}