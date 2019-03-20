using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICustomUser
    {     
        decimal Credits { get; set; }
        DateTime Date { get; set; }
        string Adress { get; set; }
    }
}
