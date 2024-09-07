using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Interfaces.Persistence;
public interface IRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IComparable
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void AddRangeAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Delete(TKey id);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);
}
