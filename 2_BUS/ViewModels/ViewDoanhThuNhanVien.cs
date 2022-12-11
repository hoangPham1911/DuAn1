using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class ViewDoanhThuNhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public double TongSoTien { get; set; }
        public string Months { get; set; }
        public string Years { get; set; }
        public DateTime? Ngaytt { get; set; }
        public int trangthai { get; set; }
        public ViewDoanhThuNhanVien(string manv, string tennv, double tongtien, string Month, string Year, DateTime? ngaytt)
        {
            MaNhanVien = manv;
            TenNhanVien = tennv;
            TongSoTien = tongtien;
            Months = Month;
            Years = Year;
            Ngaytt = ngaytt;
        }
    }
}
