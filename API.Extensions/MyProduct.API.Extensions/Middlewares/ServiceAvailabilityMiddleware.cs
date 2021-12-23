using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyProduct.API.Extensions.Middlewares
{
    /// <summary>
    /// Middleware for checking the service availability.
    /// </summary>
    internal sealed class ServiceAvailabilityMiddleware
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public ServiceAvailabilityMiddleware(RequestDelegate _)
        {

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            await httpContext.Response.WriteAsync($"Service {Utility.GetCurrentServiceName()} is available.");

        }



    }
}
