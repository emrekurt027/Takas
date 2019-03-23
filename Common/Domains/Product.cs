using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Product:BaseEntity
    {
        public int AuthorId { get; set; }
        public int PictureId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Verify { get; set; }
    }
}
