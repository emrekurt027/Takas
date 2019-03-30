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
        [Required(ErrorMessage = "Name cannot be empty..")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Notes cannot be empty..")]
        public string Notes { get; set; }

        public string UserId { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Categories { get; set; }
    }
}
