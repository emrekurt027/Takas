using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Category: BaseEntity
    {

        [MaxLength(100)]
        public string Name { get; set; }
        public int ProductID { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
