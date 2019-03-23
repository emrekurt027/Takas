using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Comment: BaseEntity
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Description cannot be empty..")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        
    }
}
