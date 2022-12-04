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
        public LichSuDiemService()
        {
            _IlichSuDiem = new HistoryPointRepositores();
        }
        public bool add(LichSuDiemViewModels ls)
        {
            LichSuDiemTieuDung lichSuDiem = new LichSuDiemTieuDung();
            lichSuDiem.NgaySuDung = ls.NgaySuDung;
            lichSuDiem.TrangThai = ls.TrangThai;
            lichSuDiem.SoDiemCong = lichSuDiem.SoDiemCong;
            lichSuDiem.SoDiemTieuDung = lichSuDiem.SoDiemTieuDung;
            lichSuDiem.IdViDiem = lichSuDiem.IdViDiem;
            lichSuDiem.IdHoaDon = lichSuDiem.IdHoaDon;
            lichSuDiem.IdQuyDoiDiem = lichSuDiem.IdQuyDoiDiem;
            if (_IlichSuDiem.add(lichSuDiem)) return true;
            else return false;
        }

        public List<LichSuDiemViewModels> GetLichSuDiem()
        {
            return (from a in _IlichSuDiem.getAll() select new LichSuDiemViewModels
            {
                IdHoaDon = a.IdHoaDon,
                IdLichSuDiem = a.IdLichSuDiem,
                IdQuyDoiDiem = a.IdQuyDoiDiem,
                IdViDiem = a.IdViDiem,
                NgaySuDung = a.NgaySuDung,
                SoDiemTieuDung = a.SoDiemTieuDung,
                SoDiemCong = a.SoDiemCong,
                TrangThai = a.TrangThai
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
            lichSuDiem.IdQuyDoiDiem = lichSuDiem.IdQuyDoiDiem;
            if (_IlichSuDiem.update(lichSuDiem)) return true;
            else return false;
        }
    }
}
