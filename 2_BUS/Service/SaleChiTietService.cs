using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepositories;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _1_DAL.Repostiores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class SaleChiTietService : ISaleChiTietService
    {
        public ISaleDetailRepository _SaleDetailRepository;
        public ISaleRepository _ISaleRepository;

        public IProductRepository ihanghoa;
        IProductDetailRepository _IHangHoaChiTietRepository;
        IQuocGiaRepository _iQuocgiaRepository;
        INsxRepository _iNsxRepository;
        ISizeShoseRepository _iSizeshoesRepository;
        ILoaiGiayRepository _iLoaiGiayRepository;
        
        public SaleChiTietService()
        {
            _ISaleRepository = new SaleRepositores();
            _SaleDetailRepository = new SaleDetailRepositores();
            _IHangHoaChiTietRepository = new ProductDetailRepositores();
            ihanghoa = new ProductRepositores();
            _iQuocgiaRepository = new QuocGiaRepositores();
            _iNsxRepository = new NsxRepositores();
            _iSizeshoesRepository = new SizeShoseRepositores();
            _iLoaiGiayRepository = new LoaiGiayRepositores();
        }
        public bool add(SaleChiTietThemView sale)
        {
            var addSale = new SaleChiTiet();
            
            if (_SaleDetailRepository.add(addSale))
                return true;
            return false;
        }

        public List<SaleChiTietViewModels> GetDanhMuc()
        {
            return (from a in _SaleDetailRepository.getAll()
                    join b in ihanghoa.getAll() on a.IdChiTietHangHoa equals b.Id
                    select new SaleChiTietViewModels
                    {
                        /*IdHangHoa = IdHangHoaCt*/
                        IdHangHoa = a.IdChiTietHangHoa,
                        IdSale = a.IdSale,
                       
                        
                        //GiamTheoKhoangTien = a.SaleTheoKhoangTien,
                        //GiamTheoPhanTram = a.SaleTheoPhanTram,

                    }).ToList();
        }
        public List<QlyHangHoaViewModels> GetsList()

        {
            return (from a in _IHangHoaChiTietRepository.getAll()
                    join b in ihanghoa.getAll() on a.IdSp equals b.Id
                    join c in _iQuocgiaRepository.getAll() on a.IdQuocGia equals c.Id
                    join d in _iNsxRepository.getAll() on b.IdNsx equals d.Id
                    join e in _iSizeshoesRepository.getAll() on a.IdSizeGiay equals e.Id
                    join f in _iLoaiGiayRepository.getAll() on a.IdLoaiGiay equals f.Id
                    join h in _SaleDetailRepository.getAll() on a.Id equals h.IdChiTietHangHoa
                    join g in _ISaleRepository.getAll() on h.IdSale equals g.Id
                    
                    select new QlyHangHoaViewModels
                    {
                        Id = a.Id,
                        IdSp = b.Id,
                        IdQuocGia = c.Id,
                        IdNsx = d.Id,
                        IdSizeGiay = e.Id,
                        IdLoaiGiay = f.Id,
                        Ma = b.Ma,
                        Ten = b.Ten,
                        TrangThai = b.TrangThai,
                        NamBh = a.NamBh,
                        MoTa = a.MoTa,
                        SoLuongTon = a.SoLuongTon,
                        GiaBan = a.GiaBan,
                        GiaNhap = a.GiaNhap,
                        SoSize = e.SoSize,
                        IdSaleChiTiet = h.IdSale,
                        SoTienSauKhiGiam = h.SoTienSauKhiGiam,
                        IdSale = g.Id
                        
                    }).ToList();
        }

        public bool remove(SaleChiTietViewModels sale)
        {
            var IdSale = _SaleDetailRepository.getAll().FirstOrDefault(p => p.IdSale == sale.IdSale);
            if (_SaleDetailRepository.remove(IdSale)) return true;
            return false;
        }

        public bool update(SaleChiTietUpdateView sale)
        {
            var addSale = _SaleDetailRepository.getAll().FirstOrDefault(p => p.IdSale == sale.IdSale);
            addSale.IdSale = sale.IdSale;
            addSale.IdChiTietHangHoa = sale.IdHangHoa;
            //addSale.SaleTheoPhanTram = sale.GiamTheoPhanTram;
            //addSale.SaleTheoKhoangTien = sale.GiamTheoKhoangTien;
            if (_SaleDetailRepository.update(addSale))
                return true;
            return false;
        }
    }
}
