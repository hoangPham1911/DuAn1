using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class QlyHangHoaViewModels
    {
        public Guid Id { get; set; }
        public Guid? IdSp { get; set; }
        public Guid? IdQuocGia { get; set; }
        public Guid? IdLoaiGiay { get; set; }
        public Guid? IdSizeGiay { get; set; }
        public Guid? IdAnh { get; set; }
        public Guid? IdChatLieu { get; set; }
        public Guid? IdNsx { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public Guid? IdSaleChiTiet { get; set; }
        public decimal? SoTienSauKhiGiam { get; set; }
        public Guid? IdSale { get; set; }
        public int TrangThai { get; set; }
        public int? NamBh { get; set; }
        public string MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public int SoSize { get; set; }
    }
}
