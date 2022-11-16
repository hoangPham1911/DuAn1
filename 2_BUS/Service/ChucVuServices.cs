using _1.DAL.DALServices;
using _1.DAL.IDALServices;
using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class ChucVuServices : IChucVuServices
    {
        private IPositionRepository _positionRepository;
        public ChucVuServices()
        {
            _positionRepository = new PositionRepositores();
        }
        public List<ChucVuViewModels> GetAll()
        {
            var lstChucVuModel = _positionRepository.GetAll();
            var lstChucVuViewModel = new List<ChucVuViewModels>();
            foreach (var item in lstChucVuModel)
            {
                var chucVu = new ChucVuViewModels
                {
                    Id = item.Id,
                    Ma = item.Ma,
                    Ten = item.Ten
                };
                lstChucVuViewModel.Add(chucVu);
            }
            return lstChucVuViewModel;
        }

        public bool Sua(ChucVuViewModels chucVu)
        {
            var chucVuModel = new ChucVu
            {
                Id = new Guid(),
                Ma = chucVu.Ma,
                Ten = chucVu.Ten,
            };
            var relut = _positionRepository.Sua(chucVuModel);
            return relut;
        }

        public bool Them(ChucVuViewModels chucVu)
        {
            var chucVuModel = new ChucVu
            {
                Id = new Guid(),
                Ma = chucVu.Ma,
                Ten = chucVu.Ten,
            };
            var relut = _positionRepository.Them(chucVuModel);
            return relut;
        }

        public List<ChucVuViewModels> TimKiem(string Ma)
        {
            var lstChucVuModel = _positionRepository.TimKiem(Ma);
            var lstChucVuViewModel = new List<ChucVuViewModels>();
            foreach (var item in lstChucVuModel)
            {
                var chucVu = new ChucVuViewModels
                {
                    Id = item.Id,
                    Ma = item.Ma,
                    Ten = item.Ten
                };
                lstChucVuViewModel.Add(chucVu);
            }
            return lstChucVuViewModel;
        }

        public bool Xoa(Guid Id)
        {
            var kq = _positionRepository.Xoa(Id);
            return kq;
        }
    }
}
