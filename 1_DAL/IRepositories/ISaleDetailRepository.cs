using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface ISaleDetailRepository
    {
        bool add(SaleChiTiet sale);
        bool remove(SaleChiTiet id);
        List<SaleChiTiet> getAll();

        bool update(SaleChiTiet sale);
    }
}
