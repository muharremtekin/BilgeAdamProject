namespace BilgeAdamProject.Entities.Entities;

public class Author : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<BookOfAuthor> Books { get; set; }
}

