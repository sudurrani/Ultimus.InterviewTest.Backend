using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Ultimus.Application.Contracts.Persistence;

namespace Ultimus.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        
        protected readonly AdventureWorksDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(AdventureWorksDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var result = await query.ToListAsync();
            return result!;
            //return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(long id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            return result!;
        }
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var result = await query.Where(predicate).FirstOrDefaultAsync();
            return result!;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }
        
    }
}
