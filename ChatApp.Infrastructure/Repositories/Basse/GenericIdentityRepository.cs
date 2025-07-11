using ChatApp.Application.Models;
using ChatApp.Domain.Models.Base;
using ChatApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Project.Application.Contracts.Persistence;
using System.Linq.Expressions;

namespace ChatApp.Infrastructure.Repositories
{
    public class GenericIdentityRepository<T> : IGenericIdentityRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericIdentityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<T> Get(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetNoTracking(string id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(f => (f as UserIdentityBase).IsActive == true && (f as UserIdentityBase).Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().Where(w => (w as UserIdentityBase).IsActive == true).AsNoTracking().OrderByDescending(o => (o as UserIdentityBase).UpdatedAt).ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var find = await Get(id);
            if (find != null)
            {
                (find as UserIdentityBase).IsActive = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Recover(string id)
        {
            var find = await Get(id);
            if (find != null)
            {
                (find as UserIdentityBase).IsActive = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> Exist(string id)
        {
            var entity = await GetNoTracking(id);
            return entity != null;
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .Where(w => (w as UserIdentityBase).IsActive == true)
                .SingleOrDefaultAsync(predicate);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate, FindOptions? findOptions = null)
        {
            return GetByOptions(findOptions)
                .Where(w => (w as UserIdentityBase).IsActive== true)
                .FirstOrDefault(predicate)!;
        }

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate, FindOptions? findOptions = null)
        {
            return GetByOptions(findOptions)
                .Where(w => (w as UserIdentityBase).IsActive == true)
                .Where(predicate);
        }

        public IQueryable<T> GetAll(FindOptions? findOptions = null)
        {
            return GetByOptions(findOptions);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Count(predicate);
        }

        private DbSet<T> GetByOptions(FindOptions? findOptions = null)
        {
            findOptions ??= new FindOptions();
            var entity = _dbContext.Set<T>();
            if (findOptions.IsAsNoTracking && findOptions.IsIgnoreAutoIncludes)
            {
                entity.AsNoTracking();
            }
            else if (findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes();
            }
            else if (findOptions.IsAsNoTracking)
            {
                entity.AsNoTracking();
            }
            return entity;
        }
    }
}
