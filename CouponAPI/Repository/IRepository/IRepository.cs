using System.Linq.Expressions;

namespace CouponAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Update(T entity);
        void Add(T entity);

    }
}
