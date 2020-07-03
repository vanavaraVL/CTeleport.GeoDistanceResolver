using System;
using System.Linq;
using CTeleport.GeoDistanceResolver.Application.Converters;
using CTeleport.GeoDistanceResolver.Application.Extensions;
using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using CTeleport.GeoDistanceResolver.Data.Dto;
using CTeleport.GeoDistanceResolver.Data.Dto.Responses;
using CTeleport.GeoDistanceResolver.Data.Exceptions;
using Microsoft.Extensions.Caching.Memory;

namespace CTeleport.GeoDistanceResolver.Application
{
    /// <summary>
    /// Service for work with geo coordinate
    /// </summary>
    public class GeoCoordinateService
    {
        private readonly IGatewayService _gatewayService;
        private readonly IGeoDistanceResolver _getGeoDistanceResolver;
        private readonly IMemoryCache _memoryCache;

        public GeoCoordinateService(
            IGatewayService gatewayService,
            IGeoDistanceResolver distanceResolver,
            IMemoryCache memoryCache)
        {
            _gatewayService = gatewayService;
            _getGeoDistanceResolver = distanceResolver;
            _memoryCache = memoryCache;
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

            if (TryGetFromCache(airportFrom, airportTo, measureUnit, out var cacheResult))
            {
                return cacheResult;
            }

            var airportDataFrom = _gatewayService.GetAirportData(airportFrom);
            var airportDataTo = _gatewayService.GetAirportData(airportTo);

            var fromGeoPoint = airportDataFrom.ConvertToGeoPoint();
            var toGeoPoint = airportDataTo.ConvertToGeoPoint();

            var distance = _getGeoDistanceResolver.ResolveDistance(
                fromGeoPoint,
                toGeoPoint,
                (EMeasureUnit)Enum.Parse(typeof(EMeasureUnit), measureUnit.ToString()));

            var result =  new DistanceResultResponseDto()
            {
                Distance = distance,
                FromAirport = airportDataFrom.ConvertToDto(),
                ToAirport = airportDataTo.ConvertToDto()
            };

            SaveToCache(airportFrom, airportTo, measureUnit, result);

            return result;
        }

        private bool TryGetFromCache(string airportFrom, string airportTo, EMeasureUnitDto measureUnit, out DistanceResultResponseDto resultCache)
        {
            var key = GetKey(airportFrom, airportTo, measureUnit);

            if (_memoryCache.TryGetValue(key, out var result))
            {
                resultCache = (DistanceResultResponseDto)result;
                
                return true;
            }

            resultCache = null;

            return false;
        }

        private void SaveToCache(string airportFrom, string airportTo, EMeasureUnitDto measureUnit, DistanceResultResponseDto result)
        {

            _memoryCache.Set(
                GetKey(airportFrom, airportTo, measureUnit),
                result,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        private string GetKey(string airportFrom, string airportTo, EMeasureUnitDto measureUnit) => $"{airportFrom}{airportTo}{measureUnit}".GetSha256();


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
