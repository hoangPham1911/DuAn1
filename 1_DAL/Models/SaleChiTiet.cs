﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("SaleChiTiet")]

    public partial class SaleChiTiet
    {
        public SaleChiTiet()
        {

        }
        [Key]
        [Required]
        public Guid IdSale { get; set; }
        [Key]
        [Required]
        public Guid IdChiTietHangHoa { get; set; }
        
        public decimal? DonGia { get; set; }
        public decimal? SoTienSauKhiGiam { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(IdSale))]
        [InverseProperty(nameof(Sale.SaleChiTiets))]

        public virtual Sale SaleNavigation { get; set; }

        [ForeignKey(nameof(IdChiTietHangHoa))]
        [InverseProperty(nameof(ChiTietHangHoa.SaleChiTiets))]
        public virtual ChiTietHangHoa ChiTietHangHoaNavigation { get; set; }
    }
}