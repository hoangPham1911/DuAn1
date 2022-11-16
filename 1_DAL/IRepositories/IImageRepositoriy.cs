using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IImageRepositoriy
    {
        bool add(Anh image);
        bool remove(Anh image);
        List<Anh> getAll();

        bool update(Anh image);
    }
}
