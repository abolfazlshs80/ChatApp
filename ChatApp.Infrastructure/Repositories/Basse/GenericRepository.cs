using ChatApp.Application.Models;
using ChatApp.Domain.Models.Base;
using ChatApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Project.Application.Contracts.Persistence;
using System.Linq.Expressions;

namespace ChatApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetNoTracking(int id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(f => (f as BaseEntity).IsDelete == true && (f as BaseEntity).Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>()
            .Where(w => (w as BaseEntity).IsDelete == true)
                .AsNoTracking().OrderByDescending(o => (o as BaseEntity).UpdatedAt).ToListAsync();
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

        public async Task Remove(int id)
        {
            var find = await Get(id);
            if (find != null)
            {
                _dbContext.Remove(find);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var find = await Get(id);
            if (find != null)
            {
                (find as BaseEntity).IsDelete = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Recover(int id)
        {
            var find = await Get(id);
            if (find != null)
            {
                (find as BaseEntity).IsDelete = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Active(int id)
        {
            var find = await Get(id);
            if (find != null)
            {
                (find as BaseEntity).IsActive = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UnActive(int id)
        {
            var find = await Get(id);
            if (find != null)
            {
                (find as BaseEntity).IsActive = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetNoTracking(id);
            return entity != null;
        }
        
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .Where(w => (w as BaseEntity).IsActive == true)
                .Where(w => (w as BaseEntity).IsDelete == true)
                .SingleOrDefaultAsync(predicate);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> predicate, FindOptions? findOptions = null)
        {
            return GetByOptions(findOptions)
                .Where(w => (w as BaseEntity).IsDelete == true)
                .FirstOrDefault(predicate)!;
        }
       
        public IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate, FindOptions? findOptions = null)
        {
            return GetByOptions(findOptions)
                .Where(w => (w as BaseEntity).IsDelete == true)
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
