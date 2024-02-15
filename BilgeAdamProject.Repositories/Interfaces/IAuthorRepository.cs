using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.Repositories.Interfaces;

public interface IAuthorRepository : IEntityRepository<Author>
{
    Task<List<Author>> GetAllAuthorsWithDetailsAsync();
    Task<Dictionary<Guid, string>> GetAllAuthorsWithFullNamesAsync();
}

