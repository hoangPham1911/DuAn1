using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class MangerServiceSaleChiTiet : ISaleDetailRepository
    {

        ISaleDetailRepository _SaleDetailRepository;
        public MangerServiceSaleChiTiet()
        {
            _SaleDetailRepository = new SaleDetailRepositores();
        }
        public bool add(SaleChiTiet sale)
        {
            SaleChiTiet giamGia = new SaleChiTiet();
            giamGia.IdChiTietHangHoa = sale.IdChiTietHangHoa;
            giamGia.IdSale = sale.IdSale;
            giamGia.NgayBatDau = sale.NgayBatDau;
            giamGia.NgayKetThuc = sale.NgayKetThuc;
            if (_SaleDetailRepository.add(giamGia)) return true;
            else return false;
        }


        public bool add(SaleChiTiet sale)
        {
            SaleChiTiet giamGia = new SaleChiTiet();
            giamGia. = sale.MaGiamGia;
            giamGia.TrangThai = sale.TrangThai;
            giamGia.TenChuongTrinh = sale.TenChuongTrinh;
            if (_SaleRepository.add(giamGia)) return true;
            else return false;
        }


        public List<SaleChiTiet> getAll()
        {
            return _SaleDetailRepository.getAll();
        }

        public bool remove(SaleChiTiet id)
        {
            SaleChiTiet sale = _SaleDetailRepository.getAll().FirstOrDefault(p => p.IdChiTietHangHoa == id.IdChiTietHangHoa);
            if (_SaleDetailRepository.remove(sale)) return true;
            return false;
        }

        public bool update(SaleChiTiet sale)
        {
            SaleChiTiet giamGia = _SaleDetailRepository.getAll().FirstOrDefault(p => p.IdSale == sale.IdSale);
            giamGia.IdChiTietHangHoa = sale.IdChiTietHangHoa;
            giamGia.IdSale = sale.IdSale;
            giamGia.NgayBatDau = sale.NgayBatDau;
            giamGia.NgayKetThuc = sale.NgayKetThuc;
            if (_SaleDetailRepository.update(giamGia)) return true;
            else return false;
        }
    }
}
