using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Data.Repositories;
public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IComparable
{
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> GetQuery()
    {
        return _dbSet;
    }

    public virtual async Task<TEntity?> FindAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }

    public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<List<TEntity>> GetListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).CountAsync();
    }

    public virtual async Task<bool> AnyAsync()
    {
        return await _dbSet.AnyAsync();
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).AnyAsync();
    }

    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    public virtual void AddRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRangeAsync(entities);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Delete(TKey id)
    {
        TEntity? entity = _dbSet.Find(id);

        if (entity != null)
            _dbSet.Remove(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        if (entity != null)
            _dbSet.Remove(entity);
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}
