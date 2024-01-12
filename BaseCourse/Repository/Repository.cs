using BaseCourse.Models;
using BaseCourse.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CouponAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CourseContext _dbcontext;
        private DbSet<T> Set;
        public Repository(CourseContext dbcontext)
        {
            _dbcontext = dbcontext;
            this.Set = _dbcontext.Set<T>();
        }

        public void Add(T entity)
        {
            Set.Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Set.Find(id);
            Set.Remove(entity);
            _dbcontext.SaveChanges();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Set.Where(predicate);
            return query;
        }

        public void Update(T entity)
        {
            Set.Update(entity);
            _dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Set.ToList();
        }
    }
}
