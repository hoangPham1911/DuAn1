using _1.DAL.DALServices;
using _1.DAL.IDALServices;
using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class NhanVienServices : INhanVienServices
    {
        private ISfattRepository _sfattRepository;
        public NhanVienServices()
        {
            _sfattRepository = new SfattRepositores();
        }
        public List<NhanVienViewModels> GetAll()
        {
            var lstNhanVienModel = _sfattRepository.GetAll();
            var lstNhanVienViewModel = new List<NhanVienViewModels>();
            foreach (var item in lstNhanVienModel)
            {
                var nv2 = new NhanVienViewModels
                {
                    Id = item.Id,
                    Ma = item.Ma,
                    Ho = item.Ho,
                    TenDem = item.TenDem,
                    Ten = item.Ten,
                    GioiTinh = item.GioiTinh,
                    NamSinh = item.NamSinh,
                    QueQuan = item.QueQuan,
                    Sdt = item.Sdt,
                    MatKhau = item.MatKhau,
                    Email = item.Email,
                    CMND = item.CMND,
                    IdCv = item.IdCv,
                    TrangThai = item.TrangThai,
                    Anh = item.Anh,
                };
                lstNhanVienViewModel.Add(nv2);
            }
            return lstNhanVienViewModel;

            //var lstnhanViens = from chucVu in GetAll()
            //                   join nhanVien in GetAll() on chucVu.Id equals nhanVien.IdCv
            //                   select new NhanVien
            //                   {
            //                       IdCv = chucVu.Id,
            //                       Id = nhanVien.Id
            //                   };

        }

        public bool Sua(NhanVienViewModels nhanVien)
        {
            var nhanVenModel = new NhanVien
            {
                Id = nhanVien.Id,
                Ma = nhanVien.Ma,
                Ho = nhanVien.Ho,
                TenDem = nhanVien.TenDem,
                Ten = nhanVien.Ten,
                GioiTinh = nhanVien.GioiTinh,
                NamSinh = nhanVien.NamSinh,
                QueQuan = nhanVien.QueQuan,
                Sdt = nhanVien.Sdt,
                MatKhau = nhanVien.MatKhau,
                Email = nhanVien.Email,
                CMND = nhanVien.CMND,
                IdCv = nhanVien.IdCv,
                TrangThai = nhanVien.TrangThai,
                Anh = nhanVien.Anh,

            };
            var relut = _sfattRepository.Sua(nhanVenModel);
            return relut;
        }

        public bool Them(NhanVienViewModels nhanVien)
        {

            var nhanVenModel = new NhanVien
            {
                Id = new Guid(),
                Ma = nhanVien.Ma,
                Ho = nhanVien.Ho,
                TenDem = nhanVien.TenDem,
                Ten = nhanVien.Ten,
                GioiTinh = nhanVien.GioiTinh,
                NamSinh = nhanVien.NamSinh,
                QueQuan = nhanVien.QueQuan,
                Sdt = nhanVien.Sdt,
                MatKhau = nhanVien.MatKhau,
                Email = nhanVien.Email,
                CMND = nhanVien.CMND,
                IdCv = nhanVien.IdCv,
                TrangThai = nhanVien.TrangThai,
                Anh = nhanVien.Anh,

            };
            var relut = _sfattRepository.Them(nhanVenModel);
            return relut;
        }

        public List<NhanVienViewModels> TimKiem(string Ma)
        {
            var lstNhanVienModel = _sfattRepository.TimKiem(Ma);
            var lstNhanVienViewModel = new List<NhanVienViewModels>();
            foreach (var item in lstNhanVienModel)
            {
                var nv2 = new NhanVienViewModels
                {
                    Id = item.Id,
                    Ma = item.Ma,
                    Ho = item.Ho,
                    TenDem = item.TenDem,
                    Ten = item.Ten,
                    GioiTinh = item.GioiTinh,
                    NamSinh = item.NamSinh,
                    QueQuan = item.QueQuan,
                    Sdt = item.Sdt,
                    MatKhau = item.MatKhau,
                    Email = item.Email,
                    CMND = item.CMND,
                    IdCv = item.IdCv,
                    TrangThai = item.TrangThai,
                    Anh = item.Anh,
                };
                lstNhanVienViewModel.Add(nv2);
            }
            return lstNhanVienViewModel;
        }

        public bool Xoa(Guid Id)
        {
            var kq = _sfattRepository.Xoa(Id);
            return kq;
        }

        public NhanVienViewModels Login(string ma, string pass)
        {
            var user = _sfattRepository.Login(ma,pass);
            if (user != null)
            {
                return new NhanVienViewModels
                {
                    Id = user.Id,
                    Ho = user.Ho,
                    TenDem = user.TenDem,
                    Ten = user.Ten
                };
            }
            else 
                return null;
        }
    }
}
