using Common.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        public static List<Product> GetData()
        {
            return Data.DataOperations.GetAllProducts();
        }

        public static Product GetDataByID(int id)
        {
            return Data.DataOperations.GetProductByID(id);
        }
    }
}
