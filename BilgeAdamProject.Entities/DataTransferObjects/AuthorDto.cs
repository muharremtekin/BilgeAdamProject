namespace BilgeAdamProject.Entities.DataTransferObjects;

public record AuthorDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

