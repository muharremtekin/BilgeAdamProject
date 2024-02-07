using BilgeAdamProject.Entities.Entities;
using BilgeAdamProject.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BilgeAdamProject.Repositories.EFCore.EntityConfigurations;

public class AuthorConfigurations : BaseEntityConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);
        builder.ToTable(nameof(Author), ApplicationDbContext.DEFAULT_SCHEMA);


    }
}

