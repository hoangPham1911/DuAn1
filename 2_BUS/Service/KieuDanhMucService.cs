using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
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
    public class KieuDanhMucService : IKieuDanhMucServices
    {
        private ITypeTableOfContents _kieuDanhMuc;
        private IDanhMucRepository danhMucRepository;
        private IProductRepository productRepository;
        private List<KieuDanhMucViewModels> KieuDanhMucList;
        public KieuDanhMucService()
        {
            _kieuDanhMuc = new TypeTableOfContentRepositores();
            danhMucRepository = new DanhMucRepositores();
            productRepository = new ProductRepositores();
        }
        public List<KieuDanhMucViewModels> GetallKieuDM()
        {
            KieuDanhMucList =
                (from a in _kieuDanhMuc.getAll()
                 join b in danhMucRepository.getAll() on a.IdDanhMuc equals b.Id
                 join c in productRepository.getAll() on a.IdHangHoa equals c.Id
                 select new KieuDanhMucViewModels()
                 {
                     TenDM = b.Ten,
                     TenHH = c.Ten,
                     IdDanhMuc = b.Id,
                     TheLoaiGioiTinh = a.TheLoaiGioiTinh,
                     IdHangHoa = c.Id,

                 }).ToList();
            return KieuDanhMucList;
        }

        public string SuaKieuDanhMuc(KieuDanhMucViewModels obj)
        {
            if (obj == null) return "Sửa không thành công";
            var x = _kieuDanhMuc.getAll().FirstOrDefault(p => p.IdDanhMuc == obj.IdDanhMuc);
            x.IdDanhMuc = obj.IdDanhMuc;
            x.IdHangHoa = obj.IdHangHoa;
            x.TheLoaiGioiTinh = obj.TheLoaiGioiTinh;
            if (_kieuDanhMuc.update(x)) return "Sửa thành công";
            return "Sửa không thành công";
        }

        public string ThemKieuDanhMuc(KieuDanhMucViewModels obj)
        {
            if (obj == null) return "Thêm không thành công";
            KieuDanhMuc kieuDanhMuc = new KieuDanhMuc()
            {
                IdDanhMuc = obj.IdDanhMuc,
                IdHangHoa = obj.IdHangHoa,
                TheLoaiGioiTinh = obj.TheLoaiGioiTinh,
            };

            if (_kieuDanhMuc.add(kieuDanhMuc)) return "Thêm thành công";
            return "Thêm không thành công";
        }
    }
}
