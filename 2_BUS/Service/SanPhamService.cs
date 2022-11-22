using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepositories;
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
    public class SanPhamService : ISanPhamService
    {
        IProductDetailRepository _ProductDetailRepository;
        IProductRepository _ProductRepository;
        IImageRepositoriy _ImageRepositoriy;
        public SanPhamService()
        {
            _ProductRepository = new ProductRepositores();
            _ProductDetailRepository = new ProductDetailRepositores();
            _ImageRepositoriy = new ImageRepositoriy();
        }
        public List<SanPhamView> GetSanPham()
        {
            return (from a in _ProductRepository.getAll()
                    join b in _ProductDetailRepository.getAll() on a.Id equals b.IdSp
                    join c in _ImageRepositoriy.getAll() on b.IdAnh equals c.ID
                    select new SanPhamView
                    {
                        IdAnh = b.IdAnh,
                        img = c.img,
                        IdSp = a.Id,
                        IdHangHoaChiTiet = b.Id,
                        GiaBan = b.GiaBan,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        SoLuongTon = b.SoLuongTon,
                    }).ToList();
        }
    }
}
