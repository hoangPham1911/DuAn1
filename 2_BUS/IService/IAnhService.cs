using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IAnhService
    {
        bool add(AnhViewModels img);
        bool remove(AnhViewModels img);
        bool update(AnhViewModels img);

        List<AnhViewModels> GetDanhMuc();
    }
}
