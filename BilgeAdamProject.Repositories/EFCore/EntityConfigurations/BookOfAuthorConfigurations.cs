using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BilgeAdamProject.Repositories.EFCore.EntityConfigurations;

public class BookOfAuthorConfigurations : BaseEntityConfiguration<BookOfAuthor>
{
    public override void Configure(EntityTypeBuilder<BookOfAuthor> builder)
    {
        base.Configure(builder);
        builder.ToTable(nameof(BookOfAuthor), ApplicationDbContext.DEFAULT_SCHEMA);

        builder.HasOne(a => a.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(a => a.AuthorId);

        builder.HasAlternateKey(a => a.BookId);
    }
}

