using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;
// TODO: Açıklama yaz.
public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;
    protected DbSet<TEntity> entity => _dbContext.Set<TEntity>();

    public EntityRepository(ApplicationDbContext dbContext) =>
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<List<TEntity>> FindAllAsync(bool noTracking = true) =>
        noTracking
        ? await entity.AsNoTracking().ToListAsync()
        : await entity.ToListAsync();

    public async Task<List<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression, bool noTracking) =>
        noTracking
        ? await entity.Where(expression).ToListAsync()
        : await entity.Where(expression).AsNoTracking().ToListAsync();
}

