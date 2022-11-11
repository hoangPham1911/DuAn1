using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface ITypeShoseRepository
    {
        bool add(LoaiGiay type);
        bool remove(LoaiGiay id);
        List<LoaiGiay> getAll();

        bool update(LoaiGiay type);
    }
}
