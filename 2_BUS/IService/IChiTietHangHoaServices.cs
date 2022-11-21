using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IChiTietHangHoaServices
    {
        List<ChiTietHangHoaViewModels> getlstcthanghoafromDB();
        bool addcthanghoa(ChiTietHangHoaThemViewModels cthh);
        bool deletecthanghoa(Guid idcthh);
        bool updatecthanghoa(ChiTietHangHoaUpdateViewModels cthh);
    }
}
