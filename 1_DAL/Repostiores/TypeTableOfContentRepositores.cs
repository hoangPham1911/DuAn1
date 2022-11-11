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
    public class TypeTableOfContentRepositores : ITypeTableOfContents
    {
        public ManagerContext _DbContext;
        public TypeTableOfContentRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(KieuDanhMuc tableOfContents)
        {
            _DbContext.KieuDanhMucs.Add(tableOfContents);
            _DbContext.SaveChanges();
            return true;
        }

        public List<KieuDanhMuc> getAll()
        {
            throw new NotImplementedException();
        }

        public bool remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool update(KieuDanhMuc tableOfContents)
        {
            throw new NotImplementedException();
        }
    }
}
