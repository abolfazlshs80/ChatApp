using ChatApp.Application.Models;
using System.Linq.Expressions;

namespace Project.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(int id);

        Task Recover(int id);

        Task<bool> Exist(int id);

        System.Linq.IQueryable<T> GetAllQueryable();

        Task<T> GetNoTracking(int id);

        Task Remove(int id);

        Task Save();

        Task Active(int id);

        Task UnActive(int id);

        T FindFirstOrDefault(Expression<Func<T, bool>> predicate, FindOptions? findOptions = null);

        IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate, FindOptions? findOptions = null);

        IQueryable<T> GetAll(FindOptions? findOptions = null);

        int Count(Expression<Func<T, bool>> predicate);
    }
}
