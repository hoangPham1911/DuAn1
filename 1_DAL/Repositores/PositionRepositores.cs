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
    public class PositionRepositores : IPositionRepository
    {
        private ManagerContext _DBcontext;
        private List<ChucVu> _lstChucVu;
        public PositionRepositores()
        {
            _DBcontext = new ManagerContext();
            _lstChucVu = new List<ChucVu>();

        }

        public List<ChucVu> GetAll()
        {
            return _DBcontext.ChucVus.ToList();
        }

        public bool Sua(ChucVu chucVu)
        {
            try
            {
                var daTaCu = _DBcontext.ChucVus.Find(chucVu.Id);
                if (daTaCu != null)
                {
                    daTaCu.Id = chucVu.Id;
                    daTaCu.Ma = chucVu.Ma;
                    daTaCu.Ten = chucVu.Ten;
                    _DBcontext.ChucVus.Add(daTaCu);
                    _DBcontext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Them(ChucVu chucVu)
        {
            try
            {
                _DBcontext.ChucVus.Add(chucVu);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ChucVu> TimKiem(string Ma)
        {
            var danhSachChucVu = _DBcontext.ChucVus.Where(x => x.Ma.ToLower().Contains(Ma.ToLower()));

            return danhSachChucVu.ToList();
        }

        public bool Xoa(Guid Id)
        {
            var cv1 = _DBcontext.ChucVus.Find(Id);
            if (cv1 != null)
            {
                _DBcontext.ChucVus.Remove(cv1);
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
