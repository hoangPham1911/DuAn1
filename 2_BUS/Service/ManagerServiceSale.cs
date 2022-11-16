using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
namespace _2_BUS.Service
{
    public class ManagerServiceSale : IManagerServiceSale
    {
        ISaleRepository _SaleRepository;

        public ManagerServiceSale()
        {
            _SaleRepository = new SaleRepositores();
        }
        public bool add(Sale sale)
        {
            Sale giamGia = new Sale();
            giamGia.MaGiamGia = sale.MaGiamGia;
            giamGia.TrangThai = sale.TrangThai;
            giamGia.TenChuongTrinh = sale.TenChuongTrinh;
            if (_SaleRepository.add(giamGia)) return true;
            else return false;
        }

        public List<Sale> getAll()
        {
            return _SaleRepository.getAll();
        }

        public bool remove(Sale id)
        {
            Sale sale = _SaleRepository.getAll().FirstOrDefault(p => p.Id == id.Id);
            if (_SaleRepository.remove(sale)) return true;
            return false;
        }

        public bool update(Sale sale)
        {
            Sale giamGia = _SaleRepository.getAll().FirstOrDefault(p => p.Id == sale.Id);
            giamGia.MaGiamGia = sale.MaGiamGia;
            giamGia.TrangThai = sale.TrangThai;
            giamGia.TenChuongTrinh = sale.TenChuongTrinh;
            if (_SaleRepository.update(giamGia)) return true;
            else return false;
        }
    }
}
