using _1_DAL.IRepositories;
using _1_DAL.Models;
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
    public class SaleChiTietService : ISaleChiTietService
    {
        public ISaleDetailRepository _SaleDetailRepository;
        public SaleChiTietService()
        {
            _SaleDetailRepository = new SaleDetailRepositores();
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
                    select new SaleChiTietViewModels
                    {
                        /*IdHangHoa = IdHangHoaCt*/
                        IdHangHoa = a.IdChiTietHangHoa,
                        IdSale = a.IdSale,
                        //GiamTheoKhoangTien = a.SaleTheoKhoangTien,
                        //GiamTheoPhanTram = a.SaleTheoPhanTram,

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
