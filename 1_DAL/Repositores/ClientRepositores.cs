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
    public class ClientRepositores : IClientRepository
    {
        private ManagerContext _dbContext;
        public ClientRepositores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(KhachHang client)
        {
            try
            {
                _dbContext.KhachHangs.Add(client);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
          
        }

        public List<KhachHang> getAll()
        {
            return _dbContext.KhachHangs.ToList();
        }

        public bool remove(KhachHang id)
        {
            try
            {
                _dbContext.KhachHangs.Remove(id);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
           
        }

        public bool update(KhachHang clinet)
        {
            try
            {
                _dbContext.KhachHangs.Update(clinet);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
