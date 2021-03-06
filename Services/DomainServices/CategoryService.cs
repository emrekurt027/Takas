﻿using Common.Domains;
using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class CategoryService : BaseService<Category>
    {
        public Category GetByName(string name)
        {
            using (context = new MyDbContext())
            {
                return context.Set<Category>().Where(p => p.Name == name).FirstOrDefault();
            }
        }

        public async Task<List<string>> GetProductCategories(int productId)
        {
            using (context = new MyDbContext())
            {
                return await context.Set<Category>().Where(p => p.ProductID == productId).Select(n=>n.Name).ToListAsync();
            }
        }
    }
}
