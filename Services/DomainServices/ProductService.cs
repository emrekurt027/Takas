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
    public class ProductService:BaseService<Product>
    {
        public Product GetByName(string name)
        {
            using (context = new MyDbContext())
            {
                return context.Set<Product>().Where(p => p.Name == name).FirstOrDefault();
            }
        }

        public ProductShowModel GetProductDetails(int id)
        {
            using (context = new MyDbContext())
            {
                var productDetail = (from products in context.Products
                                     join a in context.Authors on products.AuthorId equals a.Id
                                     join u in context.Users on products.UserId equals u.Id
                                     where products.Id == id
                                     select new ProductShowModel
                                     {
                                         Name = products.Name,
                                         AuthorName = a.Name,
                                         Description = products.Description,
                                         Images = products.ImageUrl,
                                         UserName = u.UserName
                                     }).FirstOrDefault();

                productDetail.Categories = context.Categories.Where(p => p.ProductID == id).Select(z => z.Name).ToList();

                return productDetail;
            }
        }
    }
}
