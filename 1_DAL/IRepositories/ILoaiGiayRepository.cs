using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface ILoaiGiayRepository
    {
        bool add(LoaiGiay producter);
        bool remove(LoaiGiay producter);
        List<LoaiGiay> getAll();
        bool update(LoaiGiay producter);
    }
}
