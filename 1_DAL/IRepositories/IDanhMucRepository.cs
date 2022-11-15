using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface IDanhMucRepository
    {
        bool add(DanhMuc tableOfContents);
        bool remove(DanhMuc tableOfContents);
        List<DanhMuc> getAll();

        bool update(DanhMuc tableOfContents);
    }
}
