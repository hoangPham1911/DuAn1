using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.IServices;
using _2_BUS.Services;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class DoanhThuNhanVienServices : IServiceViewThongKeDoanhThuNhanVien
    {
        private List<ViewDoanhThuNhanVien> _lstdoanhthu;
        private string manv;
        private double tong;
        private NhanVien _nv;
        private ViewDoanhThuNhanVien _viewdoanhthu;
        private DateTime? day;
        private DateTime? nam;
        private string mon;
        private string year;
        private INhanVienServices _invser;
        private IHoaDonService _ihdser;
        IHoaDonChiTietService _hdctser;

        public DoanhThuNhanVienServices()
        {
            _ihdser = new HoaDonService();
            _invser = new NhanVienServices();
            _nv = new NhanVien();
            _lstdoanhthu = new List<ViewDoanhThuNhanVien>();
            _hdctser = new HoaDonChiTietService();
        }
        public List<ViewDoanhThuNhanVien> Getlistviewdoanhthu()
        {
            var listcommit = (from a in _invser.GetAll() 
                              join b in _ihdser.GetAllHoaDonDB() on a.Id equals b.IdNv 
                              join c in _hdctser.GetAllHoaDonDB() on b.IdHoaDon equals c.IdHoaDon
                              select new { a.Ma, a.Ten, c.ThanhTien, b.NgayThanhToan }).ToList();
            // gán giá trị
            foreach (var x in listcommit)
            {
                tong = Convert.ToDouble(_ihdser.GetAllHoaDonDB().Where(c => c.IdNv == _nv.Id).Select(c => c.TongSoTienTrongCa).Sum());
                day = x.NgayThanhToan;
                nam = x.NgayThanhToan;
                mon = day.Value.Month.ToString();
                year = nam.Value.Year.ToString();
                _viewdoanhthu = new ViewDoanhThuNhanVien(manv, x.Ten, tong, mon, year, x.NgayThanhToan);
                _lstdoanhthu.Add(_viewdoanhthu);
            }

            var lisfinal = listcommit.OrderBy(c => c.ThanhTien).GroupBy(c => c.Ma)
                .Select(g => new ViewDoanhThuNhanVien(g.Key, g.Where(c => c.Ma == g.Key).Select(c => c.Ten).FirstOrDefault(),Convert.ToDouble(g.Sum(c => c.ThanhTien)), mon, year, g.Where(c => c.Ma == g.Key).Select(c => c.NgayThanhToan).FirstOrDefault())).ToList();


            return lisfinal;
        }
    }
}
