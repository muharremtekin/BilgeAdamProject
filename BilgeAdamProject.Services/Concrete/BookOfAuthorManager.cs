using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using BilgeAdamProject.Services.Interfaces;

namespace BilgeAdamProject.Services.Concrete;

public class BookOfAuthorManager : IBookOfAuthorService
{
    private readonly IBookOfAuthorRepository _bookOfAuthorRepository;

    public BookOfAuthorManager(IBookOfAuthorRepository bookOfAuthorRepository)
    {
        _bookOfAuthorRepository = bookOfAuthorRepository;
    }

    public async Task AddAsync(Guid authorId, Guid bookId)
    {
        var entity = new Entities.Entities.BookOfAuthor { AuthorId = authorId, BookId = bookId };
        await _bookOfAuthorRepository.AddAsync(entity);
    }

    public async Task<Dictionary<Guid, AuthorDto>> GetAllAsDictionaryAsync()
    {
        return await _bookOfAuthorRepository.GetAllAsDictionaryAsync();
    }

    public async Task<Author> GetAuthorByBookIdAsync(Guid bookId)
    {
        var authorOfBook = await _bookOfAuthorRepository.GetAuthorByBookIdAsync(bookId);
        return authorOfBook;
    }
}

