using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Product : BaseEntity
    {
        public int AuthorId { get; set; }
//<<<<<<< HEAD
        public string UserId { get; set; }     
        [Required(ErrorMessage = "Name cannot be empty..")]
        [MaxLength(100)]
//>>>>>>> 21c5413df57deb288e05f43d32a66f8642e8d2ce
        public string Name { get; set; }
        [Required(ErrorMessage = "Description cannot be empty..")]
        public string Description { get; set; }
        public bool Verify { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("CommentId")]
        public ICollection<Comment> Comments { get; set; }


        //user için ilişki  kurulucak..
    }

}
