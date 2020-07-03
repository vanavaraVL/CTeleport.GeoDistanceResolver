﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Data.Dto.Responses
{
    /// <summary>
    /// Dto for airport
    /// </summary>
    public class AirportDataDto
    {
        /// <summary>
        /// IATA airport code
        /// </summary>
        public string AirportCode { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }
    }
}
