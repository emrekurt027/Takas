using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Order: BaseEntity
    {
        //gelen giden
        public bool State { get; set; }

        public string UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        public bool CheckByAdmin { get; set; }

        public virtual Product Product { get; set; }  
        
    }
}
