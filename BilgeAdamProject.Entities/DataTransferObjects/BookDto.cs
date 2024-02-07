using BilgeAdamProject.Entities.Entities;

namespace BilgeAdamProject.Entities.DataTransferObjects;

public record BookDto
{
    public Guid Id { get; init; }
    public string ISSBN { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime PublicationDate { get; init; }

    public Author Author { get; init; }
}

