using System.ComponentModel.DataAnnotations;

namespace BilgeAdamProject.Entities.DataTransferObjects;

public record BookDtoForInsertion
{
    [Required]
    [MinLength(2, ErrorMessage = "Title must consist of at least 2 characters.")]
    public string Title { get; init; }
    public string Description { get; init; }
    [Required]
    public DateTime PublicationDate { get; init; }
    [Required]
    public Guid AuthorId { get; set; }

}
