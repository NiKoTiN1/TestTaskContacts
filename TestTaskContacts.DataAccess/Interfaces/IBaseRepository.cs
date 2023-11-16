using System.Linq.Expressions;
using TestTaskContacts.Domain.Models;

namespace TestTaskContacts.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public Task Add(T item);
        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string[] children = null);
        public Task Update(T item);
        public Task Remove(T item);
    }
}
