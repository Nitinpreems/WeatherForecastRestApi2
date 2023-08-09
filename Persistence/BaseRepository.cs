using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return await query.ToListAsync();
        }

        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression, bool loadchildren = false, IList<string>? children = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (loadchildren && children?.Count > 0)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);
                }
            }

            return await query.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
