using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repostiores
{
    public class receiptRepostiores : IreceiptRepository
    {
        public ManagerContext _dbContext;
        public receiptRepostiores()
        {
            _dbContext = new ManagerContext();
           
        }
        public bool addReceipt(HoaDon hd)
        {
            _dbContext.HoaDons.Add(hd);
            _dbContext.SaveChanges();

            return true;
        }
        public List<HoaDon> getAllReceipt()
        {
            return _dbContext.HoaDons.ToList();

        }
        public bool removeReceipt(Guid hdId)
        {
            HoaDon hd = new HoaDon();
            var deleteId = _dbContext.HoaDons.SingleOrDefault(p => p.Id == hdId);
            _dbContext.HoaDons.Remove(deleteId);
            _dbContext.SaveChanges();
            return true;
        }
        public bool updateReceipt(HoaDon hd)
        {
          
            _dbContext.HoaDons.Update(hd);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
