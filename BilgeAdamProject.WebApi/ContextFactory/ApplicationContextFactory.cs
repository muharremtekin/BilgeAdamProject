using BilgeAdamProject.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BilgeAdamProject.WebApi.ContextFactory;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // configration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // DbCotextBuilder
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(configuration
            .GetConnectionString("sqlConnection"), prj => prj.MigrationsAssembly("BilgeAdamProject.WebApi"));

        return new ApplicationDbContext(builder.Options);
    }
}

