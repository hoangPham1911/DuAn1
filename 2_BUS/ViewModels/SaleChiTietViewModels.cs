using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SaleChiTietViewModels
    {
        public Guid IdSale { get; set; }
        public Guid IdHangHoa { get; set; }
        public decimal? GiamTheoPhanTram { get; set; }
        public decimal? GiamTheoKhoangTien { get; set; } 
    }
}
