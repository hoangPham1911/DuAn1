using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IRepostiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repostiores
{
    public class ProducterRepositores : IProducterRepository
    {
        private ManagerContext _dbContext;

        public ProducterRepositores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(Nsx producter)
        {
            try
            {
                _dbContext.Nsxes.Add(producter);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Nsx> getAll()
        {
            return _dbContext.Nsxes.ToList();
        }

        public bool remove(Nsx id)
        {
            try
            {
                _dbContext.Nsxes.Remove(id);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(Nsx product)
        {

            try
            {
                _dbContext.Nsxes.Update(product);
                _dbContext.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
