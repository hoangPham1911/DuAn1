using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface ISizeGiayServices
    {
        string add(SizeGiayViewModels size);
        string remove(SizeGiayViewModels size);
        string update(SizeGiayViewModels size);
        public Guid IdSize(SizeGiayViewModels CL);
 
        List<SizeGiayViewModels> GetSizeGiay();
    }
}
