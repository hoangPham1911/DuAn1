using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IQlyHangHoaServices
    {
        bool addhanghoa(HangHoaThemViewModels hh);
        bool deletehanghoa(HangHoaViewModels idhh);
        bool updatehanghoa(HangHoaViewModels hh);
        bool addcthanghoa(ChiTietHangHoaThemViewModels cthh);
        bool deletecthanghoa(Guid idcthh);
        bool updatehanghoact(ChiTietHangHoaUpdateViewModels hh);

        public Guid IdSp(HangHoaViewModels product);

        List<QlyHangHoaViewModels> GetsList();
        List<HangHoaViewModels> GetsListHH();
        List<ChiTietHangHoaViewModels> GetsListCTHH();
        public bool updateSoLuong(HangHoaChiTietUpdateThanhToan hangHoas);
        List<HangHoaChiTietUpdateThanhToan> GetAllSoLuong();
    }
}
