using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyProduct.API.Extensions.Middlewares
{
    internal sealed class ServiceAvailabilityMiddleware
    {
        private readonly RequestDelegate _next;
        public ServiceAvailabilityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            await httpContext.Response.WriteAsync($"Service {Utility.GetCurrentServiceName()} is available.");

        }



    }
}
