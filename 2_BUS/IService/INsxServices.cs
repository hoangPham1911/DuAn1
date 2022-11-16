using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface INsxServices
    {
        string add(NsxViewModels NSX);
        string remove(NsxViewModels NSX);
        string update(NsxViewModels NSX);

        List<NsxViewModels> GetNhasanxuat();
    }
}
