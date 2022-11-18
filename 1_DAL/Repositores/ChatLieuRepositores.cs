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
    public class ChatLieuRepositores : IChatLieuRepository
    {
        private ManagerContext _dbContext;
        public ChatLieuRepositores()
        {
            _dbContext = new ManagerContext();
        }
        public bool add(ChatLieu producter)
        {
            if (producter == null) return false;
            producter.Id = Guid.NewGuid();
            _dbContext.ChatLieus.Add(producter);
            _dbContext.SaveChanges();
            return true;
        }

        public List<ChatLieu> getAll()
        {
            return _dbContext.ChatLieus.ToList();
        }

        public bool remove(ChatLieu producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.ChatLieus.FirstOrDefault(p => p.Id == producter.Id);
            _dbContext.ChatLieus.Remove(temproducter);
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(ChatLieu producter)
        {
            if (producter == null) return false;
            var temproducter = _dbContext.ChatLieus.FirstOrDefault(p => p.Id == producter.Id);
            temproducter.Ma = producter.Ma;
            temproducter.Ten = producter.Ten;
            temproducter.TrangThai = producter.TrangThai;
            _dbContext.ChatLieus.Update(temproducter);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
