using _1_DAL.Context;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repostiores
{
    public class SizeShoseRepositores : ISizeShoseRepository
    {
        private ManagerContext _DBcontext;
        public SizeShoseRepositores()
        {
            _DBcontext = new ManagerContext();
        }
        public bool add(SizeGiay size)
        {
            try
            {
                size.Id = Guid.NewGuid();
                _DBcontext.SizeGiays.Add(size);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SizeGiay> getAll()
        {
            return _DBcontext.SizeGiays.ToList();
        }

        public bool remove(SizeGiay size)
        {
            if (size == null) return false;
            var temsize = _DBcontext.SizeGiays.FirstOrDefault(p => p.Id == size.Id);
            _DBcontext.SizeGiays.Remove(temsize);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool update(SizeGiay size)
        {
            if (size == null) return false;
            var temsize = _DBcontext.SizeGiays.FirstOrDefault(p => p.Id == size.Id);
            temsize.Ma = size.Ma;
            temsize.SoSize = size.SoSize;
            temsize.TrangThai = size.TrangThai;
            _DBcontext.SizeGiays.Update(temsize);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
