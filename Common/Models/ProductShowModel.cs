using Common.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductShowModel
    {
        public string AuthorName { get; set; }
        public List<string> Images { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
    }
}
