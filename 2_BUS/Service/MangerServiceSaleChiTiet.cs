using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class MangerServiceSaleChiTiet : ISaleDetailRepository
    {
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
            throw new NotImplementedException();
        }

        public bool remove(SaleChiTiet id)
        {
            throw new NotImplementedException();
        }

        public bool update(SaleChiTiet sale)
        {
            throw new NotImplementedException();
        }
    }
}
