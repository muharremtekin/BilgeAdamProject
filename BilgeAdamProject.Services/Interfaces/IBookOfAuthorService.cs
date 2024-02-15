using BilgeAdamProject.Entities.DataTransferObjects;
using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.Services.Interfaces;

public interface IBookOfAuthorService
{
    Task AddAsync(Guid authorId, Guid bookId);
    Task<Dictionary<Guid, AuthorDto>> GetAllAsDictionaryAsync();
    Task<Author> GetAuthorByBookIdAsync(Guid bookId);
}

