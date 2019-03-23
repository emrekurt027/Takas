using Common.Domains;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class AuthorService : BaseService<Author>
    {
        public Author GetByName(string name)
        {
            using (context = new MyDbContext())
            {
                return context.Set<Author>().Where(p => p.Name == name).FirstOrDefault();
            }
        }
    }
}
