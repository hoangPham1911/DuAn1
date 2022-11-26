using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Service;
using _2_BUS.Services;

namespace _3_PL.View
{
    public partial class ctspINhoadon : Form
    {

        IHoaDonChiTietService _HDCTservice;
        IHoaDonService _HDService;
        IHangHoaServices _HangHoaServices;
        public ctspINhoadon()
        {
            InitializeComponent();
            _HDCTservice = new HoaDonChiTietService();
            _HDService = new HoaDonService();
            _HangHoaServices = new HangHoaServices();
            LoadDTG();
        }
        Guid idhd = Frm_HoaDon.Currenid;
        int i = 1;
        void LoadDTG()
        {

            dtg_showHD.ColumnCount = 8;
            dtg_showHD.Rows.Clear();
            dtg_showHD.Columns[0].Name = "STT";
            dtg_showHD.Columns[1].Name = "ID";
            dtg_showHD.Columns[2].Name = "MAHD";
            dtg_showHD.Columns[3].Name = "Sản Phẩm";
            dtg_showHD.Columns[4].Name = "Số Lượng";
            dtg_showHD.Columns[5].Name = "Thành Tiền";
            dtg_showHD.Columns[6].Name = "Trạng Thái";
            dtg_showHD.Columns[7].Name = "Giảm Giá";

            foreach (var x in _HDCTservice.timkiemhdtheoid(idhd))
            {
                dtg_showHD.Rows.Add(i++,
                    x.IdHoaDon,
                    _HDService.GetAllHoaDonDB().FirstOrDefault(c => c.IdHoaDon == x.IdHoaDon).Ma,
                    _HangHoaServices.getlsthanghoafromDB().FirstOrDefault(c => c.Id == x.IdChiTietSp).Ten,
                    //x.Name,
                    x.SoLuong,
                    x.ThanhTien,
                    x.TrangThai == 1 ? "Còn Hàng" : "Hết Hàng",
                    x.GiamGia);

            }
        }

    }
}
