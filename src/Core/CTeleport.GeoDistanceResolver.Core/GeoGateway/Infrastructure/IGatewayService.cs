using System;
using System.Collections.Generic;
using System.Text;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Data;

namespace CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure
{
    /// <summary>
    /// Contract service for gateway to get data about airports
    /// </summary>
    public interface IGatewayService
    {
        /// <summary>
        /// Get airports from gateway
        /// </summary>
        /// <returns><see cref="AirportData"/></returns>
        AirportData GetAirportData(string airportName);
    }
}
