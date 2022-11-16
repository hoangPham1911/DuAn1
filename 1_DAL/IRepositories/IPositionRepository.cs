using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _1.DAL.IDALServices
{
    public interface IPositionRepository
    {
        bool Them(ChucVu chucVu);
        bool Sua(ChucVu chucVu);
        bool Xoa(Guid Id);
        List<ChucVu> GetAll();
        List<ChucVu> TimKiem(string Ma);
    }
}
