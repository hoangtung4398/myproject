using CouponAPI.Models.Data;
using CouponAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CouponAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbcontext _dbcontext;
        private DbSet<T> Set;
        public Repository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            this.Set = _dbcontext.Set<T>();
        }

        public void Add(T entity)
        {
            Set.Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
            _dbcontext.SaveChanges();
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
            _dbcontext.SaveChanges();
        }
    }
}
