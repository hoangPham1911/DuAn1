using _1_DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IDALServices
{
    public interface ISfattRepository
    {
        bool Them(NhanVien nhanVien);
        bool Sua(NhanVien nhanVien);
        bool Xoa(Guid Id);
        List<NhanVien> GetAll();
        List<NhanVien> TimKiem(string Ma);
        NhanVien Login(string userName, string pass);
    }
}
