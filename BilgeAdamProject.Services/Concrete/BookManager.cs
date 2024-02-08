using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Repositories.Interfaces;
using BilgeAdamProject.Services.Interfaces;

namespace BilgeAdamProject.Services.Concrete;

public sealed class BookManager : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookOfAuthorRepository _bookOfAuthorRepository;


    public BookManager(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookOfAuthorRepository bookOfAuthorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _bookOfAuthorRepository = bookOfAuthorRepository;
    }
    /// <summary>
    ///  Toplam zaman karmaşıklığı: O(n) + O(m) + O(m) ≈ O(n + 2m) ≈ O(n + m), 
    ///  burada n ve m sırasıyla BookOfAuthor ve Book veri sayılarıdır.
    /// </summary>
    /// <returns></returns>
    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var kvp = await _bookOfAuthorRepository.GetAllAsync();

        var bookDtos = await _bookRepository.GetAllBooksAsBookDtoAsync();

        foreach (BookDto dto in bookDtos)
        {
            var b = kvp[dto.Id];

            dto.AuthorFirstName = b.FirstName;
            dto.AuthorLastName = b.LastName;
        }

        return bookDtos;
    }
}

