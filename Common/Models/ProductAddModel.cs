using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductAddModel
    {
        public int AuthorId { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty..")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be empty..")]
        public string Description { get; set; }

        public bool Verify { get; set; }

        public string ImageUrl { get; set; }
    }
}
