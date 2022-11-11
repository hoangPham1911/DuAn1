using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public  interface ITypeTableOfContents
    {
        bool add(KieuDanhMuc client);
        bool remove(Guid id);
        List<KieuDanhMuc> getAll();

        bool update(KieuDanhMuc clinet);
    }
}
