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
    public class ProductDetailRepositores : IProductDetailRepository
    {
        private ManagerContext _dbContext;

        public ProductDetailRepositores()
        {
            _dbContext = new ManagerContext();
        }

        public bool add(ChiTietHangHoa product)
        {
            try
            {
                _dbContext.ChiTietSps.Add(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ChiTietHangHoa> getAll()
        {
            return _dbContext.ChiTietSps.ToList();
        }

        public bool update(ChiTietHangHoa Product)
        {

            try
            {
                _dbContext.ChiTietSps.Update(Product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool remove(Guid id)
        {
            try
            {
                var deleteId = _dbContext.ChiTietSps.SingleOrDefault(p => p.Id == id);
                _dbContext.ChiTietSps.Remove(deleteId);
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
