using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.Repositories.Interfaces;

/// <summary>
/// Generic repository
/// </summary>
/// <typeparam name="TEntity">BaseEntity'den kalıtım almak zorundadır.</typeparam>
public interface IEntityRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync(bool noTracking);
}

