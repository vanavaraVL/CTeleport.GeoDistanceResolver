using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using CTeleport.GeoDistanceResolver.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CTeleport.GeoDistanceResolver.Test.Environments
{
    public sealed class IntegrationEnvironment : IDisposable
    {
        public HttpClient Client { get; private set; }
        private bool _disposing;

        public void Initialize()
        {
            var hostBuilder = Web.Program.CreateHostBuilder(Array.Empty<string>());

            var host = hostBuilder
                .ConfigureWebHostDefaults(webHost => webHost.UseStartup<Startup>());

            host.ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
            });

            var hostClient = host.Start();

            Client = hostClient.GetTestClient();
        }

        public void Dispose()
        {
            if (_disposing)
                return;

            _disposing = true;

            Client.Dispose();
        }
    }
}
