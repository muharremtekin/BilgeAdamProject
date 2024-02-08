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
}

