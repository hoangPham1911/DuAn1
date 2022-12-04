using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class BangQuyDoiDiemRepositories : IBangQuyDoiDiem
    {
        ManagerContext ManagerContext;
        public BangQuyDoiDiemRepositories()
        {
            ManagerContext = new ManagerContext();
        }
        public bool add(QuyDoiDiem diem)
        {
            try
            {
                ManagerContext.QuyDoiDiems.Add(diem);
                ManagerContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
          
        }

        public List<QuyDoiDiem> getAll()
        {
            return ManagerContext.QuyDoiDiems.ToList();
        }

        public bool remove(Guid id)
        {
            try
            {
                QuyDoiDiem diem = ManagerContext.QuyDoiDiems.SingleOrDefault(p => p.Id == id);
                ManagerContext.QuyDoiDiems.Remove(diem);
                ManagerContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool update(QuyDoiDiem diem)
        {
            try
            {
                ManagerContext.QuyDoiDiems.Update(diem);
                ManagerContext.SaveChanges();
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
