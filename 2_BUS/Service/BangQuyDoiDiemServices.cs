using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.IRepositories;
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
    public class BangQuyDoiDiemServices : IBangQuyDoiDiemServices
    {
        IBangQuyDoiDiem _BangQuyDoiDiem;
        IClientRepository _khachHangRepository;
        ITichDiemRepositores _TichDiemRepositores;
        IHistoryPointRepository _IlichSuDiem;

        public BangQuyDoiDiemServices()
        {
            _BangQuyDoiDiem = new BangQuyDoiDiemRepositories();
            _khachHangRepository = new ClientRepositores();
            _TichDiemRepositores = new TichDiemRepositores();
            _IlichSuDiem = new HistoryPointRepositores();
        }
        public bool add(BangQuyDoiDiemViewModels vi)
        {
            QuyDoiDiem quyDoiDiem = new QuyDoiDiem();
            quyDoiDiem.TyLeQuyDoi = vi.TyLeQuyDoi;
            quyDoiDiem.TrangThai = vi.TrangThai;
            quyDoiDiem.Ten = vi.Ten;
            if (_BangQuyDoiDiem.add(quyDoiDiem)) return true;
            return false;

        }

        public List<BangQuyDoiDiemViewModels> GetDiem()
        {
            return (from a in _BangQuyDoiDiem.getAll() 
                    join b in _IlichSuDiem.getAll() on a.Id equals b.IdQuyDoiDiem
                    join c in _TichDiemRepositores.getAll() on b.IdViDiem equals c.Id
                    join d in _khachHangRepository.getAll() on c.IdKhachHang equals d.Id
                    select new
                    BangQuyDoiDiemViewModels
                    {
                        Id = a.Id,
                        TyLeQuyDoi = a.TyLeQuyDoi,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai,
                        IdKH = d.Id,
                        STD = d.Sdt
                    }).ToList();
        }

        public bool remove(Guid vi)
        {
            if (_BangQuyDoiDiem.remove(vi)) return true;
            return false;
        }

        public bool update(BangQuyDoiDiemViewModels vi)
        {
            QuyDoiDiem quyDoiDiem = _BangQuyDoiDiem.getAll().FirstOrDefault(p => p.Id == vi.Id);
            quyDoiDiem.TyLeQuyDoi = vi.TyLeQuyDoi;
            quyDoiDiem.TrangThai = vi.TrangThai;
            quyDoiDiem.Ten = vi.Ten;
            if (_BangQuyDoiDiem.update(quyDoiDiem)) return true;
            return false;
        }
    }
}
