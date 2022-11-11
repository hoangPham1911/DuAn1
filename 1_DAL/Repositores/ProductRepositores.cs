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
    public class ProductRepositores : IProductRepository
    {
        private ManagerContext _dbContext;


        public ProductRepositores()
        {
            _dbContext = new ManagerContext();
        }

        public bool add(HangHoa product)
        {
            try
            {
                _dbContext.SanPhams.Add(product);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<HangHoa> getAll()
        {
            return _dbContext.SanPhams.ToList();
        }

        public bool remove(HangHoa id)
        {
            try
            {
                _dbContext.SanPhams.Remove(id);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(HangHoa sp)
        {
            try
            {
                _dbContext.SanPhams.Update(sp);
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
