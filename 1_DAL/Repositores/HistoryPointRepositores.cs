using _1_DAL.Context;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class HistoryPointRepositores : IHistoryPointRepository
    {
        public ManagerContext _DbContext;
        public HistoryPointRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(LichSuDiemTieuDung point)
        {
            try
            {
                _DbContext.LichSuDiemTieuDungs.Add(point);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public List<LichSuDiemTieuDung> getAll()
        {
            return _DbContext.LichSuDiemTieuDungs.ToList();
        }

        public bool remove(LichSuDiemTieuDung id)
        {
            try
            {
                _DbContext.LichSuDiemTieuDungs.Remove(id);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool update(LichSuDiemTieuDung point)
        {
            try
            {
                _DbContext.LichSuDiemTieuDungs.Update(point);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
