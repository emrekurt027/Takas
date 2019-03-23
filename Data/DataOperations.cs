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
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
            }
        }

        public static void InitDatabase()
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.Initialize(false);
            }
        }

        public static List<Product> GetAllProducts()
        {
            using (var mydb=new MyDbContext())
            {
               return mydb.Products.ToList();
            }
        }

        public static Product GetProductByID(int id)
        {
            using (var mydb = new MyDbContext())
            {
                return mydb.Products.Where(p=>p.Id==id).FirstOrDefault();
            }
        }
    }
}
