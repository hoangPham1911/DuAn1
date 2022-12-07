using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class SaleService : ISaleService
    {
        ISaleRepository _SaleRepository;
        public SaleService()
        {
            _SaleRepository = new SaleRepositores();
        }
        public bool add(SaleViewModel sale)
        {
            var addSale = new Voucher();
            addSale.MaGiamGia = sale.MaGiamGia;
            addSale.TenChuongTrinh = sale.TenChuongTrinh;
            addSale.NgayBatDau = sale.NgayBatDau;
            addSale.NgayKetThuc = sale.NgayKetThuc;
            addSale.SoTienGiamGia = sale.SoTienGiamGia;
            addSale.TrangThai = sale.TrangThai;
            if (_SaleRepository.add(addSale))
                return true;
            return false;
        }

        public List<SaleViewModel> GetDanhMuc()
        {
            return (from a in _SaleRepository.getAll()
                    select new SaleViewModel
                    {
                        Id = a.Id,
                        MaGiamGia = a.MaGiamGia,
                        TenChuongTrinh = a.TenChuongTrinh,
                        NgayBatDau = a.NgayBatDau,
                        NgayKetThuc = a.NgayKetThuc,
                        SoTienGiamGia = (decimal)a.SoTienGiamGia,
                        TrangThai = a.TrangThai
                    }).ToList();
        }

        public bool remove(SaleViewModel sale)
        {
            var IdSale = _SaleRepository.getAll().FirstOrDefault(p => p.Id == sale.Id);
            if (_SaleRepository.remove(IdSale)) return true;
            return false;
        }

        public bool update(SaleViewModel sale)
        {
            var addSale = _SaleRepository.getAll().FirstOrDefault(p => p.Id == sale.Id);
            addSale.MaGiamGia = sale.MaGiamGia;
            addSale.TenChuongTrinh = sale.TenChuongTrinh;
            addSale.NgayBatDau = sale.NgayBatDau;
            addSale.NgayKetThuc = sale.NgayKetThuc;
            addSale.SoTienGiamGia = sale.SoTienGiamGia;
            addSale.TrangThai = sale.TrangThai;
            if (_SaleRepository.update(addSale))
                return true;
            return false;
        }
    }
}
