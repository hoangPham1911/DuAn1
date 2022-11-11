using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface ITableOfContentsRepository
    {
        bool add(DanhMuc tableOfContents);
        bool remove(DanhMuc id);
        List<DanhMuc> getAll();

        bool update(DanhMuc tableOfContents);
    }
}
