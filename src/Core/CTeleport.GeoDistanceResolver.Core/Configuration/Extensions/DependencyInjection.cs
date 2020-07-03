using System;
using System.Collections.Generic;
using System.Text;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Implementation;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Data;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Implementation;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.GeoDistanceResolver.Core.Configuration.Extensions
{
    /// <summary>
    /// Configure dependency for core services <see cref="IGatewayService"></see> and <see cref="IGeoDistanceResolver"/>/>
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configure gateway service
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection ConfigureGateway(
            this IServiceCollection services,
            IConfiguration configurationRoot)
        {
            services.Configure<GatewaySettings>(
                options => configurationRoot.GetSection(GatewaySettings.SectionName).Bind(options));

            services.AddScoped<IGatewayService, GatewayService>();

            return services;
        }

        /// <summary>
        /// Configure distance resolver
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection ConfigureGeoDistanceResolver(this IServiceCollection services)
        {
            services.AddScoped<IGeoDistanceResolver, DistanceResolver>();

            return services;
        }
    }
}
