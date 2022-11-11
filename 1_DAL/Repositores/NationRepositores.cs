using _1_DAL.Context;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repostiores
{
    public class NationRepositores : INationRepository
    {
        public ManagerContext _DbContext;
        public NationRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(QuocGia quocGia)
        {
            try
            {
                _DbContext.QuocGias.Add(quocGia);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<QuocGia> getAll()
        {
            return _DbContext.QuocGias.ToList();
        }

        public bool remove(QuocGia id)
        {
            try
            {
                _DbContext.QuocGias.Remove(id);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public bool update(QuocGia quocGia)
        {
            try
            {
                _DbContext.QuocGias.Update(quocGia);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
