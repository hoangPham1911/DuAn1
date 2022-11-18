using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IRepostiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace _1.DAL.Repostiores
{
    public class NsxRepositores : INsxRepository
    {
        private ManagerContext _dbContext;

        public NsxRepositores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(Nsx producter)
        {
            if (producter == null) return false;
            producter.Id = Guid.NewGuid();
            _dbContext.Nsxes.Add(producter);
            _dbContext.SaveChanges();
            return true;
            
        }

        public List<Nsx> getAll()
        {
            X500DistinguishedName = 
            return ;
        }

        public bool remove(Nsx producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.Nsxes.FirstOrDefault(p=>p.Id==producter.Id);  
            _dbContext.Nsxes.Remove(temproducter);
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(Nsx producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.Nsxes.FirstOrDefault(p => p.Id == producter.Id);
            temproducter.Ma = producter.Ma;
            temproducter.Ten = producter.Ten;
            temproducter.TrangThai = producter.TrangThai;
            _dbContext.Nsxes.Update(temproducter);
            _dbContext.SaveChanges();
            return true;

        }
    }
}
