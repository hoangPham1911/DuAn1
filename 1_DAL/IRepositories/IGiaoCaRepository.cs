using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IGiaoCaRepository
    {
        bool Them(GiaoCa giaoCa);
        bool Sua(GiaoCa giaoCa);
        bool Xoa(Guid Id);
        List<GiaoCa> GetAll();
        List<GiaoCa> TimKiem(string Ma);
    }
}
