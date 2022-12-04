using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IBangQuyDoiDiemServices
    {
        bool add(BangQuyDoiDiemViewModels vi);
        bool remove(Guid vi);
        bool update(BangQuyDoiDiemViewModels vi);

        List<BangQuyDoiDiemViewModels> GetDiem();
    }
}
