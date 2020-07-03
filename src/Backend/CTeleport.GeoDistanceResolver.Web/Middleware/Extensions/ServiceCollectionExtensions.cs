using Microsoft.AspNetCore.Builder;

namespace CTeleport.GeoDistanceResolver.Web.Middleware.Extensions
{
    /// <summary>
    /// Extensions for service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Use application error handler
        /// </summary>
        public static IApplicationBuilder UseApplicationExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApplicationExceptionHandler>();
        }
    }
}
