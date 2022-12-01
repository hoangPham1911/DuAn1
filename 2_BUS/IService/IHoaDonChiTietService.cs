using _2_BUS.ViewModels;

namespace _2_BUS.IService
{
    public interface IHoaDonChiTietService
    {
        bool ThemHoaDonChiTiet(HoaDonChiTietThemViewModel Hoadonnew);
        bool SuaHoaDonChiTiet(HoaDonChiTietUpdateView Hoadonold);
        bool XoaHoaDonChiTiet(Guid Hoadonold);
        bool XoaSpTrongHoaDonChiTiet(Guid Id, Guid IdHoaDon);

        public List<HoaDonChiTietViewModel> GetAllHoaDonDB();
        public List<SanPhamTrongHoaDonViewModels> GetAllProductInReceipt();
        public List<HoaDonChiTietViewModel> timkiemhdtheoid(Guid id);
    }
}
