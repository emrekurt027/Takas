using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class AddUserModel
    {
        [Required(ErrorMessage = "{0} is not Empty!")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "{0} Required!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                    ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        [StringLength(50, ErrorMessage = "{0} minimum 8 character.!", MinimumLength = 8)]
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
