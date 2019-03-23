using Common.Domains;
using Goodreads;
using Goodreads.Models.Response;
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
        public async Task IndexAsync()
        {
            // Create an unauthorized Goodreads client.
            var client = GoodreadsClient.Create(apiKey, apiSecret);

            // Now you are able to call some Goodreads endpoints that don't need the OAuth credentials. For example:
            // Get a book by specified id.
            Book kitap = await client.Books.GetByTitle("hell");
            string authorname = "";
            foreach (var item in kitap.Authors)
            {
                authorname += item.Name + " & ";
            }
            authorname = authorname.Substring(0, authorname.Length - 3);

            Common.Domains.Author author = new Common.Domains.Author
            {
                Name = authorname
            };


            Product book = new Product
            {
            }
            Common.Domains.Category categories = new Category
            {

            };
        }
    }
}
