using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public class AuthorRepository : EntityRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

