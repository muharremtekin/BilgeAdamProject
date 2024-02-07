using BilgeAdamProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BilgeAdamProject.Repositories.Context;

public class ApplicationDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookOfAuthor> BookOfAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost;Database=BilgeAdamProjectDatabase;Port=5432;User ID=postgres;Password=mysecretpassword123";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

