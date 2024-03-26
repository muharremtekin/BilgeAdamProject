using BilgeAdamProject.Entities.DataTransferObjects;

namespace BilgeAdamProject.Services.Interfaces;

public interface IAuthorService
{
    Task AddOneAuthorAsync(AuthorDtoForInsertion authorDtoForInsertion);
}

