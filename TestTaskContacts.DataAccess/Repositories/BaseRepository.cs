using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTaskContacts.DataAccess.Interfaces;
using TestTaskContacts.Domain.Models;

namespace TestTaskContacts.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        private DbSet<T> Set => context.Set<T>();

        protected readonly DatabaseContext context;

        public async Task Add(T item)
        {
            Set.Add(item);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string[] children = null)
        {
            try
            {
                IQueryable<T> query = Set;

                if (children != null)
                {
                    foreach (string entity in children)
                    {
                        query = query.Include(entity);
                    }
                }

                if (filter == null)
                {
                    return query;
                }
                return query.Where(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Remove(T item)
        {
            context.Remove(item);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(T item)
        {
            context.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
