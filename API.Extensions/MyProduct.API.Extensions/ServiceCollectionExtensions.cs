using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProduct.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            return services;

        }
    }
}
