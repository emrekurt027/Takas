﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Order: BaseEntity
    {
        public bool State { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }

    }
}
