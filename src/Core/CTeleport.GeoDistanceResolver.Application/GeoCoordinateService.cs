using System;
using System.Linq;
using CTeleport.GeoDistanceResolver.Application.Converters;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using CTeleport.GeoDistanceResolver.Data.Dto;
using CTeleport.GeoDistanceResolver.Data.Dto.Responses;
using CTeleport.GeoDistanceResolver.Data.Exceptions;

namespace CTeleport.GeoDistanceResolver.Application
{
    /// <summary>
    /// Service for work with geo coordinate
    /// </summary>
    public class GeoCoordinateService
    {
        private readonly IGatewayService _gatewayService;
        private readonly IGeoDistanceResolver _getGeoDistanceResolver;

        public GeoCoordinateService(IGatewayService gatewayService, IGeoDistanceResolver distanceResolver)
        {
            _gatewayService = gatewayService;
            _getGeoDistanceResolver = distanceResolver;
        }

        /// <summary>
        /// Find distance between two airports
        /// </summary>
        /// <param name="airportFrom">IATA code airport from</param>
        /// <param name="airportTo">IATA code airport to</param>
        /// <returns></returns>
        public DistanceResultResponseDto FindDistanceBetweenAirports(
            string airportFrom,
            string airportTo,
            EMeasureUnitDto measureUnit = EMeasureUnitDto.Meters)
        {
            CheckAirportCode(airportFrom, airportTo);

            airportTo = airportTo.ToUpperInvariant();
            airportFrom = airportFrom.ToUpperInvariant();

            var airportDataFrom = _gatewayService.GetAirportData(airportFrom);
            var airportDataTo = _gatewayService.GetAirportData(airportTo);

            var fromGeoPoint = airportDataFrom.ConvertToGeoPoint();
            var toGeoPoint = airportDataTo.ConvertToGeoPoint();

            var distance = _getGeoDistanceResolver.ResolveDistance(
                fromGeoPoint,
                toGeoPoint,
                (EMeasureUnit)Enum.Parse(typeof(EMeasureUnit), measureUnit.ToString()));

            return new DistanceResultResponseDto()
            {
                Distance = distance,
                FromAirport = airportDataFrom.ConvertToDto(),
                ToAirport = airportDataTo.ConvertToDto()
            };
        }

        private void CheckAirportCode(params string[] airportCodes)
        {
            foreach (var airportCode in airportCodes)
            {
                if (string.IsNullOrEmpty(airportCode))
                    throw new ValidationException($"Aiport code is null");

                if (airportCode.Length > 4)
                    throw new ValidationException($"IATA code airport must be 3 lenght: {airportCode}");

                if (airportCode.All(char.IsDigit))
                    throw new ValidationException($"IATA code airport must contains only chars: {airportCode}");
            }
        }
    }
}
