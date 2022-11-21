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
    public class HangHoaChiTietServices :IHangHoaChiTietServices
    {
        IProductDetailRepository _IHangHoaChiTietRepository;
        IProductRepository _iHangHoaRepository;
        IQuocGiaRepository _iQuocgiaRepository;
        INsxRepository _iNsxRepository;
        ISizeShoseRepository _iSizeshoesRepository;
        ILoaiGiayRepository _iLoaiGiayRepository;
        IChatLieuRepository _iChatLieuRepository;
        IImageRepositoriy _iAnhRepositoriy;

        public HangHoaChiTietServices()
        {
            _IHangHoaChiTietRepository = new ProductDetailRepositores();
            _iHangHoaRepository = new ProductRepositores();
            _iQuocgiaRepository = new QuocGiaRepositores();
            _iNsxRepository = new NsxRepositores();
            _iSizeshoesRepository = new SizeShoseRepositores();
            _iLoaiGiayRepository = new LoaiGiayRepositores();
            _iChatLieuRepository = new ChatLieuRepositores();
            _iAnhRepositoriy = new ImageRepositoriy();
        }

        public bool ThemHangHoaChiTiet(HangHoaChiTietThemViewModels HangHoas)
        {
            ChiTietHangHoa chiTietHangHoa = new ChiTietHangHoa();
            HangHoa hangHoa = new HangHoa();
            chiTietHangHoa.IdQuocGia = HangHoas.IdQuocGia;
            hangHoa.IdNsx = HangHoas.IdNsx;
            chiTietHangHoa.IdSizeGiay = HangHoas.IdSizeGiay;
            chiTietHangHoa.IdLoaiGiay = HangHoas.IdLoaiGiay;
            chiTietHangHoa.IdChatLieu = HangHoas.IdChatLieu;
            chiTietHangHoa.IdAnh = HangHoas.IdAnh;
            hangHoa.Ma = HangHoas.Ma;
            hangHoa.Ten = HangHoas.Ten;
            hangHoa.TrangThai = HangHoas.TrangThai;
            chiTietHangHoa.NamBh = HangHoas.NamBh;
            chiTietHangHoa.SoLuongTon = HangHoas.SoLuongTon;
            chiTietHangHoa.MoTa = HangHoas.MoTa;
            chiTietHangHoa.GiaNhap = HangHoas.GiaNhap;
            chiTietHangHoa.GiaBan = HangHoas.GiaBan;
            if (_IHangHoaChiTietRepository.add(chiTietHangHoa) && _iHangHoaRepository.add(hangHoa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateSoLuong(HangHoaChiTietUpdateThanhToan hangHoas)
        {
            ChiTietHangHoa chiTietHangHoa = _IHangHoaChiTietRepository.getAll().FirstOrDefault(p => p.Id == hangHoas.IdSpCt);
            chiTietHangHoa.SoLuongTon = hangHoas.SoLuong;
            if (_IHangHoaChiTietRepository.update(chiTietHangHoa)) return true;
            return false;
        }
        public bool XoaHangHoa(Guid hanghoactid, HangHoa hanghoaid) {
            return true;
                }
        

        public bool XoaHangHoaChiTiet(Guid hanghoactid, HangHoa hanghoaid)

        {
            if (_IHangHoaChiTietRepository.remove(hanghoactid) && _iHangHoaRepository.remove(hanghoaid)) return true;
            return false;
        }


        public bool SuaHangHoaChiTiet(HangHoaChiTietUpdateViewModels HangHoas)
        {
            ChiTietHangHoa chiTietHangHoa = new ChiTietHangHoa();
            HangHoa hangHoa = new HangHoa();
            chiTietHangHoa.IdQuocGia = HangHoas.IdQuocGia;
            hangHoa.IdNsx = HangHoas.IdNsx;
            chiTietHangHoa.IdSizeGiay = HangHoas.IdSizeGiay;
            chiTietHangHoa.IdLoaiGiay = HangHoas.IdLoaiGiay;
            chiTietHangHoa.IdChatLieu = HangHoas.IdChatLieu;
            chiTietHangHoa.IdAnh = HangHoas.IdAnh;
            hangHoa.Ma = HangHoas.Ma;
            hangHoa.Ten = HangHoas.Ten;
            hangHoa.TrangThai = HangHoas.TrangThai;
            chiTietHangHoa.NamBh = HangHoas.NamBh;
            chiTietHangHoa.SoLuongTon = HangHoas.SoLuongTon;
            chiTietHangHoa.MoTa = HangHoas.MoTa;
            chiTietHangHoa.GiaNhap = HangHoas.GiaNhap;
            chiTietHangHoa.GiaBan = HangHoas.GiaBan;
            if (_IHangHoaChiTietRepository.update(chiTietHangHoa) && _iHangHoaRepository.update(hangHoa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<HangHoaChiTietViewModels> GetAllHangHoaDB()
        {
            return (from a in _IHangHoaChiTietRepository.getAll()
                    join b in _iHangHoaRepository.getAll() on a.IdSp equals b.Id
                    join c in _iQuocgiaRepository.getAll() on a.IdQuocGia equals c.Id
                    join d in _iNsxRepository.getAll() on b.IdNsx equals d.Id
                    join e in _iSizeshoesRepository.getAll() on a.IdSizeGiay equals e.Id
                    join f in _iLoaiGiayRepository.getAll() on a.IdLoaiGiay equals f.Id
                    join g in _iChatLieuRepository.getAll() on a.IdChatLieu equals g.Id
                    join h in _iAnhRepositoriy.getAll() on a.IdAnh equals h.ID
                    select new HangHoaChiTietViewModels
                    {
                        Id = a.Id,
                        IdSp = b.Id,
                        IdQuocGia = c.Id,
                        IdNsx = d.Id,
                        IdSizeGiay = e.Id,
                        IdLoaiGiay = f.Id,
                        IdChatLieu = g.Id,
                        IdAnh = h.ID,
                        Ma = b.Ma,
                        Ten = b.Ten,
                        TrangThai = b.TrangThai,
                        NamBh = a.NamBh,
                        MoTa = a.MoTa,
                        SoLuongTon = a.SoLuongTon,
                        GiaBan = a.GiaBan,
                        GiaNhap = a.GiaNhap

                    }).ToList();
        }

        public List<HangHoaChiTietUpdateThanhToan> GetAllSoLuong()
        {
            return (from a in _IHangHoaChiTietRepository.getAll()
                    select
                    new HangHoaChiTietUpdateThanhToan { IdSpCt = a.Id, SoLuong = a.SoLuongTon }).ToList();
        }

        public bool XoaHangHoaChiTiet(Guid idHangHoa)
        {
            throw new NotImplementedException();
        }

        public List<HangHoaChiTietViewModels> GetAllHoaDonDB()
        {
            throw new NotImplementedException();
        }
    }
}
