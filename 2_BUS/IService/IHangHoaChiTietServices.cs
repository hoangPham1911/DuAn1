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
        bool XoaHangHoaChiTiet(Guid idHangHoa);
        public List<HangHoaChiTietViewModels> GetAllHoaDonDB();
        public List<HangHoaChiTietUpdateThanhToan> GetAllSoLuong();

        public bool updateSoLuong(HangHoaChiTietUpdateThanhToan hangHoas);
=======
        bool XoaHangHoaChiTiet(Guid idHangHoa, HangHoa hanghoaid);
        public List<HangHoaChiTietViewModels> GetAllHangHoaDB();
>>>>>>> 5df4b049fee2c248c67ff9129f80eab99d61b894
    }
}
