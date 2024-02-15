using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdamProject.Repositories.EFCore.Concrete;

public sealed class BookOfAuthorRepository : EntityRepository<BookOfAuthor>, IBookOfAuthorRepository
{
    public BookOfAuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Dictionary<Guid, AuthorDto>> GetAllAsDictionaryAsync() =>
        await entity
            .AsNoTracking()
            .Include(b => b.Author)
            .ToDictionaryAsync(b => b.BookId, b => new AuthorDto { Id = b.AuthorId, FirstName = b.Author.FirstName, LastName = b.Author.LastName });

    public async Task<Author> GetAuthorByBookIdAsync(Guid bookId)
    {
        var bookOfAuthor = await GetSingleAsync(b => b.BookId == bookId, false, b => b.Author);
        return bookOfAuthor.Author;
    }
}

