﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domains
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public int ProductID { get; set; }
    }
}
