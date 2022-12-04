using _1.DAL.IRepostiories;
using _1_DAL.IRepositories;
using _1_DAL.IRepostiories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _1_DAL.Repostiores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class ViDiemService : IViDiemService
    {
        private ITichDiemRepositores _ViTichDiemRepositores;

        public ViDiemService()
        {
            _ViTichDiemRepositores = new TichDiemRepositores();

        }
        public bool add(ViDiemViewModel viDiems)
        {
            ViDiem vi = new ViDiem();
            vi.Id = viDiems.Id;
            vi.TongDiem = viDiems.TongDiem;
            vi.TrangThai = viDiems.TrangThai;
            vi.IdKhachHang = viDiems.IdKhachHang;
            if (_ViTichDiemRepositores.add(vi)) return true;
            return false;
        }

        public List<ViDiemViewModel> GetViDiem()
        {
            return (from sz in _ViTichDiemRepositores.getAll()
                           select new ViDiemViewModel
                           {
                               Id = sz.Id,
                               TongDiem = sz.TongDiem,
                               IdKhachHang = sz.IdKhachHang,
                               TrangThai = sz.TrangThai,
                           }).ToList();
   
        }

        public bool remove(Guid id)
        {

            if (_ViTichDiemRepositores.remove(id)) return true;
            return false;
        }

        public bool update(ViDiemViewModel viDiems)
        {
            ViDiem vi = _ViTichDiemRepositores.getAll().FirstOrDefault(p=>p.Id == viDiems.Id);
            vi.TongDiem = viDiems.TongDiem;
            vi.TrangThai = viDiems.TrangThai;
            vi.IdKhachHang = viDiems.IdKhachHang;
            if (_ViTichDiemRepositores.update(vi)) return true;
            return false;
        }

    }
}
