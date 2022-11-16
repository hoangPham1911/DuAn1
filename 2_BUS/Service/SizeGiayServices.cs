using _1_DAL.IRepostiories;
using _1_DAL.Models;
using _1_DAL.Repostiores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class SizeGiayServices : ISizeGiayServices
    {
        private ISizeShoseRepository sizeGiay;
        private List<SizeGiayViewModels> lstSizeGiay;
        public SizeGiayServices()
        {
            sizeGiay = new SizeShoseRepositores();
            lstSizeGiay = new List<SizeGiayViewModels>();
        }
        public string add(SizeGiayViewModels size)
        {
            if (size == null) return "Không Thành Công";
            var temp = sizeGiay.getAll().FirstOrDefault(c => c.Ma == size.Ma);
            SizeGiay x = new SizeGiay()
            {
                Id = size.Id,
                Ma = size.Ma,
                SoSize = size.SoSize,
                TrangThai = size.TrangThai
            };
            if (temp == null)
            {
                if (size.Ma != "")
                {
                    if (sizeGiay.add(x)) return "Thêm Thành Công";
                    return "Không Thành Công";
                }
                else return "Chưa nhập mã";
            }
            else { return "Trùng rồi"; }
        }

        public List<SizeGiayViewModels> GetSizeGiay()
        {
            lstSizeGiay = (from sz in sizeGiay.getAll()
                           select new SizeGiayViewModels
                           {
                               Id = sz.Id,
                               Ma = sz.Ma,
                               SoSize = sz.SoSize,
                               TrangThai = sz.TrangThai,
                           }).OrderBy(c => c.Ma).ToList();
            return lstSizeGiay;
        }

        public string remove(SizeGiayViewModels size)
        {
            if (size == null) return "Không Thành Công";
            int a = 0;
            var x = new SizeGiay()
            {
                Id = size.Id
            };
            var list = sizeGiay.getAll();
            foreach (var i in list)
            {
                if (size.Id == i.Id) a++;
            }
            if (sizeGiay.remove(x)) return "Xóa Thành Công";
            return "Không Thành Công";
        }

        public string update(SizeGiayViewModels size)
        {
            if (size == null) return "Không Thành Công";
            var temp = sizeGiay.getAll().FirstOrDefault(c => c.Id == size.Id);
            SizeGiay x = new SizeGiay()
            {
                Id = size.Id,
                Ma = size.Ma,
                SoSize = size.SoSize,
                TrangThai = size.TrangThai
            };
            if ( size.Ma != "")
            {
                if (temp == null)
                {
                    if (sizeGiay.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else if (size.Id == x.Id)
                {
                    if (sizeGiay.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else { return "Trùng rồi"; }
            }
            else return "Nhập đủ thông tin";
        }

    }
}
