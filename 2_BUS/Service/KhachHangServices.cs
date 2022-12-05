using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class KhachHangServices : IKhachHangServices
    {
        private IClientRepository _khachHangRepository;
        private List<KhachHangViewModels> _khachHangViewModels;
        private ITichDiemRepositores _TichDiemRepositores;
        public KhachHangServices()
        {
            _khachHangRepository = new ClientRepositores();
            _khachHangViewModels = new List<KhachHangViewModels>();
            _TichDiemRepositores = new TichDiemRepositores();
        }

        public List<KhachHangViewModels> GetAllDiemKhachHang()
        {
            throw new NotImplementedException();
        }
        public List<KhachHangViewModels> GetAllKhachHangDB()
        {        
              return  (from a in _khachHangRepository.getAll() 
                       join b in _TichDiemRepositores.getAll() on a.IdVi equals b.Id 
                       into kh_table from p in kh_table.DefaultIfEmpty()
                 select new KhachHangViewModels()
                 {
                     Idkh = a.Id,
                     Ma = a.Ma,
                     Ten = a.Ten,
                     GioiTinh = a.GioiTinh,
                     Email = a.Email,
                     SoCCCD = a.SoCCCD,
                     NamSinh = a.NamSinh,
                     Sdt = a.Sdt,
                     DiaChi = a.DiaChi,
                     TrangThai = a.TrangThai,
                     IdVi = p == null ?null: p.Id,
                     tongDiem = p == null ? 0: p.TongDiem

                 }).ToList();
        }

        public string SuaKhachHang(SuaKhachHangViewModels obj)
        {
            if (obj == null) return "Sửa không thành công";
            var x = _khachHangRepository.getAll().FirstOrDefault(p => p.Id == obj.Idkh);
            x.Ma = obj.Ma;
            x.Ten = obj.Ten;
            x.GioiTinh = obj.GioiTinh;
            x.Email = obj.Email;
            x.SoCCCD = obj.SoCCCD;
            x.NamSinh = obj.NamSinh;
            x.Sdt = obj.Sdt;
            x.DiaChi = obj.DiaChi;
            x.TrangThai = obj.TrangThai;

            if (_khachHangRepository.update(x)) return "Sửa thành công";
            return "Sửa không thành công";
        }

        public string ThemKhachHang(ThemKhachHangViewModels obj)
        {
            if(obj == null) return "Thêm không thành công";
            KhachHang khachHang = new KhachHang()
            {
                Ma = obj.Ma,
                Ten = obj.Ten,
                GioiTinh = obj.GioiTinh,
                Email = obj.Email,
                SoCCCD = obj.SoCCCD,
                NamSinh = obj.NamSinh,
                Sdt = obj.Sdt,
                DiaChi = obj.DiaChi,
                TrangThai = obj.TrangThai,
 
            };

            if (_khachHangRepository.add(khachHang)) return "Thêm thành công";
            return "Thêm không thành công";
        }

        public string XoaKhachHang(Guid idKh)
        {
            if (idKh == null) return "Xóa không thành công";
            var x = _khachHangRepository.getAll().FirstOrDefault(p => p.Id == idKh);
            if (_khachHangRepository.remove(x)) return "Xóa thành công";
            return "Xóa không thành công";
        }
    }
}
