using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface ISaleService
    {
        bool add(SaleViewModel sale);
        bool remove(SaleViewModel sale);
        bool update(SaleViewModel sale);

        List<SaleViewModel> GetDanhMuc();
    }
}
