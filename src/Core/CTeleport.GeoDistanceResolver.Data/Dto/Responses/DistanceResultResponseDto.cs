using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Data.Dto.Responses
{
    /// <summary>
    /// Dto for result object of finding distance between two airports
    /// </summary>
    public class DistanceResultResponseDto
    {
        /// <summary>
        /// Distance
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// From airport data information <see cref="AirportDataDto"/>
        /// </summary>
        public AirportDataDto FromAirport { get; set; }

        /// <summary>
        /// To airport data information <see cref="AirportDataDto"/>
        /// </summary>
        public AirportDataDto ToAirport { get; set; }
    }
}
