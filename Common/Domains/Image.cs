using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Image: BaseEntity
    {
        public string URL { get; set; }
        public string fas3 { get; set; }
        public string fas343 { get; set; }
        public int ProductId { get; set; }
        public int ProductId2 { get; set; }
    }
}
