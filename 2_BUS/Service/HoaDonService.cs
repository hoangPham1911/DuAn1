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

        IreceiptRepository HoaDonRepos = new ReceiptRepositores();
        ManagerContext _context;
        public List<ThemHoaDonModels> GetAllHoaDonDB()
        {
            throw new NotImplementedException();
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
            if(Hoadonnew == null)  return "that bai"; 
            else
            {
                HoaDon hd = new HoaDon()
                {
                    Id=Guid.NewGuid(),
                    IdKh = Hoadonnew.IdKh,
                    IdNv=Hoadonnew.IdNv,
                    Ma=Hoadonnew.Ma,
                    NgayTao=Hoadonnew.NgayTao,
                    NgayThanhToan=Hoadonnew.NgayThanhToan,
                    NgayShip=Hoadonnew.NgayShip,
                    NgayNhan=Hoadonnew.NgayNhan,
                    TinhTrang=Hoadonnew.TinhTrang,
                    Thue=Hoadonnew.Thue,
                };
                HoaDonRepos.addReceipt(hd);
                return "thanh cong";
                
            }
        }

        public string XoaHoaDon(SuaHoaDonModels SuaHD)
        {
            var idhd = _context.HoaDons.FirstOrDefault(c => c.Id == SuaHD.IdHoaDon);
            HoaDonRepos.removeReceipt(idhd);
            return "thanh cong xoa";
           
        }
    }
}
