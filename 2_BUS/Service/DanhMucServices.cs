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
    public class DanhMucServices : IDanhMucServices
    {
        private IDanhMucRepository iDanhMucRP;
        private List<DanhMucViewModels> lstdanhmuc;

        public DanhMucServices()
        {
            iDanhMucRP = new DanhMucRepositores();
            lstdanhmuc = new List<DanhMucViewModels>();
        }
        public string add(DanhMucViewModels DM)
        {
            if (DM == null) return "Không Thành Công";
            var temp = iDanhMucRP.getAll().FirstOrDefault(c => c.Ma == DM.Ma);
            DanhMuc x = new DanhMuc()
            {
                Id = DM.Id,
                Ma = DM.Ma,
                Ten = DM.Ten,
                TrangThai = DM.TrangThai,
                IdDanhMucKhac = DM.IdDanhMucKhac,
            };
            if (temp == null)
            {
                if (DM.Ma != "")
                {
                    if (iDanhMucRP.add(x)) return "Thêm Thành Công";
                    return "Không Thành Công";
                }
                else return "Chưa nhập mã";
            }
            else { return "Trùng rồi"; }
        }

        public List<DanhMucViewModels> GetDanhMuc()
        {
            lstdanhmuc = (from dm in iDanhMucRP.getAll()
                      select new DanhMucViewModels
                      {
                          Id = dm.Id,
                          Ma = dm.Ma,
                          Ten = dm.Ten,
                          TrangThai = dm.TrangThai,
                          IdDanhMucKhac = dm.IdDanhMucKhac,
                      }).OrderBy(c => c.Ma).ToList();
            return lstdanhmuc;
        }

        public string remove(DanhMucViewModels DM)
        {
            if (DM == null) return "Không Thành Công";
            int a = 0;
            var x = new DanhMuc()
            {
                Id = DM.Id
            };
            var list = iDanhMucRP.getAll();
            foreach (var i in list)
            {
                if (DM.Id == i.Id) a++;
            }
            if (iDanhMucRP.remove(x)) return "Xóa Thành Công";
            return "Không Thành Công";
        }

        public string update(DanhMucViewModels DM)
        {
            if (DM == null) return "Không Thành Công";
            var temp = iDanhMucRP.getAll().FirstOrDefault(c => c.Id == DM.Id);
            DanhMuc x = new DanhMuc()
            {
                Id = DM.Id,
                Ma = DM.Ma,
                Ten = DM.Ten,
                TrangThai = DM.TrangThai,
                IdDanhMucKhac = DM.IdDanhMucKhac,
            };
            if (DM.Ma != "")
            {
                if (temp == null)
                {
                    if (iDanhMucRP.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else if (DM.Id == x.Id)
                {
                    if (iDanhMucRP.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else { return "Trùng rồi"; }
            }
            else return "Nhập đủ thông tin";
        }
    }
}
