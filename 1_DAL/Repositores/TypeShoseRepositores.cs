using _1_DAL.Context;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repostiores
{
    public class TypeShoseRepositores : ITypeShoseRepository
    {
        public ManagerContext _DbContext;
        public TypeShoseRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(LoaiGiay type)
        {
            try
            {
                _DbContext.LoaiGiays.Add(type);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LoaiGiay> getAll()
        {
            return _DbContext.LoaiGiays.ToList();
        }

        public bool remove(LoaiGiay id)
        {
            try
            {
                _DbContext.LoaiGiays.Remove(id);
                _DbContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(LoaiGiay type)
        {
            try
            {
                _DbContext.LoaiGiays.Update(type);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
