using AutoMapper;
using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Interfaces;
using BilgeAdamProject.Services.Interfaces;

namespace BilgeAdamProject.Services.Concrete;

public sealed class BookManager : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookOfAuthorService _bookOfAuthorManager;
    private readonly IMapper _mapper;

    public BookManager(IBookRepository bookRepository, IBookOfAuthorService bookOfAuthorManager, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _bookOfAuthorManager = bookOfAuthorManager;
        _mapper = mapper;
    }
    /// <summary>
    ///  Toplam zaman karmaşıklığı: O(n) + O(m) + O(m) ≈ O(n + 2m) ≈ O(n + m), 
    ///  burada n ve m sırasıyla BookOfAuthor ve Book veri sayılarıdır.
    /// </summary>
    /// <returns></returns>
    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var kvp = await _bookOfAuthorManager.GetAllAsDictionaryAsync();

        var bookDtos = await _bookRepository.GetAllBooksAsBookDtoAsync();

        foreach (BookDto dto in bookDtos)
        {

            var authorDto = kvp[dto.Id];

            dto.AuthorFirstName = authorDto.FirstName;
            dto.AuthorLastName = authorDto.LastName;
        }

        return bookDtos;
    }

    public async Task<Guid> AddOneBookAsync(BookDtoForInsertion bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        await _bookRepository.AddAsync(book);

        var addedBook = await _bookRepository.GetSingleAsync(b => b.Title == book.Title
                                                            && b.Description == book.Description
                                                            && b.PublicationDate == book.PublicationDate);

        await _bookOfAuthorManager.AddAsync(bookDto.AuthorId, addedBook.Id);

        return addedBook.Id;
    }
    public async Task<BookDto> GetOneBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        //var book = await _bookRepository.GetSingleAsync(b => b.Id == id);
        var authorOfBook = await _bookOfAuthorManager.GetAuthorByBookIdAsync(book.Id);
        var bookDto = _mapper.Map<BookDto>(book);

        bookDto.AuthorFirstName = authorOfBook.FirstName;
        bookDto.AuthorLastName = authorOfBook.LastName;

        return bookDto;
    }
}

