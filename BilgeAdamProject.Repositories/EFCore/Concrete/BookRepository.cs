using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public class BookRepository : EntityRepository<Book>, IBookRepository
{
    public BookRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

