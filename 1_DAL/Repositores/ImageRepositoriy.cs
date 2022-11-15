using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class ImageRepositoriy : IImageRepositoriy
    {
        ManagerContext _DBcontext;
        public ImageRepositoriy()
        {
            _DBcontext = new ManagerContext();
        }
        public bool add(Anh image)
        {
            try
            {
                _DBcontext.Anhs.Add(image);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Anh> getAll()
        {
            return _DBcontext.Anhs.ToList();
        }

        public bool remove(Anh image)
        {
             
            try
            {
                var x = _DBcontext.Anhs.FirstOrDefault(p=>p.ID==image.ID);
                _DBcontext.Anhs.Remove(x);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(Anh image)
        {
            try
            {
                _DBcontext.Anhs.Update(image);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
