using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class GiaoCaRepositores : IGiaoCaRepository
    {
        private ManagerContext _DBcontext;
        private List<GiaoCa> _lstGiaoCa;

        public GiaoCaRepositores()
        {
            _DBcontext = new ManagerContext();
            _lstGiaoCa = new List<GiaoCa>();
        }
        public List<GiaoCa> GetAll()
        {
            return _DBcontext.GiaoCas.ToList();
        }

        public bool Sua(GiaoCa giaoCa)
        {
            try
            {
                var daTaCu = _DBcontext.GiaoCas.Find(giaoCa.Id);
                if (daTaCu != null)
                {
                    daTaCu.Ma = giaoCa.Ma;
                    daTaCu.ThoiGianNhanCa = giaoCa.ThoiGianNhanCa;
                    daTaCu.ThoiGianGiaoCa = giaoCa.ThoiGianGiaoCa;
                    daTaCu.IdNvNhanCaTiep = giaoCa.IdNvNhanCaTiep;
                    daTaCu.IdNvTrongCa = giaoCa.IdNvTrongCa;
                    daTaCu.TienBanDau = giaoCa.TienBanDau;
                    daTaCu.TongTienTrongCa = giaoCa.TongTienTrongCa;
                    daTaCu.TongTienMat = giaoCa.TongTienMat;
                    daTaCu.TongTienKhac = giaoCa.TongTienKhac;
                    daTaCu.TienPhatSinh = giaoCa.TienPhatSinh;
                    daTaCu.GhiChuPhatSinh = giaoCa.GhiChuPhatSinh;
                    daTaCu.TongTienCaTruoc = giaoCa.TongTienCaTruoc;
                    daTaCu.Time = giaoCa.Time;
                    daTaCu.TongTienMatRut = giaoCa.TongTienMat;
                    daTaCu.TrangThai = giaoCa.TrangThai;
                    _DBcontext.GiaoCas.Update(daTaCu);
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

        public bool Them(GiaoCa giaoCa)
        {
            try
            {
                _DBcontext.GiaoCas.Add(giaoCa);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GiaoCa> TimKiem(string Ma)
        {
            var danhSachGiaoCa = _DBcontext.GiaoCas.Where(x => x.Ma.ToLower().Contains(Ma.ToLower()));

            return danhSachGiaoCa.ToList();
        }

        public bool Xoa(Guid Id)
        {
            var c1 = _DBcontext.GiaoCas.Find(Id);
            if (c1 != null)
            {
                _DBcontext.GiaoCas.Remove(c1);
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
