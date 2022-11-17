using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class SanPhamService : ISanPhamService
    {
        IProductDetailRepository _ProductDetailRepository;
        IProductRepository _ProductRepository;
        public SanPhamService()
        {
            _ProductRepository = new ProductRepositores();
            _ProductDetailRepository = new ProductDetailRepositores();
        }
        public List<SanPhamView> GetSanPham()
        {
            return (from a in _ProductRepository.getAll()
                    join b in _ProductDetailRepository.getAll() on a.Id equals b.IdSp
                    select new SanPhamView
                    {
                        IdAnh = b.IdAnh,
                        IdSp = a.Id,
                        IdChatLieu = b.IdChatLieu,
                        IdHangHoaChiTiet = b.Id,
                        IdLoaiGiay = b.IdLoaiGiay,
                        IdNsx = a.IdNsx,
                        IdQuocGia = b.IdQuocGia,
                        IdSizeGiay = b.IdSizeGiay,
                        GiaBan = b.GiaBan,
                        GiaNhap = b.GiaNhap,
                        Ma = a.Ma,
                        TrangThai = a.TrangThai,
                        Ten = a.Ten,
                        MoTa = b.MoTa,
                        NamBh = b.NamBh,
                        SoLuongTon = b.SoLuongTon,
                    }).ToList();
        }
    }
}
