using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface IHistoryPointRepository
    {
        bool add(LichSuDiemTieuDung point);
        bool remove(LichSuDiemTieuDung id);
        List<LichSuDiemTieuDung> getAll();

        bool update(LichSuDiemTieuDung point);
    }
}
