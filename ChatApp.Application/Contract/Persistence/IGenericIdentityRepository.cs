using ChatApp.Application.Models;

namespace Project.Application.Contracts.Persistence
{
    public interface IGenericIdentityRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(string id);

        Task Recover(string id);

        Task<bool> Exist(string id);

        System.Linq.IQueryable<T> GetAllQueryable();

        Task<T> GetNoTracking(string id);

        Task<T> SingleOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        T FindFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate, FindOptions? findOptions = null);

        IQueryable<T> FindWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate, FindOptions? findOptions = null);

        IQueryable<T> GetAll(FindOptions? findOptions = null);

        int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}
