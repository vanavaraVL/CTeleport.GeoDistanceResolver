using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CTeleport.GeoDistanceResolver.Application.Configuration.Extensions
{
    /// <summary>
    /// Configure application layer dependency
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configure geo coordinate service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureGeoCoordinateService(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

            services.AddScoped<GeoCoordinateService>();
            
            return services;
        }
    }
}
