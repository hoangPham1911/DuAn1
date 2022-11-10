using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface IHistoryPoint
    {
        bool add(LichSuDiemTieuDung point);
        bool remove(Guid id);
        List<LichSuDiemTieuDung> getAll();

        bool update(LichSuDiemTieuDung point);
    }
}
