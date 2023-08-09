
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
        Task<T> FindByCondition(Expression<Func<T, bool>> expression, bool loadchildren = false, IList<string>? children = null);
    }
}
