﻿using _1_DAL.Context;
using _1_DAL.IRepositories;
using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Repositores
{
    public class SaleRepositores : ISaleRepository
    {
        public ManagerContext _DbContext;
        public SaleRepositores()
        {
            _DbContext = new ManagerContext();
        }
        public bool add(Sale sale)
        {
            try
            {
                _DbContext.Sales.Add(sale);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Sale> getAll()
        {
            return _DbContext.Sales.ToList();

        }

        public bool remove(Sale id)
        {
            try
            {
                _DbContext.Sales.Remove(id);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(Sale sale)
        {
            try
            {
                _DbContext.Sales.Update(sale);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}