using _1_DAL.IRepostiories;
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
    public class LichSuDiemService : ILichSuDiemService
    {
        public IHistoryPointRepository _IlichSuDiem;
        public IKhachHangServices _ikhachHang;
        public IViDiemService _iviDiemService;
        public LichSuDiemService()
        {
            _IlichSuDiem = new HistoryPointRepositores();
            _ikhachHang = new KhachHangServices();
            _iviDiemService = new ViDiemService();
        }
        public bool add(LichSuDiemViewModels ls)
        {
            LichSuDiemTieuDung lichSuDiem = new LichSuDiemTieuDung();
            lichSuDiem.NgaySuDung = ls.NgaySuDung;
            lichSuDiem.TrangThai = ls.TrangThai;
            lichSuDiem.SoDiemCong = ls.SoDiemCong;
            lichSuDiem.SoDiemTieuDung = ls.SoDiemTieuDung;
            lichSuDiem.IdViDiem = ls.IdViDiem;
            lichSuDiem.IdHoaDon = ls.IdHoaDon;

            if (_IlichSuDiem.add(lichSuDiem)) return true;
            else return false;
        }

        public List<LichSuDiemViewModels> GetLichSuDiem()
        {
            return (from a in _IlichSuDiem.getAll() 
                    join b in _iviDiemService.GetViDiem() on a.IdViDiem equals b.Id
                    join c in _ikhachHang.GetAllKhachHangDB() on b.IdKhachHang equals c.Idkh
                    select new LichSuDiemViewModels
            {
                IdHoaDon = a.IdHoaDon,
                IdLichSuDiem = a.IdLichSuDiem,
                IdViDiem = a.IdViDiem,
                IdKhachHang = c.Idkh,
                MaKH = c.Ma,
                TenKH = c.Ten,
                NgaySuDung = a.NgaySuDung,
                SoDiemTieuDung = a.SoDiemTieuDung,
                SoDiemCong = a.SoDiemCong,
                TrangThai = a.TrangThai,
                TongDiem = b.TongDiem

            }).ToList();
        }

        public bool remove(Guid ls)
        {
            if (_IlichSuDiem.remove(ls)) return true;
            return false;
        }

        public bool update(LichSuDiemViewModels ls)
        {
            LichSuDiemTieuDung lichSuDiem = _IlichSuDiem.getAll().FirstOrDefault(p => p.IdLichSuDiem == ls.IdLichSuDiem);
            lichSuDiem.NgaySuDung = ls.NgaySuDung;
            lichSuDiem.TrangThai = ls.TrangThai;
            lichSuDiem.SoDiemCong = lichSuDiem.SoDiemCong;
            lichSuDiem.SoDiemTieuDung = lichSuDiem.SoDiemTieuDung;
            lichSuDiem.IdViDiem = lichSuDiem.IdViDiem;
            lichSuDiem.IdHoaDon = lichSuDiem.IdHoaDon;
  
            if (_IlichSuDiem.update(lichSuDiem)) return true;
            else return false;
        }
    }
}
