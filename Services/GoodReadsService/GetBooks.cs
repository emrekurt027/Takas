using Common.Domains;
using Goodreads;
using Goodreads.Models.Response;
using Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.GoodReadsService
{
    public class GetBooks
    {
        const string apiKey = "G7huqYW2RzxjnBGnexRPAQ";
        const string apiSecret = "LUzJiVl6oHg7ASbo5IKmsNqfndAeAJhv3FKQFota7g";
        // GET: Home
        public async Task IndexAsync(string booksName)
        {
            // Create an unauthorized Goodreads client.
            var client = GoodreadsClient.Create(apiKey, apiSecret);

            // Now you are able to call some Goodreads endpoints that don't need the OAuth credentials. For example:
            // Get a book by specified id.
            Book kitap = await client.Books.GetByTitle(booksName);
            string authorname = "";
            foreach (var item in kitap.Authors)
            {
                authorname += item.Name + " & ";
            }
            authorname = authorname.Substring(0, authorname.Length - 3);
            //db yazar
            AuthorService _authorService = new AuthorService();
            Common.Domains.Author author = new Common.Domains.Author
            {
                Name = authorname
            };
            await _authorService.Add(author);
            //db image

            ProductService _productService = new ProductService();
            Product book = new Product
            {
                AuthorId = _authorService.GetByName(authorname).Id,
                ImageUrl = kitap.ImageUrl,
                Description = kitap.Description,
                Verify = false,
                Name=kitap.Title                
            };
            await _productService.Add(book);

            CategoryService _categoryService = new CategoryService();
            foreach (var item in kitap.PopularShelves)
            {
                Common.Domains.Category categories = new Category
                {
                    Name = item.Key,
                    ProductID=_productService.GetByName(kitap.Title).Id
                };
                await _categoryService.Add(categories);

            }
            int x = 15;
           
        }
    }
}
