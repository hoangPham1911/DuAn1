using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IManagerServiceSaleChiTiet
    {
        bool add(SaleChiTietThemView sale);
        bool remove(SaleChiTiet id);
        List<SaleChiTiet> getAll();

        bool update(SaleChiTietUpdateView sale);
    }
}
