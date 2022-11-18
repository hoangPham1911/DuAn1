using _1_DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class ChatLieuViewModels
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }

        public int TrangThai { get; set; }
    }
}
