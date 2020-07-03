using System;
using System.Collections.Generic;
using System.Text;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Implementation;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<GeoCoordinateService>();

            return services;
        }
    }
}
