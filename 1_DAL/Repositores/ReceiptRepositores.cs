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
        public bool removeReceipt(Guid hdId)
        {
            try
            {
                HoaDon hoaDon = _dbContext.HoaDons.SingleOrDefault(p=>p.Id == hdId);
                _dbContext.HoaDons.Remove(hoaDon);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<HoaDon> TimKiemTheomaHd(string MaHd)
        {

            var dsHoaDon = _dbContext.HoaDons.Where(x => x.Ma.ToLower().Contains(MaHd.ToLower()));

            return dsHoaDon.ToList();
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
