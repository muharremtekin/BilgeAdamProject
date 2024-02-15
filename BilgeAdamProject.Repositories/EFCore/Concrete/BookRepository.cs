using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public sealed class BookRepository : EntityRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<BookDto>> GetAllBooksAsBookDtoAsync() =>
        await entity
        .Select(b => new BookDto { Id = b.Id, Title = b.Title, PublicationDate = b.PublicationDate })
        .AsNoTracking()
        .ToListAsync();
}

