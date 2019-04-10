using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class OrderShowModel
    {
        public int OrderID { get; set; }
        public bool State { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
