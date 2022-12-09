using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class SaleRepositores : ISaleRepository
    {
        public ManagerContext _DbContext;
        public SaleRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(Voucher sale)
        {
            if (sale == null) return false;
            _DbContext.Sales.Add(sale);
            _DbContext.SaveChanges();
            return true;
        }

        public List<Voucher> getAll()
        {
            return _DbContext.Sales.ToList();

        }

        public bool remove(Voucher id)
        {
            if (id == null) return false;
            var tempsale = _DbContext.Sales.FirstOrDefault(p => p.Id == id.Id);
            _DbContext.Sales.Remove(tempsale);
            _DbContext.SaveChanges();
            return true;
        }

        public bool update(Voucher sale)
        {
            if (sale == null) return false;
            var tempsale = _DbContext.Sales.FirstOrDefault(p => p.Id == sale.Id);
            tempsale.MaGiamGia = sale.MaGiamGia;
            tempsale.TenChuongTrinh = sale.TenChuongTrinh;
            tempsale.NgayBatDau = sale.NgayBatDau;
            tempsale.NgayKetThuc = sale.NgayKetThuc;
            tempsale.SoTienGiamGia = sale.SoTienGiamGia;
            tempsale.TrangThai = sale.TrangThai;
            _DbContext.Sales.Update(tempsale);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
