using BilgeAdamProject.Entities.DataTransferObjects;

namespace BilgeAdamProject.Services.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
}

