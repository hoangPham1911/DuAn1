using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepostiories;
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
        private List<KieuDanhMucViewModels> KieuDanhMucList;
        public KieuDanhMucService()
        {
            _kieuDanhMuc = new TypeTableOfContentRepositores();
        }
        public List<KieuDanhMucViewModels> GetallKieuDM()
        {
            KieuDanhMucList =
                (from a in _kieuDanhMuc.getAll()
                 select new KieuDanhMucViewModels()
                 {
                     IdDanhMuc = a.IdDanhMuc,
                     TenKieuDanhMuc = a.TheLoaiGioiTinh,
                     IdHangHoa = a.IdHangHoa,

                 }).ToList();
            return KieuDanhMucList;
        }
    }
}
