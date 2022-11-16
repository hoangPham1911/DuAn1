using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface ISaleChiTietService 
    {
        bool add(SaleChiTietThemView sale);
        bool remove(SaleChiTietViewModels sale);
        bool update(SaleChiTietUpdateView sale);

        List<SaleChiTietViewModels> GetDanhMuc();
    }
}
