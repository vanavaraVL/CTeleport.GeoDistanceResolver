using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Core.GeoGateway.Data
{
    /// <summary>
    /// Settings for gateway
    /// </summary>
    public class GatewaySettings
    {
        public static string SectionName = "GatewayConnectionSettings";

        /// <summary>
        /// Address to connect
        /// </summary>
        public string EndpointAddress { get; set; }
    }
}
