using Common.Domains;
using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<T> where T : BaseEntity
    {
        protected MyDbContext context;

        public async Task<List<T>> GetAll()
        {
            using (context = new MyDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (context = new MyDbContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task Add(T obj)
        {
            using (context = new MyDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(T obj)
        {
            using (context = new MyDbContext())
            {
                var oldProduct = await GetById(obj.Id);
                if (oldProduct == null)
                    return false;
                context.Entry(oldProduct).CurrentValues.SetValues(obj);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task Update(int id)
        {
            T obj = await GetById(id);
            await Update(obj);
        }

        public async Task Delete(T obj)
        {
            using (context = new MyDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            T obj =await GetById(id);
            await Delete(obj);
        }


    }
}
