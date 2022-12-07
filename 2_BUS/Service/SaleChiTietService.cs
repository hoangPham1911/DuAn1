//using _1.DAL.IRepostiories;
//using _1.DAL.Repostiores;
//using _1_DAL.IRepositories;
//using _1_DAL.IRepostiories;
//using _1_DAL.Models;
//using _1_DAL.Repositores;
//using _1_DAL.Repostiores;
//using _2_BUS.IService;
//using _2_BUS.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _2_BUS.Service
//{
//    public class SaleChiTietService : ISaleChiTietService
//    {
//        public ISaleDetailRepository _SaleDetailRepository;
//        public ISaleRepository _ISaleRepository;

//        public IProductRepository ihanghoa;
//        IProductDetailRepository _IHangHoaChiTietRepository;
//        ISizeShoseRepository _iSizeshoesRepository;
//        ILoaiGiayRepository _iLoaiGiayRepository;
        
//        public SaleChiTietService()
//        {
//            _ISaleRepository = new SaleRepositores();
//            _SaleDetailRepository = new SaleDetailRepositores();
//            _IHangHoaChiTietRepository = new ProductDetailRepositores();
//            ihanghoa = new ProductRepositores();
//            _iSizeshoesRepository = new SizeShoseRepositores();
//            _iLoaiGiayRepository = new LoaiGiayRepositores();
//        }
//        public bool add(SaleChiTietThemView sale)
//        {
//            var addSale = new SaleChiTiet();
            
//            if (_SaleDetailRepository.add(addSale))
//                return true;
//            return false;
//        }
//        public List<SaleChiTietViewModels> GetsList()

//        {
//            return (from a in _IHangHoaChiTietRepository.getAll()
//                    join b in ihanghoa.getAll() on a.IdSp equals b.Id
//                    join e in _iSizeshoesRepository.getAll() on a.IdSizeGiay equals e.Id
//                    join f in _iLoaiGiayRepository.getAll() on a.IdLoaiGiay equals f.Id
//                    join h in _SaleDetailRepository.getAll() on a.Id equals h.IdHoaDon
//                    join g in _ISaleRepository.getAll() on h.IdSale equals g.Id
                    
//                    select new SaleChiTietViewModels
//                    {
//                        IdCtSp = a.Id,
//                        IdSp = b.Id,
//                        IdSizeGiay = e.Id,
//                        IdLoaiGiay = f.Id,
//                        Ma = b.Ma,
//                        Ten = b.Ten,
//                        TrangThai = b.TrangThai,
//                        MoTa = a.MoTa,
//                        SoLuongTon = a.SoLuongTon,
//                        GiaBan = a.GiaBan,
//                        SoSize = e.SoSize,
//                        IdSaleChiTiet = h.IdSale,
//                        SoTienSauKhiGiam = h.SoTienSauKhiGiam,
//                        IdSale = g.Id,
//                        NgayBatDau = g.NgayBatDau,
//                        NgayKetThuc = g.NgayKetThuc,
//                        MaGiamGia = g.MaGiamGia,
//                        TenChuongTrinh = g.TenChuongTrinh,
//                        SaleTheoPhanTram = g.SaleTheoPhanTram,
                        
//                    }).ToList();
//        }

//        public bool remove(SaleChiTietViewModels sale)
//        {
//            var IdSale = _SaleDetailRepository.getAll().FirstOrDefault(p => p.IdSale == sale.IdSale);
//            if (_SaleDetailRepository.remove(IdSale)) return true;
//            return false;
//        }

//        public bool update(SaleChiTietUpdateView sale)
//        {
//            var addSale = _SaleDetailRepository.getAll().FirstOrDefault(p => p.IdSale == sale.IdSale);
//            addSale.IdSale = sale.IdSale;
//            addSale.IdHoaDon = sale.IdHoaDon;
//            //addSale.SaleTheoPhanTram = sale.GiamTheoPhanTram;
//            //addSale.SaleTheoKhoangTien = sale.GiamTheoKhoangTien;
//            if (_SaleDetailRepository.update(addSale))
//                return true;
//            return false;
//        }
//    }
//}
