using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IKhachHangServices
    {
        string ThemKhachHang(ThemKhachHangViewModels obj);
        string SuaKhachHang(SuaKhachHangViewModels obj);
        string XoaKhachHang(Guid idKh);
        List<KhachHangViewModels> GetAllKhachHangDB();
        //List<KhachHangViewModels> TimKiem(string maKH);
    }
}
