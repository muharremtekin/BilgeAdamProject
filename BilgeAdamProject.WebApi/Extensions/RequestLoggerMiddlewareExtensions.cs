using BilgeAdamProject.WebApi.Middlewares;

namespace BilgeAdamProject.WebApi.Extensions
{
    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
