using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.Repositories.Interfaces;

public interface IBookRepository : IEntityRepository<Book>
{
    Task<List<BookDto>> GetAllBooksAsBookDtoAsync();
}

