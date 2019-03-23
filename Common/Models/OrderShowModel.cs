using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class OrderShowModel
    {
        public bool State { get; set; }
        public int Token { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
