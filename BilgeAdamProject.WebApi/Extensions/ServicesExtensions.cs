using Serilog;

namespace BilgeAdamProject.WebApi.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureSerilog(this IServiceCollection services)
    {
        // log conf
        services.AddSerilog(opt =>
        {
            opt.WriteTo.Console()
            .WriteTo.File("internal_logs/request_logs.txt", rollingInterval: RollingInterval.Day);
        });
    }
}

