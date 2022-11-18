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
    public class QuocGiaRepositores : IQuocGiaRepository
    {
        private ManagerContext _dbContext;

        public QuocGiaRepositores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(QuocGia producter)
        {
            if (producter == null) return false;
            producter.Id = Guid.NewGuid();
            _dbContext.QuocGias.Add(producter);
            _dbContext.SaveChanges();
            return true;

        }

        public List<QuocGia> getAll()
        {
            return _dbContext.QuocGias.ToList();
        }

        public bool remove(QuocGia producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.QuocGias.FirstOrDefault(p => p.Id == producter.Id);
            _dbContext.QuocGias.Remove(temproducter);
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(QuocGia producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.QuocGias.FirstOrDefault(p => p.Id == producter.Id);
            temproducter.Ma = producter.Ma;
            temproducter.Ten = producter.Ten;
            temproducter.TrangThai = producter.TrangThai;
            _dbContext.QuocGias.Update(temproducter);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
