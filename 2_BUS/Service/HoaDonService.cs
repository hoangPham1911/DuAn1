using _1.DAL.IRepositories;
using _1.DAL.Repostiores;
using _1_DAL.Context;
using _1_DAL.Models;
using _2_BUS.IServices;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Services
{
    public class HoaDonService : IHoaDonService
    {

        IreceiptRepository HoaDonRepos;

        public HoaDonService()
        {
            HoaDonRepos = new ReceiptRepositores();
        }
        public List<SuaHoaDonModels> GetAllHoaDonDB()
        {
            return (from a in HoaDonRepos.getAllReceipt()
                    select
                    new SuaHoaDonModels
                    {
                        IdHoaDon = a.Id,
                     //   IdKh = a.IdKh,
                        Ma = a.Ma,
                        NgayNhan = a.NgayNhan,
                        NgayShip = a.NgayShip,
                        NgayTao = a.NgayTao,
                        NgayThanhToan = a.NgayThanhToan,
                  //      IdNv = a.IdNv,
                        Thue = a.Thue,
                        TinhTrang = a.TinhTrang,
                    }).ToList();

        }
    

        public Guid GetIdHoaDon(ThemHoaDonModels IdHoaDon)
        {
            var hoaDon = new HoaDon();
            hoaDon.IdKh = IdHoaDon.IdKh;
            hoaDon.IdNv = IdHoaDon.IdNv;
            hoaDon.Ma = IdHoaDon.Ma;
            hoaDon.NgayTao = IdHoaDon.NgayTao;
            hoaDon.NgayThanhToan = IdHoaDon.NgayThanhToan;
            hoaDon.NgayShip = IdHoaDon.NgayShip;
            hoaDon.NgayNhan = IdHoaDon.NgayNhan;
            hoaDon.TinhTrang = IdHoaDon.TinhTrang;
            hoaDon.Thue = IdHoaDon.Thue;
            if (HoaDonRepos.addReceipt(hoaDon)) return hoaDon.Id;
            return Guid.Parse(null);
        }

        public string SuaHoaDon(SuaHoaDonModels Hoadonold)
        {
            if (Hoadonold == null) return "that bai";
            else
            {
                HoaDon hd = new HoaDon()
                {
                    Id = Hoadonold.IdHoaDon,
                    IdKh = Hoadonold.IdKh,
                    IdNv = Hoadonold.IdNv,
                    Ma = Hoadonold.Ma,
                    NgayTao = Hoadonold.NgayTao,
                    NgayThanhToan = Hoadonold.NgayThanhToan,
                    NgayShip = Hoadonold.NgayShip,
                    NgayNhan = Hoadonold.NgayNhan,
                    TinhTrang = Hoadonold.TinhTrang,
                    Thue = Hoadonold.Thue,
                };
                HoaDonRepos.addReceipt(hd);
                return "thanh cong";
            }
        }

        public string ThemHoaDon(ThemHoaDonModels Hoadonnew)
        {
            if (Hoadonnew == null) return "that bai";
            else
            {
                HoaDon hd = new HoaDon()
                {
                    Id = Guid.NewGuid(),
                    IdKh = Hoadonnew.IdKh,
                    IdNv = Hoadonnew.IdNv,
                    Ma = Hoadonnew.Ma,
                    NgayTao = Hoadonnew.NgayTao,
                    NgayThanhToan = Hoadonnew.NgayThanhToan,
                    NgayShip = Hoadonnew.NgayShip,
                    NgayNhan = Hoadonnew.NgayNhan,
                    TinhTrang = Hoadonnew.TinhTrang,
                    Thue = Hoadonnew.Thue,
                };
                HoaDonRepos.addReceipt(hd);
                return "thanh cong";

            }
        }

        public string XoaHoaDon(SuaHoaDonModels SuaHD)
        {

            var hoaDon = HoaDonRepos.getAllReceipt().FirstOrDefault(p => p.Id == SuaHD.IdHoaDon);
            if (HoaDonRepos.removeReceipt(hoaDon))
                return "thanh cong xoa";
            return "That Bai";
        }
    }
}
