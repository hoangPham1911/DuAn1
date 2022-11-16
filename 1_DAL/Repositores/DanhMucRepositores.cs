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
    public class DanhMucRepositores : IDanhMucRepository
    {
        public ManagerContext _DbContext;
        public DanhMucRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(DanhMuc tableOfContents)
        {
            try
            {
                tableOfContents.Id = Guid.NewGuid();
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

        public bool remove(DanhMuc tableOfContents)
        {
            if (tableOfContents == null) return false;
            var temtableOfContents = _DbContext.DanhMucs.FirstOrDefault(p => p.Id == tableOfContents.Id);
            _DbContext.DanhMucs.Remove(temtableOfContents);
            _DbContext.SaveChanges();
            return true;
        }

        public bool update(DanhMuc tableOfContents)
        {
            if (tableOfContents == null) return false;
            var temtableOfContents = _DbContext.DanhMucs.FirstOrDefault(p => p.Id == tableOfContents.Id);
            temtableOfContents.Ma = tableOfContents.Ma;
            temtableOfContents.Ten = tableOfContents.Ten;
            temtableOfContents.TrangThai = tableOfContents.TrangThai;
            temtableOfContents.IdDanhMucKhac = tableOfContents.IdDanhMucKhac;
            _DbContext.DanhMucs.Update(temtableOfContents);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
