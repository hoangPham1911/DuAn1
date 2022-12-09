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
        private IAnhService _anhser;
        private INsxServices _nsxser;
        private IChatLieuServices _chatlieuser;
        private ILoaiGiayServices _loaigiayser;
        private IQuocGiaServices _quocgiaser;
        private ISizeGiayServices _sizegiayser;
        private static FrmHangHoa _sender;
        public FrmHangHoa()
        {
                    
            InitializeComponent();
            qlhhser = new QlyHangHoaServices();
            _chatlieuser = new ChatLieuServices();
            _quocgiaser = new QuocGiaServices();
            _sizegiayser = new SizeGiayServices();
            _loaigiayser = new LoaiGiayServices();
            _sender = this;
            loadloc();
            loaddata();
            dgrid_sanpham.AllowUserToAddRows = false;
            
        }

        public void Alert(string mess)
        {
            FrmAlert frmAlert = new FrmAlert();
            frmAlert.showAlert(mess);
        }

        void loadloc()
        {
            ArrayList row = new ArrayList();

            row = new ArrayList();
            row.Add("Giá");
            row.Add("Số Lượng");
            cbo_loc.Items.AddRange(row.ToArray());
        }
        public void loaddata()
        {

            dgrid_sanpham.ColumnCount = 15;
            dgrid_sanpham.Columns[0].Name = "IDHH";
            dgrid_sanpham.Columns[0].Visible = false;
            dgrid_sanpham.Columns[1].Name = "IDCTHH";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[2].Name = "Mã Hàng Hóa";
            dgrid_sanpham.Columns[3].Name = "Tên Hàng Hóa";
            dgrid_sanpham.Columns[4].Name = "Mã vạch";
            //dgrid_sanpham.Columns[4].Visible = false;

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
            foreach (var x in qlhhser.GetsList())
            {

                //dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, _nsxser.GetNhasanxuat().FirstOrDefault(c => c.Id == x.IdNsx).Ten, x.SoLuongTon, _anhser.GetAnh().FirstOrDefault(c => c.ID == x.IdAnh).DuongDan, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, _chatlieuser.GetChatLieu().FirstOrDefault(c => c.Id == x.IdChatLieu).Ten, _sizegiayser.GetSizeGiay().FirstOrDefault(c => c.Id == x.IdSizeGiay).SoSize, _quocgiaser.GetQuocGia().FirstOrDefault(c => c.Id == x.IdQuocGia).Ten, _loaigiayser.GetLoaiGiay().FirstOrDefault(c => c.Id == x.IdLoaiGiay).Ten);
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, x.TenNsx, x.SoLuongTon, x.DuongDanAnh, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, x.TenChatLieu, x.SoSize, x.TenQuocGia, x.TenLoaiGiay);


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
                _sender.dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, x.TenNsx, x.SoLuongTon, x.DuongDanAnh, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, x.TenChatLieu, x.SoSize, x.TenQuocGia, x.TenLoaiGiay);
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
            FrmChiTietHangHoa frmBackView = new FrmChiTietHangHoa(idhh, idcthh, mahh, tenhh, nsx, trangthai, soluong,
            gianhap, giaban, chatlieu, sizegiay, loaigiay, tenquocgia, anh);
            frmBackView.Show();
            this.Hide();

        }

        void loaddatafortimkiem(string ma)
        {
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
            foreach (var x in qlhhser.GetsList().Where(c => c.TrangThai == 1 && c.Ma.Contains(txt_timkiem.Text)))
            {
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, _nsxser.GetNhasanxuat().FirstOrDefault(c => c.Id == x.IdNsx).Ten, x.SoLuongTon, _anhser.GetAnh().FirstOrDefault(c => c.ID == x.IdAnh).DuongDan, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, _chatlieuser.GetChatLieu().FirstOrDefault(c => c.Id == x.IdChatLieu).Ten, _sizegiayser.GetSizeGiay().FirstOrDefault(c => c.Id == x.IdSizeGiay).SoSize, _quocgiaser.GetQuocGia().FirstOrDefault(c => c.Id == x.IdQuocGia).Ten, _loaigiayser.GetLoaiGiay().FirstOrDefault(c => c.Id == x.IdLoaiGiay).Ten);

            }
        }

        void loaddataforlocsoluong(string soluong)
        {
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
            foreach (var x in qlhhser.GetsList().Where(c => c.TrangThai == 1).OrderByDescending(c => c.SoLuongTon))
            {
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, _nsxser.GetNhasanxuat().FirstOrDefault(c => c.Id == x.IdNsx).Ten, x.SoLuongTon, _anhser.GetAnh().FirstOrDefault(c => c.ID == x.IdAnh).DuongDan, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, _chatlieuser.GetChatLieu().FirstOrDefault(c => c.Id == x.IdChatLieu).Ten, _sizegiayser.GetSizeGiay().FirstOrDefault(c => c.Id == x.IdSizeGiay).SoSize, _quocgiaser.GetQuocGia().FirstOrDefault(c => c.Id == x.IdQuocGia).Ten, _loaigiayser.GetLoaiGiay().FirstOrDefault(c => c.Id == x.IdLoaiGiay).Ten);

            }

        }

        void loaddataforloc(string locgia)
        {
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
            foreach (var x in qlhhser.GetsList().Where(c => c.TrangThai == 1).OrderByDescending(c => c.GiaBan))
            {
                dgrid_sanpham.Rows.Add(x.IdSp, x.Id, x.Ma, x.Ten, x.Mavach, _nsxser.GetNhasanxuat().FirstOrDefault(c => c.Id == x.IdNsx).Ten, x.SoLuongTon, _anhser.GetAnh().FirstOrDefault(c => c.ID == x.IdAnh).DuongDan, x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng", x.GiaNhap, x.GiaBan, _chatlieuser.GetChatLieu().FirstOrDefault(c => c.Id == x.IdChatLieu).Ten, _sizegiayser.GetSizeGiay().FirstOrDefault(c => c.Id == x.IdSizeGiay).SoSize, _quocgiaser.GetQuocGia().FirstOrDefault(c => c.Id == x.IdQuocGia).Ten, _loaigiayser.GetLoaiGiay().FirstOrDefault(c => c.Id == x.IdLoaiGiay).Ten);


            }


        }

        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            loaddatafortimkiem(txt_timkiem.Text);
        }

        private void cbo_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_loc.Text == "Giá")
            {
                loaddataforloc("Giá");
                return;
            }
            if (cbo_loc.Text == "Số Lượng")
            {
                loaddataforlocsoluong("Số Lượng");
                return;
            }
            if (cbo_loc.Text == "")
            {
                loaddata();
                return;
            }
        }

        private void chaasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ChatLieu frm_ChatLieu = new Frm_ChatLieu();
            frm_ChatLieu.ShowDialog();
        }

        private void loạiGiàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_LoaiGiay frm_LoaiGiay = new Frm_LoaiGiay();
            frm_LoaiGiay.ShowDialog();
        }

        private void sizeGiàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_SizeGiay frm_SizeGiay = new Frm_SizeGiay();
            frm_SizeGiay.ShowDialog();
        }

        private void xuấtXứToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_QuocGia frm_QuocGia = new Frm_QuocGia();
            frm_QuocGia.ShowDialog();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            FrmThemHH frmThemHH = new FrmThemHH();
            frmThemHH.ShowDialog();
        }

        private void nhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_NSX frm_NSX = new Frm_NSX();
            frm_NSX.ShowDialog();
        }

        private void ảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Anh frm_Anh = new Frm_Anh();
            frm_Anh.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn xuất file pdf  hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                ReportFileToPDF reportFileToPDF = new ReportFileToPDF();
                reportFileToPDF.Show();
                for (int a = 0; a < 1; a++)
                {
                    this.Alert("Hãy Tiến Hành Xuát Ra File PDF Thôi Nào !");

                }
            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("bạn có muốn thêm số lượng Lớn sản phẩm bằng file excel hay không", "Thông Báo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Frm_ImportExcel frmAddDataFormExcelToDB = new Frm_ImportExcel();
                for (int a = 0; a < 2; a++)
                {
                    this.Alert("Hãy Tiến Hành Thêm Số Lượng Lớn Thôi Nào !");

                }
                frmAddDataFormExcelToDB.Show();


            };

            if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            
        }
    }
}