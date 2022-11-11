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
            _DbContext.DanhMucs.Add(tableOfContents);
            _DbContext.SaveChanges();
            return true;
        }

        public List<DanhMuc> getAll()
        {
            return _DbContext.DanhMucs.ToList();
        }

        public bool remove(Guid id)
        {
            DanhMuc hd = new DanhMuc();
            var deleteId = _DbContext.DanhMucs.SingleOrDefault(p => p.Id == id);
            _DbContext.DanhMucs.Remove(deleteId);
            _DbContext.SaveChanges();
            return true;
        }

        public bool update(DanhMuc tableOfContents)
        {
            _DbContext.DanhMucs.Update(tableOfContents);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
