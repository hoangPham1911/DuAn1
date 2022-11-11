using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface INationRepository
    {
        bool add(QuocGia quocGia);
        bool remove(QuocGia id);
        List<QuocGia> getAll();

        bool update(QuocGia quocGia);
    }
}
