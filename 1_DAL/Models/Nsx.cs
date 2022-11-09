using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1_DAL.Models
{
    [Table("NSX")]
    [Index(nameof(Ma), Name = "UQ_NSX", IsUnique = true)]
    public partial class Nsx
    {
        public Nsx()
        {
            HangHoas = new HashSet<HangHoa>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }

 //       [InverseProperty(nameof(HangHoa.IdNsxNavigation))]
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
