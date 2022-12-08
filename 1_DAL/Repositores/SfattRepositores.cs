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
using System.Text.RegularExpressions;

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

        public List<NhanVien> GetAll()
        {
            return _DBcontext.NhanViens.ToList();
        }

        public bool Sua(NhanVien nhanVien)
        {
            try
            {
                var daTaCu = _DBcontext.NhanViens.Find(nhanVien.Id);
                if (daTaCu != null)
                {
                    daTaCu.Ma = nhanVien.Ma;
                    daTaCu.TenDem = nhanVien.TenDem;
                    daTaCu.Ten = nhanVien.Ten;
                    daTaCu.Ho = nhanVien.Ho;
                    daTaCu.GioiTinh = nhanVien.GioiTinh;
                    daTaCu.NamSinh = nhanVien.NamSinh;
                    daTaCu.QueQuan = nhanVien.QueQuan;
                    daTaCu.Sdt = nhanVien.Sdt;
                    daTaCu.MatKhau = nhanVien.MatKhau;
                    daTaCu.Email = nhanVien.Email;
                    daTaCu.CMND = nhanVien.CMND;
                    daTaCu.IdCv = nhanVien.IdCv;
                    daTaCu.TrangThai = nhanVien.TrangThai;
                    daTaCu.Anh = nhanVien.Anh;
                    _DBcontext.NhanViens.Update(daTaCu);
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

        public bool Them(NhanVien nhanVien)
        {
            try
            {
                _DBcontext.NhanViens.Add(nhanVien);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<NhanVien> TimKiem(string Ma)
        {

            var danhSachNhanVien = _DBcontext.NhanViens.Where(x => x.Ma.ToLower().Contains(Ma.ToLower()));

            return danhSachNhanVien.ToList();
        }

        public bool Xoa(Guid Id)
        {
            var nv1 = _DBcontext.NhanViens.Find();
            if (nv1 != null)
            {
                _DBcontext.NhanViens.Remove(nv1);
                _DBcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public NhanVien Login(string userName, string pass)
        {
            return _DBcontext.NhanViens.Where(x => (x.Email.ToUpper() == userName.ToUpper() & x.MatKhau == pass)).FirstOrDefault();
        }
    }
}
