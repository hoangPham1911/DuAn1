using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IreceiptRepository
    {
        List<HoaDon> getAllReceipt();
        bool addReceipt(HoaDon hd);
        bool removeReceipt(Guid hd);

        bool updateReceipt(HoaDon hd);
                        
    }
}
