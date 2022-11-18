using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IQuocGiaServices
    {
        string add(QuocGiaViewModels quocgia);
        string remove(QuocGiaViewModels quocgia);
        string update(QuocGiaViewModels quocgia);

        List<QuocGiaViewModels> GetQuocGia();
    }
}
