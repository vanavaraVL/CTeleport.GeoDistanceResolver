﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CTeleport.GeoDistanceResolver.Application.Configuration.Extensions;
using CTeleport.GeoDistanceResolver.Core.Configuration.Extensions;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Implementation;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Data;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Implementation;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CTeleport.GeoDistanceResolver.Test.Environments
{
    public class TestEnvironment
    {
        private static TestEnvironment _instance;

        private IServiceProvider _services;

        private TestEnvironment() => ConfigureServices();

        public static TestEnvironment GetInstance() => _instance ??= new TestEnvironment();

        public T Resolve<T>() => _services.GetRequiredService<T>();

        private IConfigurationRoot GetConfigurationRoot() => new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath))
                .AddJsonFile("Appsettings/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        private void ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var configurationRoot = GetConfigurationRoot();

            services.ConfigureGateway(configurationRoot);
            services.ConfigureGeoDistanceResolver();
            services.ConfigureGeoCoordinateService();

            _services = services.BuildServiceProvider();
        }
    }
}
