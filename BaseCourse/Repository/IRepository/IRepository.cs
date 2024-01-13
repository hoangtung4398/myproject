using BaseCourse.Models;
using System.Linq.Expressions;

namespace BaseCourse.Repository.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Delete(int id);
        void Update(T entity);
        int Add(T entity);

    }
}
