using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IGiaoCaServices
    {
        List<GiaoCaViewModels> GetAll();
        bool Them(GiaoCaViewModels giaoCa);
        bool Sua(GiaoCaViewModels giaoCa);
        bool Xoa(Guid Id);
        Guid GetId(GiaoCaViewModels Gc);
        List<GiaoCaViewModels> TimKiem(string Ma);
    }
}
