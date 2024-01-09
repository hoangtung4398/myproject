using CourseAPI.Models;
using System.Linq.Expressions;

namespace CouponAPI.Repository.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable Get(Expression<Func<T, bool>> predicate);
        void Delete(int id);
        void Update(T entity);
        void Add(T entity);

    }
}
