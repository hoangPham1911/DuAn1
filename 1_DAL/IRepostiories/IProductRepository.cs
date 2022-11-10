using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepostiories
{
    public interface IProductRepository
    {
        bool add(HangHoa product); 
        bool remove(Guid id);
        List<HangHoa> getAll();
        bool update(HangHoa sp);
        List<HangHoa> get(string name);
    }
}
