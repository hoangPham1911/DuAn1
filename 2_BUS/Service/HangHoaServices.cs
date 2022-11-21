using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
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
    public class HangHoaServices: IHangHoaServices
    {
        INsxRepository _iNsxRepository;
        IProductRepository _iHangHoaRepository;

        public HangHoaServices()
        {
            _iHangHoaRepository = new ProductRepositores();
            _iNsxRepository = new NsxRepositores();
        }

        public List<HangHoaViewModels> getlsthanghoafromDB()
        {
            return (from a in _iHangHoaRepository.getAll()
               
                    join b in _iNsxRepository.getAll() on a.IdNsx equals b.Id
                  
                    select new HangHoaViewModels
                    {
                        Id = a.Id,
                        IdNsx = b.Id,
                        Ma = a.Ma,
                        Ten = a.Ten,
                        TrangThai = a.TrangThai
                    }).ToList();
        }

        public bool addhanghoa(HangHoaThemViewModels HangHoas)
        {
            HangHoa hangHoa = new HangHoa();
            hangHoa.IdNsx = HangHoas.IdNsx;
            hangHoa.Ma = HangHoas.Ma;
            hangHoa.Ten = HangHoas.Ten;
            hangHoa.TrangThai = HangHoas.TrangThai;
            if (_iHangHoaRepository.add(hangHoa))
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updatehanghoa(HangHoaUpdateViewModels HangHoas)
        {
            HangHoa hangHoa = new HangHoa();
            hangHoa.IdNsx = HangHoas.IdNsx;
            hangHoa.Ma = HangHoas.Ma;
            hangHoa.Ten = HangHoas.Ten;
            hangHoa.TrangThai = HangHoas.TrangThai;
            if (_iHangHoaRepository.update(hangHoa))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deletehanghoa(HangHoaViewModels hanghoaid)
        {
            var hangHoa = _iHangHoaRepository.getAll().FirstOrDefault(p => p.Id == hanghoaid.Id);
            if (_iHangHoaRepository.remove(hangHoa))
                return true;
            return false;
        }

    }
}
