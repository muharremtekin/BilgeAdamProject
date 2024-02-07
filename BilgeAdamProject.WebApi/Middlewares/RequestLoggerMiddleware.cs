using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BilgeAdamProject.WebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var requestUrl = httpContext.Request.GetDisplayUrl();
            var clientIpAddress = httpContext.Connection.RemoteIpAddress;
            var clNmae = httpContext.Request.Headers["User-Agent"];

            Log.Information($"information - DateTime: {DateTime.UtcNow} URL: {requestUrl}, IP ADDRESS: {clientIpAddress}, {clNmae}");
            
            return _next(httpContext);
        }
    }
}
