using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface ITichDiemRepositores
    {
        bool add(ViDiem type);
        bool remove(Guid id);
        List<ViDiem> getAll();

        bool update(ViDiem type);
    }
}
