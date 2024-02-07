using BilgeAdamProject.Repositories.Context;
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
            cfg.UseNpgsql(connectionString);
        });

        //var seeder = new SeedData();
        //seeder.SeedAsync(configuration).GetAwaiter().GetResult();


        return services;
    }
}

