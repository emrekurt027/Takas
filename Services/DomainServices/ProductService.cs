﻿using Common.Domains;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class ProductService:BaseService<Product>
    {
        public Product GetByName(string name)
        {
            using (context = new MyDbContext())
            {
                return context.Set<Product>().Where(p => p.Name == name).FirstOrDefault();
            }
        }
    }
}
