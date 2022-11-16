using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface INhanVienServices
    {
        List<NhanVienViewModels> GetAll();
        bool Them(NhanVienViewModels nhanVien);
        bool Sua(NhanVienViewModels nhanVien);
        bool Xoa(Guid Id);

        List<NhanVienViewModels> TimKiem(string Ma);
    }
}
