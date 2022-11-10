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
    public class ProducterRepostiores : IProducterRepository
    {
        private ManagerContext _dbContext;

        public ProducterRepostiores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(Nsx producter)
        {
            _dbContext.Nsxes.Add(producter);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Nsx> getAll()
        {
            return _dbContext.Nsxes.ToList();
        }

        public bool remove(Guid id)
        {
            Nsx sp = _dbContext.Nsxes.SingleOrDefault(p => p.Id == id);
            _dbContext.Nsxes.Remove(sp);
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(Nsx product)
        {

            _dbContext.Nsxes.Update(product);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
