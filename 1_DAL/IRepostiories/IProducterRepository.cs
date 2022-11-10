using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepostiories
{
    public interface IProducterRepository
    {
        bool add(Nsx producter);
        bool remove(Guid id);
        List<Nsx> getAll();
        bool update(Nsx producter);
    }
}
