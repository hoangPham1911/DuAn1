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
namespace _1.DAL.DALServices
{
    public class SfattRepository : ISfattRepository
    {
        private ManagerContext _DBcontext;
        private List<NhanVien> _lstNhanVien;

        public SfattRepository()
        {
            _DBcontext = new ManagerContext();
            _lstNhanVien = new List<NhanVien>();
        }
        public bool addNhanVien(NhanVien nhanVien)
        {
            _DBcontext.NhanViens.Add(nhanVien);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteNhanVien(NhanVien nhanVien)
        {
            _DBcontext.NhanViens.Remove(nhanVien);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<NhanVien> getNhanViensFromDB()
        {
            _lstNhanVien = _DBcontext.NhanViens.ToList();
            return _lstNhanVien;
        }

        public bool updateNhanVien(NhanVien nhanVien)
        {
            _DBcontext.NhanViens.Update(nhanVien);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
