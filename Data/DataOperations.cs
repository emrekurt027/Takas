using Common.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataOperations
    {
        public static void CreateDatabaseIfNotExists()
        {
            MyDbContext db = new MyDbContext();

            db.Database.CreateIfNotExists();
        }
        public static List<Product> GetAllProducts()
        {
            using (var mydb=new MyDbContext())
            {
               return mydb.Products.ToList();
            }
        }     
    }
}
