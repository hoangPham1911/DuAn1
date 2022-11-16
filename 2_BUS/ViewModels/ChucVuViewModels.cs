using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class ChucVuViewModels
    {
        public Guid Id { get; set; }
    
        public string Ma { get; set; }
        public string Ho { get; set; }
        public string TenDem { get; set; }
        public string Ten { get; set; }

        public string HoTen
        {
            get { return $"{Ho}{TenDem}{Ten}"; }
            set { HoTen = value; }
        }

        public int TrangThai { get; set; }

    }
}
