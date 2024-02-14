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

    public async Task<List<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression, bool noTracking = true) =>
        noTracking
        ? await entity.Where(expression).AsNoTracking().ToListAsync()
        : await entity.Where(expression).ToListAsync();


    public async Task<int> AddAsync(TEntity entity)
    {
        await this.entity.AddAsync(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Guid entityId)
    {
        var entity = await this.entity.FindAsync(entityId);
        return await DeleteAsync(entity);
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        if (_dbContext.Entry(entity).State == EntityState.Detached)
            this.entity.Attach(entity);

        this.entity.Remove(entity);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
    {
        TEntity found = await entity.FindAsync(id);

        if (found is null)
            return null;

        if (noTracking)
            _dbContext.Entry(found).State = EntityState.Detached;

        foreach (Expression<Func<TEntity, object>> include in includes)
            _dbContext.Entry(found).Reference(include).Load();

        return found;
    }
    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = false, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = entity;

        if (predicate != null)
            query = query.Where(predicate);


        query = ApplyIncludes(query, includes);

        if (noTracking)
            query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync();
    }
    private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
    {
        if (includes != null)
        {
            foreach (var includeItem in includes)
                query = query.Include(includeItem);
        }

        return query;
    }
}

