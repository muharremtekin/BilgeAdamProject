using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BilgeAdamProject.Repositories.EFCore.EntityConfigurations;

public class BookConfigurations : BaseEntityConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);
        builder.ToTable(nameof(Book), ApplicationDbContext.DEFAULT_SCHEMA);
    }
}

