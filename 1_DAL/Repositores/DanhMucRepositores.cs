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
    public class TableOfContentRepositores : ITableOfContentsRepository
    {
        public ManagerContext _DbContext;
        public TableOfContentRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(DanhMuc tableOfContents)
        {
            try
            {
                _DbContext.DanhMucs.Add(tableOfContents);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DanhMuc> getAll()
        {
            return _DbContext.DanhMucs.ToList();
        }

        public bool remove(DanhMuc id)
        {
            try
            {
                _DbContext.DanhMucs.Remove(id);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(DanhMuc tableOfContents)
        {
            try
            {
                _DbContext.DanhMucs.Update(tableOfContents);
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
