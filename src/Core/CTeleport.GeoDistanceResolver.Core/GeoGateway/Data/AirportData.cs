using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Core.GeoGateway.Data
{
    /// <summary>
    /// Airport data
    /// </summary>
    public class AirportData
    {
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// IATA city name
        /// </summary>
        public string CityIata { get; set; }

        /// <summary>
        /// IATA code
        /// </summary>
        public string Iata { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Timezone
        /// </summary>
        public string TimezoneRegionName { get; set; }

        /// <summary>
        /// Country IATA name
        /// </summary>
        public string CountryIata { get; set; }

        /// <summary>
        /// Rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Airport name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public LocationData Location { get; set; }

        /// <summary>
        /// Type. Allway airport
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Hubs number
        /// </summary>
        public int Hubs { get; set; }
    }
}
