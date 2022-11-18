using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class LoaiGiayServices : ILoaiGiayServices
    {
        private ILoaiGiayRepository loaiGiayrp;
        private List<LoaiGiayViewModels> lstLoaiGiay;

        public LoaiGiayServices()
        {
            loaiGiayrp = new LoaiGiayRepositores();
            lstLoaiGiay = new List<LoaiGiayViewModels>();
        }
        public string add(LoaiGiayViewModels LG)
        {
            if (LG == null) return "Không Thành Công";
            var temp = loaiGiayrp.getAll().FirstOrDefault(c => c.Ma == LG.Ma);
            LoaiGiay x = new LoaiGiay()
            {
                Id = LG.Id,
                Ma = LG.Ma,
                Ten = LG.Ten,
                TrangThai = LG.TrangThai
            };
            if (temp == null)
            {
                if (LG.Ma != "")
                {
                    if (loaiGiayrp.add(x)) return "Thêm Thành Công";
                    return "Không Thành Công";
                }
                else return "Chưa nhập mã";
            }
            else { return "Trùng mã rồi"; }
        }

        public List<LoaiGiayViewModels> GetLoaiGiay()
        {
            lstLoaiGiay = (from lg in loaiGiayrp.getAll()
                           select new LoaiGiayViewModels
                           {
                               Id = lg.Id,
                               Ma = lg.Ma,
                               Ten = lg.Ten,
                               TrangThai = lg.TrangThai,
                           }).OrderBy(c => c.Ma).ToList();
            return lstLoaiGiay;
        }

        public string remove(LoaiGiayViewModels LG)
        {
            if (LG == null) return "Không Thành Công";
            int a = 0;
            var x = new LoaiGiay()
            {
                Id = LG.Id
            };
            var list = loaiGiayrp.getAll();
            foreach (var i in list)
            {
                if (LG.Id == i.Id) a++;
            }
            if (loaiGiayrp.remove(x)) return "Xóa Thành Công";
            return "Không Thành Công";
        }

        public string update(LoaiGiayViewModels LG)
        {
            if (LG == null) return "Không Thành Công";
            var temp = loaiGiayrp.getAll().FirstOrDefault(c => c.Id == LG.Id);
            LoaiGiay x = new LoaiGiay()
            {
                Id = LG.Id,
                Ma = LG.Ma,
                Ten = LG.Ten,
                TrangThai = LG.TrangThai
            };
            if (LG.Ma != "")
            {
                if (temp == null)
                {
                    if (loaiGiayrp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else if (LG.Id == x.Id)
                {
                    if (loaiGiayrp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else { return "Trùng rồi kìa"; }
            }
            else return "Vui lòng đủ thông tin";
        }

    }
}
