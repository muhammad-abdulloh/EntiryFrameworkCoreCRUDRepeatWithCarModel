using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepeatGenericCrud 
{
    #pragma warning disable
    internal abstract class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        /// <summary>
        /// DbContext to use
        /// </summary>
        /// <param name="CarDbContext"></param>
        protected CarDbContext _dbContext = new CarDbContext();

        /// <summary>
        /// Database DbSet done
        /// </summary>
        /// <param name="T"></param>
        protected DbSet<T> dbSet {get; set;}

        /// <summary>
        /// Constructor used to set the DbSet
        /// </summary>
        /// <param name="constructor"></param>
        public GenericRepository()
        {
            this.dbSet = _dbContext.Set<T>();
        }


        /// <summary>
        /// Create an entity done
        /// </summary>
        /// <param name="entity">Entity to create</param>
        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry entry =  await dbSet.AddAsync(entity);
            _dbContext.SaveChanges();
            return (T)entry.Entity;
        }


        /// <summary>
        /// Delete an Predicate done
        /// </summary>
        /// <param name="predicate">Predicate to find the entity</param>
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity  = await dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null)
            {
                return false;
            }

            dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return true;
            
        }

        /// <summary>
        /// Get All an entity done
        /// </summary>
        /// <param name="predicate">Predicate to find the entity</param>
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            Expression<Func<T, bool>> where = predicate ?? (x => true);
            return dbSet.Where(where);
        }

        /// <summary>
        /// Get an entity done
        /// </summary>
        /// <param name="predicate">Predicate to find the entity</param>
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Update an entity done
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }

}

#pragma warning restore