using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductDetailModel
    {
        public ProductShowModel Product { get; set; }
        public List<ProductShowModel> RecommendedList { get; set; }
    }
}
