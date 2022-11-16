using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepositories;
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
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        IreceiptDetailRepository _IreceiptDetailRepository;
        public HoaDonChiTietService()
        {
            _IreceiptDetailRepository = new ReceiptDetailRepositores();
        }
        public List<HoaDonChiTietViewModel> GetAllHoaDonDB()
        {
            return (from a in _IreceiptDetailRepository.GetAll()
                    select new HoaDonChiTietViewModel
                    {
                        IdHoaDon = a.IdHoaDon,
                        IdChiTietSp =a.IdChiTietSp,
                        DonGia = a.DonGia,
                        SoLuong =a.SoLuong,
                        ThanhTien = a.ThanhTien,                        
                    }).ToList();
                   
        }

        public bool SuaHoaDonChiTiet(HoaDonChiTietUpdateView Hoadons)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.IdHoaDon = Hoadons.IdHoaDon;
            hdct.DonGia = Hoadons.DonGia;
            hdct.IdChiTietSp = Hoadons.IdChiTietSp;
            hdct.SoLuong = Hoadons.SoLuong;
            hdct.ThanhTien = Hoadons.ThanhTien;
            if (_IreceiptDetailRepository.update(hdct)) return true;
            return false;
        }
        

        public bool ThemHoaDonChiTiet(HoaDonChiTietViewModel Hoadons)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.IdHoaDon = Hoadons.IdHoaDon;
            hdct.DonGia = Hoadons.DonGia;
            hdct.IdChiTietSp = Hoadons.IdChiTietSp;
            hdct.SoLuong = Hoadons.SoLuong;
            hdct.ThanhTien = Hoadons.ThanhTien;
            if (_IreceiptDetailRepository.add(hdct)) return true;
            return false;
        }

        public bool XoaHoaDonChiTiet(Guid Hoadonld)
        {
            if (_IreceiptDetailRepository.remove(Hoadonld)) return true;
            return false;
        }
    }
}
