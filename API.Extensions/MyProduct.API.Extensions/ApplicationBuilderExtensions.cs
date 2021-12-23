using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProduct.API.Extensions.Middlewares;

namespace MyProduct.API.Extensions
{
    /// <summary>
    /// Extension methods for Application builder.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Extension method to register default middlewares for the product.
        /// It will help to ensure that all the required middlewares are configured without missing any.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDefaultMiddlewares(this IApplicationBuilder applicationBuilder)
        {
            ShowExceptionOnPage(applicationBuilder);
            UsePathBase(applicationBuilder);

            var environment = applicationBuilder.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (!environment.IsDevelopment())
            {
                // UseHsts adds a header Strict-Transport-Security to the response. 
                // When the site was accessed using HTTPS then the browser notes it down and future request using HTTP will be redirected to HTTPS. 
                // So, accessing the site using HTTPS at least once is mandatory to make this work.

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                applicationBuilder.UseHsts();
            }

            applicationBuilder.Map($"/{Utility.GetCurrentServiceName()}/isavailable",
                app => app.UseMiddleware<ServiceAvailabilityMiddleware>());

            applicationBuilder.UseRouting();
            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return applicationBuilder;
        }

        #region Private Methods

        /// <summary>
        /// Uses the settings from configuration <see cref="IConfiguration"/> to show or hide the exceptions on page.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        private static void ShowExceptionOnPage(IApplicationBuilder applicationBuilder)
        {
            var configuration = applicationBuilder.ApplicationServices.GetRequiredService<IConfiguration>();
            var showExceptionOnPage = configuration.GetValue<bool>("ShowExceptionOnPage");
            if (showExceptionOnPage)
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
        }


        /// <summary>
        /// Uses the path base from configuration <see cref="IConfiguration"/>.
        /// </summary>
        /// <param name="applicationBuilder">The application builder.</param>
        /// <returns></returns>
        private static void UsePathBase(IApplicationBuilder applicationBuilder)
        {
            var configuration = applicationBuilder.ApplicationServices.GetRequiredService<IConfiguration>();
            var basePath = configuration.GetValue<string>("BasePath");
            if (string.IsNullOrEmpty(basePath))
            {
                return;
            }
            applicationBuilder.UsePathBase(basePath);
        }

        #endregion
    }
}
