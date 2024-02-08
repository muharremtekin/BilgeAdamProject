using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public class AuthorRepository : EntityRepository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Author>> GetAllAuthorsWithDetailsAsync() =>
        await entity.AsNoTracking().Include(e => e.Books).AsNoTracking().ToListAsync();
    public async Task<Dictionary<Guid, string>> GetAllAuthorsWithFullNamesAsync() =>
        await entity.AsNoTracking().ToDictionaryAsync(a => a.Id, a => $"{a.FirstName} {a.LastName}");

}

