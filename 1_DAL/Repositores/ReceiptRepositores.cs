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
    public class ReceiptRepositores : IreceiptRepository
    {
        public ManagerContext _dbContext;
        public ReceiptRepositores()
        {
            _dbContext = new ManagerContext();
           
        }
        public bool addReceipt(HoaDon hd)
        {
            try
            {
                _dbContext.HoaDons.Add(hd);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<HoaDon> getAllReceipt()
        {
            return _dbContext.HoaDons.ToList();

        }
        public bool removeReceipt(HoaDon hdId)
        {
            try
            {
                _dbContext.HoaDons.Remove(hdId);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool updateReceipt(HoaDon hd)
        {

            try
            {
                _dbContext.HoaDons.Update(hd);
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
