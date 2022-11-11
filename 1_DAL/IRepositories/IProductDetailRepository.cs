using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Models;

namespace _1.DAL.IRepostiories
{
    public interface IProductDetailRepository
    {
        bool add(ChiTietHangHoa product);
        bool remove(Guid id);
        List<ChiTietHangHoa> getAll();
        bool update(ChiTietHangHoa sp);
    }
}
