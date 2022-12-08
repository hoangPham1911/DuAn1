using _1.DAL.IDALServices;
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
    public class GiaoCaServices : IGiaoCaServices
    {
        private IGiaoCaRepository _giaoCaRepository;

        public GiaoCaServices()
        {
            _giaoCaRepository = new GiaoCaRepositores();
        }
        public List<GiaoCaViewModels> GetAll()
        {
            var lstGiaoCaModel = _giaoCaRepository.GetAll();
            var lstGiaoCaViewModel = new List<GiaoCaViewModels>();
            foreach (var item in lstGiaoCaModel)
            {
                var gC2 = new GiaoCaViewModels
                {
                    Id = item.Id,
                    Ma = item.Ma,
                    ThoiGianNhanCa = item.ThoiGianNhanCa,
                    ThoiGianGiaoCa= item.ThoiGianGiaoCa,
                    IdNvNhanCaTiep= item.IdNvNhanCaTiep,
                    IdNvTrongCa = item.IdNvTrongCa,
                    TienBanDau= item.TienBanDau,
                    TongTienTrongCa= item.TongTienTrongCa,
                    TongTienMat = item.TongTienMat,
                    TongTienKhac =item.TongTienKhac,
                    TienPhatSinh =item.TienPhatSinh,
                    GhiChuPhatSinh= item.GhiChuPhatSinh,
                    TongTienCaTruoc= item.TongTienCaTruoc,
                    Time = item.Time,
                    TongTienMatRut= item.TongTienMatRut,
                    TrangThai = item.TrangThai,

                };
                lstGiaoCaViewModel.Add(gC2);
            }
            return lstGiaoCaViewModel;
        }

        public bool Sua(GiaoCaViewModels giaoCa)
        {
            var GiaoCaModel = new GiaoCa
            {
                Id = giaoCa.Id,
                Ma = giaoCa.Ma,
                ThoiGianNhanCa = giaoCa.ThoiGianNhanCa,
                ThoiGianGiaoCa = giaoCa.ThoiGianGiaoCa,
                IdNvNhanCaTiep = giaoCa.IdNvNhanCaTiep,
                IdNvTrongCa = giaoCa.IdNvTrongCa,
                TienBanDau = giaoCa.TienBanDau,
                TongTienTrongCa = giaoCa.TongTienTrongCa,
                TongTienMat = giaoCa.TongTienMat,
                TongTienKhac = giaoCa.TongTienKhac,
                TienPhatSinh = giaoCa.TienPhatSinh,
                GhiChuPhatSinh = giaoCa.GhiChuPhatSinh,
                TongTienCaTruoc = giaoCa.TongTienCaTruoc,
                Time = giaoCa.Time,
                TongTienMatRut = giaoCa.TongTienMatRut,
                TrangThai = giaoCa.TrangThai,

            };
            var relut = _giaoCaRepository.Sua(GiaoCaModel);
            return relut;
        }

        public bool Them(GiaoCaViewModels giaoCa)
        {
            var GiaoCaModel = new GiaoCa
            {
                Id = new Guid(),
                Ma = giaoCa.Ma,
                ThoiGianNhanCa = giaoCa.ThoiGianNhanCa,
                ThoiGianGiaoCa = giaoCa.ThoiGianGiaoCa,
                IdNvNhanCaTiep = giaoCa.IdNvNhanCaTiep,
                IdNvTrongCa = giaoCa.IdNvTrongCa,
                TienBanDau = giaoCa.TienBanDau,
                TongTienTrongCa = giaoCa.TongTienTrongCa,
                TongTienMat = giaoCa.TongTienMat,
                TongTienKhac = giaoCa.TongTienKhac,
                TienPhatSinh = giaoCa.TienPhatSinh,
                GhiChuPhatSinh = giaoCa.GhiChuPhatSinh,
                TongTienCaTruoc = giaoCa.TongTienCaTruoc,
                Time = giaoCa.Time,
                TongTienMatRut = giaoCa.TongTienMatRut,
                TrangThai = giaoCa.TrangThai,

            };
            var relut = _giaoCaRepository.Them(GiaoCaModel);
            return relut;
        }

        public List<GiaoCaViewModels> TimKiem(string Ma)
        {
            var lstGiaoCaModel = _giaoCaRepository.TimKiem(Ma);
            var lstGiaoCaViewModel = new List<GiaoCaViewModels>();
            foreach (var item in lstGiaoCaModel)
            {
                var gC2 = new GiaoCaViewModels
                {
                    Id = item.Id,
                    Ma = item.Ma,
                    ThoiGianNhanCa = item.ThoiGianNhanCa,
                    ThoiGianGiaoCa = item.ThoiGianGiaoCa,
                    IdNvNhanCaTiep = item.IdNvNhanCaTiep,
                    IdNvTrongCa = item.IdNvTrongCa,
                    TienBanDau = item.TienBanDau,
                    TongTienTrongCa = item.TongTienTrongCa,
                    TongTienMat = item.TongTienMat,
                    TongTienKhac = item.TongTienKhac,
                    TienPhatSinh = item.TienPhatSinh,
                    GhiChuPhatSinh = item.GhiChuPhatSinh,
                    TongTienCaTruoc = item.TongTienCaTruoc,
                    Time = item.Time,
                    TongTienMatRut = item.TongTienMatRut,
                    TrangThai = item.TrangThai,

                };
                lstGiaoCaViewModel.Add(gC2);
            }
            return lstGiaoCaViewModel;
        }

        public bool Xoa(Guid Id)
        {
            var kq = _giaoCaRepository.Xoa(Id);
            return kq;
        }
    }
}
