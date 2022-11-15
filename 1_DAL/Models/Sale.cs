﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1_DAL.Models
{
    [Table("Sale")]
    [Index(nameof(MaGiamGia), Name = "UQ_MaGiamGia", IsUnique = true)]
    public partial class Sale
    {
        public Sale()
        {
            SaleChiTiets = new HashSet<SaleChiTiet>();
        }
        [Key]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string MaGiamGia { get; set; }

        [StringLength(30)]
        public string TenChuongTrinh { get; set; }

        public int TrangThai { get; set; }

        public virtual ICollection<SaleChiTiet> SaleChiTiets { get; set; }
    }
}