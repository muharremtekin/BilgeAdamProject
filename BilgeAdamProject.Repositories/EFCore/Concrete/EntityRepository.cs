using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly DbContext dbContext;
    protected DbSet<TEntity> entity => dbContext.Set<TEntity>();

    public EntityRepository(DbContext dbContext) =>
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<List<TEntity>> GetAllAsync(bool noTracking = true) =>
        noTracking
        ? await entity.AsNoTracking().ToListAsync()
        : await entity.ToListAsync();
}

