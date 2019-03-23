using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Order: BaseEntity
    {
        public bool State { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        public ICollection<Product> Products { get; set; }

        //user tablosu gelince eklenicek --> 
        //public User User { get; set; }
        //[ForeignKey("CommentId")]
        //public ICollection<Order> Orders { get; set; } -->> diğer tabloda da bunlar olucak
    }
}
