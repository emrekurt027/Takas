using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Comment: BaseEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
    }
}
