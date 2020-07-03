using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Data;
using CTeleport.GeoDistanceResolver.Data.Dto.Responses;

namespace CTeleport.GeoDistanceResolver.Application.Converters
{
    /// <summary>
    /// Airport data <see cref="AirportData"/> converters
    /// </summary>
    public static class AirportDataMappers
    {
        /// <summary>
        /// Convert to GeoPoint <see cref="GeoPoint"/>
        /// </summary>
        /// <returns></returns>
        public static GeoPoint ConvertToGeoPoint(this AirportData airportData)
        {
            return new GeoPoint(airportData.Location.Lon, airportData.Location.Lat);
        }

        /// <summary>
        /// Convert to dto <see cref="AirportDataDto"/>
        /// </summary>
        /// <param name="airportData"></param>
        /// <returns></returns>
        public static AirportDataDto ConvertToDto(this AirportData airportData)
        {
            return new AirportDataDto()
            {
                Longitude = airportData.Location.Lon,
                Latitude = airportData.Location.Lat,
                AirportCode = airportData.Iata
            };
        }
    }
}
