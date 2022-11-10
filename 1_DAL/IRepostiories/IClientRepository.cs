using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepostiories
{
    public interface IClientRepository
    {
        bool add(KhachHang client);
        bool remove(Guid id);   
        List<KhachHang> getAll();

        bool update(KhachHang clinet);
    }
}
