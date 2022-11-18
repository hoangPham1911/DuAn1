﻿using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepositories
{
    public interface IQuocGiaRepository
    {
        bool add(QuocGia producter);
        bool remove(QuocGia producter);
        List<QuocGia> getAll();
        bool update(QuocGia producter);
    }
}
