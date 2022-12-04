using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class TichDiemRepositores : ITichDiemRepositores
    {
        private ManagerContext _DBcontext;
        public TichDiemRepositores()
        {
            _DBcontext = new ManagerContext();
        }
        public bool add(ViDiem diem)
        {
            try
            {
                _DBcontext.ViDiems.Add(diem);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ViDiem> getAll()
        {
           return _DBcontext.ViDiems.ToList();
        }

        public bool remove(Guid id)
        {
            try
            {
                ViDiem vi = _DBcontext.ViDiems.SingleOrDefault(p => p.Id == id);
                _DBcontext.ViDiems.Remove(vi);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(ViDiem diem)
        {
            try
            {
                _DBcontext.ViDiems.Update(diem);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
