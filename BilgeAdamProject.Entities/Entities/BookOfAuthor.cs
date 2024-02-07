namespace BilgeAdamProject.Entities.Entities;

public class BookOfAuthor : BaseEntity
{
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }
}

