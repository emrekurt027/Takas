using Common.Domains;
using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        MyDbContext context;

        public async Task<List<Product>> GetAllData()
        {
            using (context = new MyDbContext())
            {
                return await context.Products.ToListAsync();
            }
        }

        public async Task<Product> GetDataByID(int id)
        {
            using (context = new MyDbContext())
            {
                return await context.Products.FindAsync(id);
            }
        }

        /*public async Task Add(Product product)
        {
            using (context = new MyDbContext())
            {
                context.Products.Add(product);
            }
        }*/
    }
}
