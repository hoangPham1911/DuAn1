using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IHangHoaServices
    {
        List<HangHoaViewModels> getlsthanghoafromDB();
        bool addhanghoa(HangHoaThemViewModels hh);
        bool deletehanghoa(HangHoaViewModels idhh);
        bool updatehanghoa(HangHoaUpdateViewModels hh);
    }
}
