using _1_DAL.Context;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
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

        public bool remove(SizeGiay id)
        {
            try
            {
                _DBcontext.SizeGiays.Remove(id);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(SizeGiay size)
        {
            try
            {
                _DBcontext.SizeGiays.Update(size);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
