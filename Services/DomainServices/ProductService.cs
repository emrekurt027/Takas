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

        public async Task<List<ProductShowModel>> GetRandomProducts(int limit)
        {
            using (context = new MyDbContext())
            {
                int count = context.Products.Count();
                if (count >= limit)
                {
                    count = limit;
                }

                return await context.Products.OrderBy(r => Guid.NewGuid()).Take(count).Select(p => new ProductShowModel()
                {
                    Id = p.Id,
                    Images = p.ImageUrl
                }).ToListAsync();
            }
        }

        public List<ProductShowModel> GetAllForProductsIndex()
        {
            using (context = new MyDbContext())
            {
                return context.Products.Select(p => new ProductShowModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Images = p.ImageUrl
                }).ToList();
            }
        }
        public async Task<ProductShowModel> GetProductDetails(int id)
        {
            using (context = new MyDbContext())
            {
                ProductShowModel Model = await context.Products.Where(p => p.Id == id).Select(product => new ProductShowModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    AuthorName = product.Author.Name,
                    Description = product.Description,
                    Images = product.ImageUrl,
                    UserName = context.Users.Where(u => u.Id == product.UserId).FirstOrDefault().UserName,
                    Notes = product.Notes,
                    Categories = product.Categories.Select(c => c.Name).ToList()
                }).FirstOrDefaultAsync();
                return Model;
            }
        }

        public async Task AddNewProduct(ProductAddModel pModel)
        {
            using (context = new MyDbContext())
            {
                Author author = context.Authors.Where(p => p.Name == pModel.AuthorName).FirstOrDefault();
                if (author == null)
                {
                    author = new Author
                    {
                        Name = pModel.AuthorName
                    };

                    context.Authors.Add(author);
                }

                Product product = new Product()
                {
                    AuthorId = author.Id,
                    Name = pModel.Name,
                    UserId = pModel.UserId,
                    Description = pModel.Description,
                    Notes = pModel.Notes,
                    ImageUrl = pModel.ImageUrl,
                    Verify = false,
                };

                context.Products.Add(product);

                List<Category> catList = new List<Category>();
                foreach (var item in pModel.Categories.Split(','))
                {
                    if(context.Categories.Where(p=>p.Name == item).Count() == 0)
                    {
                        Category cat = new Category
                        {
                            Name = item,
                            ProductID = product.Id
                        };
                        catList.Add(cat);
                    }
                };
                if(catList.Count > 0)
                    context.Categories.AddRange(catList);


                await context.SaveChangesAsync();
            }
        }


    }
}
