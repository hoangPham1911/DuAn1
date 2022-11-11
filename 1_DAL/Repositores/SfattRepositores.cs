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
    public class SfattRepositores : ISfattRepository
    {
        private ManagerContext _DBcontext;
        private List<NhanVien> _lstNhanVien;

        public SfattRepositores()
        {
            _DBcontext = new ManagerContext();
            _lstNhanVien = new List<NhanVien>();
        }
        public bool addNhanVien(NhanVien nhanVien)
        {
            try
            {
                _DBcontext.NhanViens.Add(nhanVien);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deleteNhanVien(NhanVien nhanVien)
        {
            try
            {
                _DBcontext.NhanViens.Remove(nhanVien);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<NhanVien> getNhanViensFromDB()
        {
            _lstNhanVien = _DBcontext.NhanViens.ToList();
            return _lstNhanVien;
        }

        public bool updateNhanVien(NhanVien nhanVien)
        {
            try
            {
                _DBcontext.NhanViens.Update(nhanVien);
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
