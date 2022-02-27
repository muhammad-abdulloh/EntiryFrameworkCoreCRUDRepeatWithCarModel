using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepeatGenericCrud
{
    internal interface IGenericRepository<T> where T : class
    {
        
        /// <summary>
        /// Get done
        /// </summary>
        /// <param name="predicate"></param>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get all done
        /// </summary>
        /// <param name="predicate"></param>
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Create an entity
        /// </summary>
        /// <param name="entity">Entity to create</param>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="predicate">Predicate to find the entity</param>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate);

    }
}