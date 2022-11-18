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
    public class QuocGiaServices : IQuocGiaServices
    {
        private IQuocGiaRepository quocGiarp;
        private List<QuocGiaViewModels> lstQuocGia;

        public QuocGiaServices()
        {
            quocGiarp = new QuocGiaRepositores();
            lstQuocGia = new List<QuocGiaViewModels>();
        }
        public string add(QuocGiaViewModels QG)
        {
            if (QG == null) return "Không Thành Công";
            var temp = quocGiarp.getAll().FirstOrDefault(c => c.Ma == QG.Ma);
            QuocGia x = new QuocGia()
            {
                Id = QG.Id,
                Ma = QG.Ma,
                Ten = QG.Ten,
                TrangThai = QG.TrangThai
            };
            if (temp == null)
            {
                if (QG.Ma != "")
                {
                    if (quocGiarp.add(x)) return "Thêm Thành Công";
                    return "Không Thành Công";
                }
                else return "Chưa nhập mã";
            }
            else { return "Trùng mã rồi"; }
        }

        public List<QuocGiaViewModels> GetQuocGia()
        {
            lstQuocGia = (from qg in quocGiarp.getAll()
                      select new QuocGiaViewModels
                      {
                          Id = qg.Id,
                          Ma = qg.Ma,
                          Ten = qg.Ten,
                          TrangThai = qg.TrangThai,
                      }).OrderBy(c => c.Ma).ToList();
            return lstQuocGia;
        }

        public string remove(QuocGiaViewModels QG)
        {
            if (QG == null) return "Không Thành Công";
            int a = 0;
            var x = new QuocGia()
            {
                Id =QG.Id
            };
            var list = quocGiarp.getAll();
            foreach (var i in list)
            {
                if (QG.Id == i.Id) a++;
            }
            if (quocGiarp.remove(x)) return "Xóa Thành Công";
            return "Không Thành Công";
        }

        public string update(QuocGiaViewModels QG)
        {
            if (QG == null) return "Không Thành Công";
            var temp = quocGiarp.getAll().FirstOrDefault(c => c.Id == QG.Id);
            QuocGia x = new QuocGia()
            {
                Id = QG.Id,
                Ma = QG.Ma,
                Ten = QG.Ten,
                TrangThai = QG.TrangThai
            };
            if (QG.Ma != "")
            {
                if (temp == null)
                {
                    if (quocGiarp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else if (QG.Id == x.Id)
                {
                    if (quocGiarp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else { return "Trùng rồi kìa"; }
            }
            else return "Vui lòng đủ thông tin";
        }

    }
}

