using _1_DAL.Context;
using _1_DAL.Models;
using _1.DAL.IDALServices;
using _1.DAL.IRepostiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.DALServices
{
    public class PositionRepositores : IPositionRepository
    {
        private ManagerContext _DBcontext;
        private List<ChucVu> _lstChucVu;
        public PositionRepositores()
        {
            _DBcontext = new ManagerContext();
            _lstChucVu = new List<ChucVu>();

        }
        public bool addChucVu(ChucVu chucVu)
        {
            _DBcontext.ChucVus.Add(chucVu);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteChucVu(ChucVu chucVu)
        {
            _DBcontext.ChucVus.Remove(chucVu);
            _DBcontext.SaveChanges();
            return true;
        }

        public List<ChucVu> getChucVusFromDB()
        {
            _lstChucVu = _DBcontext.ChucVus.ToList();
            return _lstChucVu;
        }

        public bool updateChucVu(ChucVu chucVu)
        {
            _DBcontext.ChucVus.Update(chucVu);
            _DBcontext.SaveChanges();
            return true;
        }
    }
}
