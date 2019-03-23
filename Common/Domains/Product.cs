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
        public int ImageId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Name cannot be empty..")]
        [MaxLength(100)]
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

        [ForeignKey("ImageId")]
        public ICollection<Image> Images { get; set; }

        [ForeignKey("CommentId")]
        public ICollection<Comment> Comments { get; set; }


        //user için ilişki  kurulucak..
    }

}
