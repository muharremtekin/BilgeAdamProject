using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public class BookOfAuthorRepository : EntityRepository<BookOfAuthor>, IBookOfAuthorRepository
{
    public BookOfAuthorRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

