using System.ComponentModel.DataAnnotations;

namespace BilgeAdamProject.Entities.DataTransferObjects;

public record AuthorDtoForInsertion
{
    [Required]
    public string FirstName { get; init; }
    [Required]
    public string LastName { get; init; }
}

