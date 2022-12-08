using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface  IChucVuServices
    {
        List<ChucVuViewModels> GetAll();
        bool Them(ChucVuViewModels chucVu);
        bool Sua(ChucVuViewModels chucVu);
        bool Xoa(Guid Id);
        public List<ChucVuViewModels> GetChucVu();
        List<ChucVuViewModels> TimKiem(string Ma);
    }
}
