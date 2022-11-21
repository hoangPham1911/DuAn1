using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IHangHoaChiTietServices
    {
        bool ThemHangHoaChiTiet(HangHoaChiTietThemViewModels HangHoa);
        bool SuaHangHoaChiTiet(HangHoaChiTietUpdateViewModels HangHoa);
<<<<<<< HEAD
=======

>>>>>>> f5e174becf0f814e77ef154d7329b4dab93b2afe
        bool XoaHangHoaChiTiet(Guid idHangHoa);
        public List<HangHoaChiTietViewModels> GetAllHoaDonDB();
        public List<HangHoaChiTietUpdateThanhToan> GetAllSoLuong();

        public bool updateSoLuong(HangHoaChiTietUpdateThanhToan hangHoas);

        bool XoaHangHoaChiTiet(Guid idHangHoa, HangHoa hanghoaid);
        public List<HangHoaChiTietViewModels> GetAllHangHoaDB();

    }
}
