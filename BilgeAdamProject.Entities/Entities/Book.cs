namespace BilgeAdamProject.Entities.Entities;

/// <summary>
/// BaseEntity'den gelen id, ISBN yerine geçiyor.
/// </summary>
public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublicationDate { get; set; }
}
