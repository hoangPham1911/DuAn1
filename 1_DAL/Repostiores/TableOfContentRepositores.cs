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
            throw new NotImplementedException();
        }

        public bool remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool update(DanhMuc tableOfContents)
        {
            throw new NotImplementedException();
        }
    }
}
