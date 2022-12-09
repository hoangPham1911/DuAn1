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
            image.Ten = img.Ten;
            image.MaAnh = img.MaAnh;
            image.DuongDan = img.DuongDan;
            image.TrangThai = img.TrangThai;
            if (_ImageRepositoriy.add(image)) 
                return true;
            return false;
        }

        public Guid Id(AnhViewModels img)
        {
            Anh image = new Anh();
            image.Ten = img.Ten;
            image.MaAnh = img.MaAnh;
            image.DuongDan = img.DuongDan;
            image.TrangThai = img.TrangThai;
            if (_ImageRepositoriy.add(image))
                return image.ID;
            return Guid.Empty;
        }

        public List<AnhViewModels> GetAnh()
        {
            return (from a in _ImageRepositoriy.getAll()
                    select new AnhViewModels
                    {
                        MaAnh = a.MaAnh,
                        Ten = a.Ten,
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
            image.Ten = img.Ten;
            image.MaAnh = img.MaAnh;
            image.DuongDan = img.DuongDan;
            image.TrangThai = img.TrangThai;
            if (_ImageRepositoriy.update(image))
                return true;
            return false;
        }
    }
}
