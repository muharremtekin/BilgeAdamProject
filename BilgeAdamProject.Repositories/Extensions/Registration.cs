using BilgeAdamProject.Repositories.Context;
using BilgeAdamProject.Repositories.EFCore.Concrete;
using BilgeAdamProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BilgeAdamProject.Repositories.Extensions;

public static class Registration
{
    public static IServiceCollection ConfigureApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(cfg =>
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");
            Console.WriteLine(connectionString);
            cfg.UseNpgsql(connectionString);
        });

        //var seeder = new SeedData();
        //seeder.SeedAsync(configuration).GetAwaiter().GetResult();



        return services;
    }
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookOfAuthorRepository, BookOfAuthorRepository>();

        return services;
    }
}

