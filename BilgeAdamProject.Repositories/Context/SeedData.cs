using BilgeAdamProject.Entities.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BilgeAdamProject.Repositories.Context;

internal sealed class SeedData
{
    static List<Author> GetAuthors()
    {
        var res = new Faker<Author>()
            .RuleFor(a => a.Id, f => Guid.NewGuid())
            .RuleFor(a => a.FirstName, f => f.Person.FirstName)
            .RuleFor(a => a.LastName, f => f.Person.LastName)
           .Generate(2500);

        return res;
    }
    /// <summary>
    /// 14 GB Ram yedi :D
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseNpgsql(configuration.GetConnectionString("sqlConnection"));
        var context = new ApplicationDbContext(dbContextBuilder.Options);
        //

        //var items = await context.BookOfAuthors
        //    .AsNoTracking()
        //    .Include(b => b.Author)
        //    .ToDictionaryAsync(b => b.BookId, b => new AuthorDto { Id = b.AuthorId, FirstName = b.Author.FirstName, LastName = b.Author.LastName });

        //
        var authors = GetAuthors();

        await context.Authors.AddRangeAsync(authors);

        var books = new Faker<Book>()
            .RuleFor(b => b.Id, f => Guid.NewGuid())
            .RuleFor(b => b.Title, f => f.Random.Words(f.Random.Number(1, 7)))
            .RuleFor(b => b.Description, f => f.Lorem.Paragraph(100))
            .RuleFor(b => b.PublicationDate, f => f.Date.Between(DateTime.UtcNow.AddYears(-90), DateTime.UtcNow))
           .Generate(250000);

        await context.Books.AddRangeAsync(books);

        var authorIds = authors.Select(a => a.Id).ToList();
        var bookIds = books.Select(b => b.Id).ToList();

        List<BookOfAuthor> bookOfAuthors = new();

        int bookCounter = 0;

        for (int i = 0; i < authorIds.Count; i++)
        {
            var temp = new Faker<BookOfAuthor>()
                .RuleFor(bof => bof.Id, f => Guid.NewGuid())
                .RuleFor(bof => bof.AuthorId, f => authorIds[i])
                .RuleFor(bof => bof.BookId, f => bookIds[bookCounter++])
                .Generate(100);

            bookOfAuthors.AddRange(temp);
        }

        await context.BookOfAuthors.AddRangeAsync(bookOfAuthors);

        await context.SaveChangesAsync();
    }
}
