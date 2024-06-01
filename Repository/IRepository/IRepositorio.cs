using System.Linq.Expressions;

namespace StarFood.Repository.IRepository
{
        
        public interface IRepositorio<T> where T : class
        {
            IEnumerable<T> GetAll(string? includeProperties = null);

            T GetFirstOrDefault(Expression<Func<T, bool>> filter, Expression<Func<T, bool>>? filter2, string? includeProperties = null);

            void Add(T entity);

            void Remove(T entity);

            void RemoveRange(IEnumerable<T> entities);

        }
    }
