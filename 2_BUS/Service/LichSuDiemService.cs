using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepositories;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.ViewModels;

namespace _2_BUS.Service
{
    public class LichSuDiemService : ILichSuDiemService
    {
        public IHistoryPointRepository _IlichSuDiem;
        public IClientRepository _ikhachHang;
        public ITichDiemRepositores _iviDiemService;
        public LichSuDiemService()
        {
            _IlichSuDiem = new HistoryPointRepositores();
            _ikhachHang = new ClientRepositores();
            _iviDiemService = new TichDiemRepositores();
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
            return (from c in _ikhachHang.getAll()
                    join b in _iviDiemService.getAll() on c.IdVi equals b.Id
                    join a in _IlichSuDiem.getAll() on b.Id equals a.IdViDiem
                    select new LichSuDiemViewModels
                    {
                        IdHoaDon = a.IdHoaDon,
                        IdLichSuDiem = a.IdLichSuDiem,
                        IdViDiem = a.IdViDiem,
                        IdKhachHang = c.Id,
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
