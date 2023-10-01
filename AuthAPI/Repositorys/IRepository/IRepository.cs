using System.Linq.Expressions;

namespace AuthAPI.Repositorys.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        void Update(T entity);
    }
}
