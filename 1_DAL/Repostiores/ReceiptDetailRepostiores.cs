using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IRepositories;
using _1.DAL.IRepostiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repostiores
{
    public class ReceiptDetailRepostiores : IreceiptDetailRepository
    {
        public ManagerContext _dbContext;
        public Nsx _nsx;

        public ReceiptDetailRepostiores()
        {
            _dbContext = new ManagerContext();

        }

        public bool add(HoaDonChiTiet hd)
        {
            _dbContext.HoaDonChiTiets.Add(hd);
            _dbContext.SaveChanges();

            return true;
        }

        public List<HoaDonChiTiet> GetAll()
        {
            return _dbContext.HoaDonChiTiets.ToList();
        }

        public bool remove( Guid IdSpCt)
        {
            HoaDonChiTiet Spct = _dbContext.HoaDonChiTiets.SingleOrDefault(p => p.IdChiTietSp == IdSpCt);
            _dbContext.HoaDonChiTiets.Remove(Spct);
            _dbContext.SaveChanges();

            return true;
        }
        public bool update(HoaDonChiTiet hd)
        {

            _dbContext.HoaDonChiTiets.Update(hd);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
