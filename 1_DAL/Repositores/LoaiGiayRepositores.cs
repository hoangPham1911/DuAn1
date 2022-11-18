using _1_DAL.Context;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.IRepositories;

namespace _1_DAL.Repositores
{
    public class LoaiGiayRepositores : ILoaiGiayRepository
    {
        private ManagerContext _dbContext;

        public LoaiGiayRepositores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(LoaiGiay producter)
        {
            if (producter == null) return false;
            producter.Id = Guid.NewGuid();
            _dbContext.LoaiGiays.Add(producter);
            _dbContext.SaveChanges();
            return true;
        }

        public List<LoaiGiay> getAll()
        {
            return _dbContext.LoaiGiays.ToList();
        }

        public bool remove(LoaiGiay producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.LoaiGiays.FirstOrDefault(p => p.Id == producter.Id);
            _dbContext.LoaiGiays.Remove(temproducter);
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(LoaiGiay producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.LoaiGiays.FirstOrDefault(p => p.Id == producter.Id);
            temproducter.Ma = producter.Ma;
            temproducter.Ten = producter.Ten;
            temproducter.TrangThai = producter.TrangThai;
            _dbContext.LoaiGiays.Update(temproducter);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
