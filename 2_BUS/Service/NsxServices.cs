using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.Models;
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
    public class NsxServices : INsxServices
    {
        private INsxRepository insxrp;
        private List<NsxViewModels> lstNsx;

        public NsxServices()
        {
            insxrp = new NsxRepositores();
            lstNsx = new List<NsxViewModels>();
        }
        public string add(NsxViewModels NSX)
        {
            if (NSX == null) return "Không Thành Công";
            var temp = insxrp.getAll().FirstOrDefault(c => c.Ma == NSX.Ma);
            Nsx x = new Nsx()
            {
                Id = NSX.Id,
                Ma = NSX.Ma,
                Ten = NSX.Ten,
                TrangThai = NSX.TrangThai
            };
            if (temp == null)
            {
                if (NSX.Ma != "")
                {
                    if (insxrp.add(x)) return "Thêm Thành Công";
                    return "Không Thành Công";
                }
                else return "Chưa nhập mã";
            }
            else { return "Trùng rồi"; }
        }

        public List<NsxViewModels> GetNhasanxuat()
        {
            lstNsx = (from nsx in insxrp.getAll()
                           select new NsxViewModels
                           {
                               Id = nsx.Id,
                               Ma = nsx.Ma,
                               Ten =nsx.Ten,
                               TrangThai = nsx.TrangThai,
                           }).OrderBy(c => c.Ma).ToList();
            return lstNsx;
        }

        public string remove(NsxViewModels NSX)
        {
            if (NSX == null) return "Không Thành Công";
            int a = 0;
            var x = new Nsx()
            {
                Id = NSX.Id
            };
            var list = insxrp.getAll();
            foreach (var i in list)
            {
                if (NSX.Id == i.Id) a++;
            }
            if (insxrp.remove(x)) return "Xóa Thành Công";
            return "Không Thành Công";
        }

        public string update(NsxViewModels NSX)
        {
            if (NSX == null) return "Không Thành Công";
            var temp = insxrp.getAll().FirstOrDefault(c => c.Id == NSX.Id);
            Nsx x = new Nsx()
            {
                Id = NSX.Id,
                Ma = NSX.Ma,
                Ten = NSX.Ten,
                TrangThai = NSX.TrangThai
            };
            if (NSX.Ma != "")
            {
                if (temp == null)
                {
                    if (insxrp.update(x)) return "Sửa Thành Công";
                    
                    return "Không Thành Công";
                }
                else if (NSX.Id == x.Id)
                {
                    if (insxrp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                    
                }
                else { return "Trùng rồi"; }
            }
            else return "Nhập đủ thông tin";
        }
    
    }
}
