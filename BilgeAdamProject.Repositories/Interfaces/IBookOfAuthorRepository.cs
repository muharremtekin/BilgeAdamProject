using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.Repositories.Interfaces;

public interface IBookOfAuthorRepository : IEntityRepository<BookOfAuthor>
{
    Task<Dictionary<Guid, AuthorDto>> GetAllAsync();
}

