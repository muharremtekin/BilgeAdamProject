namespace BilgeAdamProject.Entities.DataTransferObjects;

/// <summary>
/// record type olmasını istiyordum fakat bu senaryoda class daha mantıklı.
/// </summary>
public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
}

