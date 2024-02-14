using BilgeAdamProject.Entities.DataTransferObjects;

namespace BilgeAdamProject.Services.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task<Guid> AddOneBookAsync(BookDtoForInsertion bookDto);
    Task<BookDto> GetOneBookByIdAsync(Guid id);
}

