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
            try
            {
                _DbContext.KieuDanhMucs.Add(tableOfContents);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<KieuDanhMuc> getAll()
        {
            return _DbContext.KieuDanhMucs.ToList();
        }

        public bool remove(Guid id)
        {
            try
            {
                KieuDanhMuc hd = new KieuDanhMuc();
                var deleteId = _DbContext.KieuDanhMucs.SingleOrDefault(p => p.IdDanhMuc == id);
                _DbContext.KieuDanhMucs.Remove(deleteId);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(KieuDanhMuc tableOfContents)
        {
            try
            {
                _DbContext.KieuDanhMucs.Update(tableOfContents);
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
