using _1.DAL.IRepositories;
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
        IreceiptRepository _HoaDonRepos;
        IProductDetailRepository _IProductDetailRepository;
        IProductRepository _ProductRepository;
        public HoaDonChiTietService()
        {
            _IProductDetailRepository = new ProductDetailRepositores();
            _ProductRepository = new ProductRepositores();
            _IreceiptDetailRepository = new ReceiptDetailRepositores();
            _HoaDonRepos = new ReceiptRepositores();
        }
       
        public List<HoaDonChiTietViewModel> GetAllHoaDonDB()
        {
            return (from a in _IreceiptDetailRepository.GetAll()
                    join b in _HoaDonRepos.getAllReceipt() on a.IdHoaDon equals b.Id
                    select new HoaDonChiTietViewModel
                    {
                        IdHoaDon = a.IdHoaDon,
              //          IdChiTietSp = a.IdChiTietSp,
             //           SoLuong = a.SoLuong,
              //          ThanhTien = a.ThanhTien,
                        //   IdKh = b.IdKh,
                        Ma = b.Ma,
                   //     NgayNhan = b.NgayNhan,
                    //    NgayShip = b.NgayShip,
                        NgayTao = b.NgayTao,
                     //   NgayThanhToan = b.NgayThanhToan,
                        //  IdNv = b.IdNv,
                     //   GiamGia = a.GiamGia,
                  //      Thue = b.Thue,
                        TinhTrang = b.TinhTrang,
                    }).ToList();

        }

        public List<SanPhamTrongHoaDonViewModels> GetAllProductInReceipt()
        {
            return (from a in _ProductRepository.getAll()
                    join b in _IProductDetailRepository.getAll() on a.Id equals b.IdSp
                    join c in _IreceiptDetailRepository.GetAll() on b.Id equals c.IdChiTietSp
                    join d in _HoaDonRepos.getAllReceipt() on c.IdHoaDon equals d.Id
                    select new SanPhamTrongHoaDonViewModels
                    {
                        MaSP = a.Ma,
                        TenSp = a.Ten,
                        SoLuong = c.SoLuong,
                        DonGia = b.GiaBan,
                        IdHoaDon = c.IdHoaDon,
                        ThanhTien = c.ThanhTien * c.SoLuong
                    }).ToList();
        }

        public bool SuaHoaDonChiTiet(HoaDonChiTietUpdateView Hoadons)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.IdHoaDon = Hoadons.IdHoaDon;
            hdct.GiamGia = Hoadons.GiamGia;
            hdct.IdChiTietSp = Hoadons.IdChiTietSp;
            hdct.SoLuong = Hoadons.SoLuong;
            hdct.ThanhTien = Hoadons.ThanhTien;
            if (_IreceiptDetailRepository.update(hdct)) return true;
            return false;
        }


        public bool ThemHoaDonChiTiet(HoaDonChiTietThemViewModel Hoadons)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.IdHoaDon = Hoadons.IdHoaDon;
            hdct.GiamGia = Hoadons.GiamGia;
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
