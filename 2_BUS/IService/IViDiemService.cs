using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IViDiemService
    {
        bool add(ViDiemViewModel vi);
        bool remove(Guid vi);
        bool update(ViDiemViewModel vi);

        List<ViDiemViewModel> GetViDiem();
    }
}
