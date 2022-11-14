using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class SaleDetailRepositores : ISaleDetailRepository
    {
        public ManagerContext _DbContext;
        public SaleDetailRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(SaleChiTiet sale)
        {
            try
            {
                _DbContext.SaleChiTiets.Add(sale);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SaleChiTiet> getAll()
        {
            return _DbContext.SaleChiTiets.ToList();

        }

        public bool remove(SaleChiTiet id)
        {
            try
            {
                _DbContext.SaleChiTiets.Remove(id);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(SaleChiTiet sale)
        {
            try
            {
                _DbContext.SaleChiTiets.Update(sale);
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
