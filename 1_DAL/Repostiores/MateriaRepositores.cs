using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IDALServices;
using _1.DAL.IRepostiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.IRepostiories;

namespace _1.DAL.DALServices
{
    public class MateriaRepositores : IMaterialRepository
    {
        private ManagerContext _DBcontext;
        private List<ChatLieu> _lstCuaHang;

        public MateriaRepositores()
        {
            _DBcontext = new ManagerContext();
            _lstCuaHang = new List<ChatLieu>();
        }
        public bool addMaterial(ChatLieu material)
        {
            _DBcontext.ChatLieus.Add(material);
            _DBcontext.SaveChanges();
            return true;
        }
        public bool updateMaterial(ChatLieu material)
        {
            _DBcontext.ChatLieus.Update(material);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteMaterial(ChatLieu material)
        {
            _DBcontext.ChatLieus.Remove(material);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<ChatLieu> getMaterialFromDB()
        {
            _lstCuaHang = _DBcontext.ChatLieus.ToList();
            return _lstCuaHang;
        }
    }
}
