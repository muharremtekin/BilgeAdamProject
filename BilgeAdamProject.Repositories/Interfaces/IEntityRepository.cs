using BilgeAdamProject.Entities.Entities;
using System.Linq.Expressions;

namespace BilgeAdamProject.Repositories.Interfaces;

/// <summary>
/// Generic repository
/// </summary>
/// <typeparam name="TEntity">BaseEntity'den kalıtım almak zorundadır.</typeparam>
public interface IEntityRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> FindAllAsync(bool trackChanges);
    Task<List<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
    Task<int> AddAsync(TEntity entity);
    Task<int> DeleteAsync(Guid entityId);
    Task<int> DeleteAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
}
