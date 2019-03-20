using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CheckDbCreate
    {
       public static void CreateseIfNotExists()
        {
            Data.DataOperations.CreateDatabaseIfNotExists();         
        }
    }
}
