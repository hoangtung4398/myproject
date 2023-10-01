using AuthAPI.Models.Data;
using AuthAPI.Repositorys.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthAPI.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbcontext _db;
        internal DbSet<T> Set;
        public Repository(AppDbcontext dbcontext)
        {
            _db = dbcontext;
            Set = _db.Set<T>();
        }
        public void Delete(T entity)
        {
            Set.Remove(entity);
            _db.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Set.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return Set.ToList();
        }

        public void Update(T entity)
        {
            Set.Update(entity);
            _db.SaveChanges();
        }
    }
}
