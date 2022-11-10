using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface ISizeShoseRepository
    {
        bool add(SizeGiay size);
        bool remove(Guid id);
        List<SizeGiay> getAll();

        bool update(SizeGiay size);
    }
}
