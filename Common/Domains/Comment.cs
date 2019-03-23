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
        public int UserId { get; set; }
        [Required(ErrorMessage = "Description cannot be empty..")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        //user tablosu gelince eklenicek --> 
        //public User User { get; set; }
        //[ForeignKey("CommentId")]
        //public ICollection<Comment> Comments { get; set; } -->> diğer tabloda da bunlar olucak
    }
}
