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
    public class ClientRepostiores : IClientRepository
    {
        private ManagerContext _dbContext;
        public ClientRepostiores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(KhachHang client)
        {
            if (client == null) return false;
            _dbContext.KhachHangs.Add(client);
            _dbContext.SaveChanges();
         
            return true;
        }

        public List<KhachHang> getAll()
        {
            return _dbContext.KhachHangs.ToList();
        }

        public bool remove(Guid id)
        {
            KhachHang sp = new KhachHang();
            var deleteId = _dbContext.KhachHangs.SingleOrDefault(p => p.Id == id);
            if (deleteId == null) return false;
            _dbContext.KhachHangs.Remove(deleteId);
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(KhachHang clinet)
        {
            if(clinet == null) return false;      
            _dbContext.KhachHangs.Update(clinet);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
