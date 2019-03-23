
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Domains
{
    public class Image : BaseEntity
    {

        [Required(ErrorMessage = "Image URL is required")]
        public string URL { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }


    }
}