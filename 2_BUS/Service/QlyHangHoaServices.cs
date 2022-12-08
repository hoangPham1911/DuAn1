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
    public class QlyHangHoaServices : IQlyHangHoaServices
    {
        IProductDetailRepository _IHangHoaChiTietRepository;
        IProductRepository _iHangHoaRepository;
        IQuocGiaRepository _iQuocgiaRepository;
        INsxRepository _iNsxRepository;
        ISizeShoseRepository _iSizeshoesRepository;
        ILoaiGiayRepository _iLoaiGiayRepository;
        IChatLieuRepository _iChatLieuRepository;
        IImageRepositoriy _iAnhRepositoriy;

        public QlyHangHoaServices()
        {
            _IHangHoaChiTietRepository = new ProductDetailRepositores();
            _iHangHoaRepository = new ProductRepositores();
            _iQuocgiaRepository = new QuocGiaRepositores();
            _iNsxRepository = new NsxRepositores();
            _iSizeshoesRepository = new SizeShoseRepositores();
            _iLoaiGiayRepository = new LoaiGiayRepositores();
            _iChatLieuRepository = new ChatLieuRepositores();
            _iAnhRepositoriy = new ImageRepositoriy();
            GetsList();
        }
        public bool updateSoLuong(HangHoaChiTietUpdateThanhToan hangHoas)
        {
            ChiTietHangHoa chiTietHangHoa = _IHangHoaChiTietRepository.getAll().FirstOrDefault(p => p.Id == hangHoas.IdSpCt);
            chiTietHangHoa.SoLuongTon = hangHoas.SoLuong;
            if (_IHangHoaChiTietRepository.update(chiTietHangHoa)) return true;
            return false;
        }
        public bool XoaHangHoa(Guid hanghoactid, HangHoa hanghoaid)
        {
            return true;
        }

        public bool XoaHangHoaChiTiet(Guid hanghoactid, HangHoa hanghoaid)

        {
            if (_IHangHoaChiTietRepository.remove(hanghoactid) && _iHangHoaRepository.remove(hanghoaid)) return true;
            return false;
        }
        public List<QlyHangHoaViewModels> GetsList()

        {
            return (from a in _IHangHoaChiTietRepository.getAll()
                    join b in _iHangHoaRepository.getAll() on a.IdSp equals b.Id
                    join c in _iQuocgiaRepository.getAll() on a.IdQuocGia equals c.Id
                    join d in _iNsxRepository.getAll() on b.IdNsx equals d.Id
                    join e in _iSizeshoesRepository.getAll() on a.IdSizeGiay equals e.Id
                    join f in _iLoaiGiayRepository.getAll() on a.IdLoaiGiay equals f.Id
                    join g in _iChatLieuRepository.getAll() on a.IdChatLieu equals g.Id
                    join h in _iAnhRepositoriy.getAll() on a.IdAnh equals h.ID
                    select new QlyHangHoaViewModels
                    {
                        IdSp = b.Id,
                        Id = a.Id,
                        IdQuocGia = c.Id,
                        IdNsx = d.Id,
                        IdSizeGiay = e.Id,
                        IdLoaiGiay = f.Id,
                        IdChatLieu = g.Id,
                        IdAnh = h.ID,
                        Ma = b.Ma,
                        Ten = b.Ten,
                        TrangThai = b.TrangThai,
                        SoLuongTon = a.SoLuongTon,
                        GiaBan = a.GiaBan,
                        GiaNhap = a.GiaNhap,
                        SoSize = e.SoSize,
                        Mavach = a.MaQRCode,
                        TenNsx = d.Ten,
                        TenChatLieu = g.Ten,
                        TenLoaiGiay = f.Ten,
                        TenQuocGia = c.Ten,
                        SizeGiay = e.SoSize,
                        DuongDanAnh = h.DuongDan,
                        TenSp = b.Ten

                    }).ToList();
        }

        public List<ChiTietHangHoaViewModels> GetsListCTHH()
        {
            return (from a in _IHangHoaChiTietRepository.getAll()
                    join b in _iHangHoaRepository.getAll() on a.IdSp equals b.Id
                    join c in _iQuocgiaRepository.getAll() on a.IdQuocGia equals c.Id
                    join d in _iSizeshoesRepository.getAll() on a.IdSizeGiay equals d.Id
                    join e in _iLoaiGiayRepository.getAll() on a.IdLoaiGiay equals e.Id
                    join f in _iChatLieuRepository.getAll() on a.IdChatLieu equals f.Id
                    join g in _iAnhRepositoriy.getAll() on a.IdAnh equals g.ID
                    select new ChiTietHangHoaViewModels
                    {
                        Id = a.Id,
                        IdSp = b.Id,
                        IdQuocGia = c.Id,
                        IdSizeGiay = d.Id,
                        IdLoaiGiay = e.Id,
                        IdChatLieu = f.Id,
                        IdAnh = g.ID,
                        NamBh = a.NamBh,
                        MoTa = a.MoTa,
                        SoLuongTon = a.SoLuongTon,
                        GiaBan = a.GiaBan,
                        GiaNhap = a.GiaNhap

                    }).ToList();
        }

        public List<HangHoaViewModels> GetsListHH()
        {
            return (from a in _iHangHoaRepository.getAll()

                    join b in _iNsxRepository.getAll() on a.IdNsx equals b.Id

                    select new HangHoaViewModels
                    {
                        Id = a.Id,
                        IdNsx = b.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai
                    }).ToList();
        }

        public bool addcthanghoa(ChiTietHangHoaThemViewModels HangHoas)
        {
            ChiTietHangHoa chiTietHangHoa = new ChiTietHangHoa();
            chiTietHangHoa.IdQuocGia = HangHoas.IdQuocGia;
            chiTietHangHoa.IdSizeGiay = HangHoas.IdSizeGiay;
            chiTietHangHoa.IdLoaiGiay = HangHoas.IdLoaiGiay;
            chiTietHangHoa.IdChatLieu = HangHoas.IdChatLieu;
            chiTietHangHoa.IdAnh = HangHoas.IdAnh;
            chiTietHangHoa.SoLuongTon = HangHoas.SoLuongTon;
            chiTietHangHoa.GiaNhap = HangHoas.GiaNhap;
            chiTietHangHoa.GiaBan = HangHoas.GiaBan;
            chiTietHangHoa.MoTa = HangHoas.MoTa;
            chiTietHangHoa.NamBh = HangHoas.NamBh;
            chiTietHangHoa.IdSp = HangHoas.IdSp;
            if (_IHangHoaChiTietRepository.add(chiTietHangHoa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deletecthanghoa(Guid hanghoactid)
        {
            if (_IHangHoaChiTietRepository.remove(hanghoactid)) return true;
            return false;
        }

        public bool updatehanghoa(HangHoaViewModels product)
        {
            try
            {
                var sp = _iHangHoaRepository.getAll().FirstOrDefault(c => c.Id == product.Id);
                sp.Ten = product.Ten;
                sp.Ma = product.Ma;
                sp.TrangThai = product.TrangThai;
                sp.IdNsx = product.IdNsx;
                _iHangHoaRepository.update(sp);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool updatehanghoact(ChiTietHangHoaUpdateViewModels product)
        {
            try
            {
                ChiTietHangHoa sp = _IHangHoaChiTietRepository.getAll().FirstOrDefault(c => c.Id == product.Id);
                sp.IdQuocGia = product.IdQuocGia;
                sp.IdLoaiGiay = product.IdLoaiGiay;
                sp.IdSizeGiay = product.IdSizeGiay;
                sp.IdChatLieu = product.IdChatLieu;
                sp.IdAnh = product.IdAnh;
                sp.MaQRCode = product.Mavach;
                sp.SoLuongTon = product.SoLuongTon;
                sp.GiaNhap = product.GiaNhap;
                sp.GiaBan = product.GiaBan;
                _IHangHoaChiTietRepository.update(sp);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool updateMaQR(ChiTietHangHoaUpdateViewModels product)
        {
            try
            {
                ChiTietHangHoa sp = _IHangHoaChiTietRepository.getAll().FirstOrDefault(c => c.Id == product.Id);
                sp.MaQRCode = product.Mavach;
                _IHangHoaChiTietRepository.update(sp);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool addhanghoa(HangHoaThemViewModels HangHoas)
        {
            HangHoa hangHoa = new HangHoa();
            hangHoa.IdNsx = HangHoas.IdNsx;
            hangHoa.Ma = HangHoas.Ma;
            hangHoa.Ten = HangHoas.Ten;
            hangHoa.TrangThai = HangHoas.TrangThai;
            if (_iHangHoaRepository.add(hangHoa))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public Guid IdSp(HangHoaViewModels product)
        {
            try
            {
                var sp = new HangHoa();
                sp.Ten = product.Ten;
                sp.Ma = product.Ma;
                sp.TrangThai = product.TrangThai;
                sp.IdNsx = product.IdNsx;
                _iHangHoaRepository.add(sp);
                return sp.Id;
            }
            catch (Exception)
            {
                return Guid.Parse(null);
                throw;
            }
        }


        public bool deletehanghoa(HangHoaViewModels hanghoaid)
        {
            var hangHoa = _iHangHoaRepository.getAll().FirstOrDefault(p => p.Id == hanghoaid.Id);
            if (_iHangHoaRepository.remove(hangHoa))
                return true;
            return false;
        }

        public bool XoaHangHoaChiTiet(Guid idHangHoa)
        {
            throw new NotImplementedException();
        }

        public List<HangHoaChiTietUpdateThanhToan> GetAllSoLuong()
        {
            return (from a in _IHangHoaChiTietRepository.getAll() select new HangHoaChiTietUpdateThanhToan { IdSpCt = a.Id, SoLuong = a.SoLuongTon }).ToList();
        }
    }
}
