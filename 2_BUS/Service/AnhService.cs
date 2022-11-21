using _1_DAL.IRepositories;
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
    public class AnhService : IAnhService
    {
        public IImageRepositoriy _ImageRepositoriy;
        public AnhService()
        {
            _ImageRepositoriy = new ImageRepositoriy();
        }
        public bool add(AnhViewModels img)
        {
            Anh image = new Anh();
            img.TrangThai = img.TrangThai;
            image.DuongDan = img.DuongDan;
            img.TenAnh = img.TenAnh;
            img.MaAnh = img.MaAnh;
            if (_ImageRepositoriy.add(image)) 
                return true;
            return false;
        }

        public List<AnhViewModels> GetDanhMuc()
        {
            return (from a in _ImageRepositoriy.getAll()
                    select new AnhViewModels
                    {
                        MaAnh = a.MaAnh,
                        TenAnh = a.TenAnh,
                        DuongDan = a.DuongDan,
                        ID = a.ID,
                        TrangThai = a.TrangThai
                    }).ToList();
        }

        public bool remove(AnhViewModels img)
        {
            var idImg = _ImageRepositoriy.getAll().FirstOrDefault(p => p.ID == img.ID);
            if (_ImageRepositoriy.remove(idImg)) return true;
            return false;
        }

        public bool update(AnhViewModels img)
        {
            Anh image = _ImageRepositoriy.getAll().FirstOrDefault(p => p.ID == img.ID);
            img.TrangThai = img.TrangThai;
            image.DuongDan = img.DuongDan;
            img.TenAnh = img.TenAnh;
            img.MaAnh = img.MaAnh;
            if (_ImageRepositoriy.add(image))
                return true;
            return false;
        }
    }
}
