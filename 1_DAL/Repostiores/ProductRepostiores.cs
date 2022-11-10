using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IRepostiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repostiores
{
    public class productRepostiores : IProductRepository
    {
        private ManagerContext _dbContext;


        public productRepostiores()
        {
            _dbContext = new ManagerContext();
        }

        public bool add(HangHoa product)
        {
            _dbContext.SanPhams.Add(product);
            _dbContext.SaveChanges();

            return true;
        }

        public List<HangHoa> get(string name)
        {
            return _dbContext.SanPhams.Where(p => p.Ten.Contains(name)).ToList();
        }

        public List<HangHoa> getAll()
        {
            return _dbContext.SanPhams.ToList();
        }

        public bool remove(Guid id)
        {
            var deleteId = _dbContext.SanPhams.SingleOrDefault(p => p.Id == id);
            _dbContext.SanPhams.Remove(deleteId);
            _dbContext.SaveChanges();

            return true;
        }

        public bool update(HangHoa sp)
        {
            if (sp == null) return false;
            _dbContext.SanPhams.Update(sp);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
