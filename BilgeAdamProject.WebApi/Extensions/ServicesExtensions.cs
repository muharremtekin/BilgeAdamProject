﻿using BilgeAdamProject.Repositories.Context;
using BilgeAdamProject.Repositories.EFCore.Concrete;
using BilgeAdamProject.Repositories.Interfaces;
using BilgeAdamProject.Services.Concrete;
using BilgeAdamProject.Services.Interfaces;
using BilgeAdamProject.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BilgeAdamProject.WebApi.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(cfg =>
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");
            cfg.UseNpgsql(connectionString);
        });

        //var seed = new SeedData();
        //seed.SeedAsync(configuration).GetAwaiter().GetResult();

        return services;
    }
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
    }
    public static void ConfigureSerilog(this IServiceCollection services)
    {
        // log conf
        services.AddSerilog(opt =>
        {
            opt.WriteTo.Console()
            .WriteTo.File("internal_logs/request_logs.txt", rollingInterval: RollingInterval.Day);
        });
    }
    public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<RequestLoggerMiddleware>();

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<IBookOfAuthorService, BookOfAuthorManager>();
        services.AddScoped<IAuthorService, AuthorManager>();
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

