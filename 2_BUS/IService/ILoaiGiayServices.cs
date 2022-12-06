using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface ILoaiGiayServices
    {
        string add(LoaiGiayViewModels loaigiay);
        string remove(LoaiGiayViewModels loaigiay);
        string update(LoaiGiayViewModels loaigiay);
        public Guid IdSize(LoaiGiayViewModels CL);
        List<LoaiGiayViewModels> GetLoaiGiay();
    }
}
