using Common.Domains;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Services.DomainServices
{
    public class ProductService : BaseService<Product>
    {
        public Product GetByName(string name)
        {
            using (context = new MyDbContext())
            {
                return context.Set<Product>().Where(p => p.Name == name).FirstOrDefault();
            }
        }

        public async Task<ProductShowModel> GetProductDetails(int id)
        {
            using (context = new MyDbContext())
            {
                ProductShowModel Model = await context.Products.Where(p => p.Id == id).Select(product => new ProductShowModel()
                {
                    Name = product.Name,
                    AuthorName = product.Author.Name,
                    Description = product.Description,
                    Images = product.ImageUrl,
                    UserName = context.Users.Where(u => u.Id == product.UserId).FirstOrDefault().UserName,
                    Categories = product.Categories.Select(c => c.Name).ToList()
                }).FirstOrDefaultAsync();
                return Model;
            }
        }


    }
}
