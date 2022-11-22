using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SanPhamView
    {
        public Guid IdHangHoaChiTiet { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }

        public Guid? IdSp { get; set; }

        public Guid? IdAnh { get; set; }

        public byte[]? img { get; set; }
        public int? SoLuongTon { get; set; }

        public decimal? GiaBan { get; set; }

    }
}
