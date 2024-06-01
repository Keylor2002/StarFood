using Microsoft.EntityFrameworkCore;
using StarFood.Data;
using StarFood.Repository.IRepository;
using System.Linq.Expressions;

namespace StarFood.Repository
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly StarfoodContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(StarfoodContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, Expression<Func<T, bool>>? filter2, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            if (filter2 != null)
            {
                query = query.Where(filter).Where(filter2);
            }
            else
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

    }
}
