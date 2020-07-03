using System;
using CTeleport.GeoDistanceResolver.Core.Extensions;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Data;
using CTeleport.GeoDistanceResolver.Core.GeoGateway.Infrastructure;
using CTeleport.GeoDistanceResolver.Data.Exceptions;
using Microsoft.Extensions.Options;
using RestSharp;

namespace CTeleport.GeoDistanceResolver.Core.GeoGateway.Implementation
{
    /// <summary>
    /// Gateway service for airports
    /// </summary>
    public class GatewayService: IGatewayService
    {
        private const string _airportPath = "airports";

        private readonly RestClient _restClient;

        public GatewayService(IOptions<GatewaySettings> settings)
        {
            _restClient = new RestClient(settings.Value.EndpointAddress);
        }

        /// <summary>
        /// Get airport data
        /// </summary>
        public AirportData GetAirportData(string airportName)
        {
            var data = SendRequest<AirportData>(_airportPath, airportName);

            return data;

        }

        private TDtoOut SendRequest<TDtoOut>(string path, string airportName) where TDtoOut : class
        {
            var request = new RestRequest($"{path}/{airportName}", Method.GET);

            try
            {
                var response = _restClient.Execute(request);

                var data = response.Deserialize<TDtoOut>();

                return data;
            }
            catch (SerializationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SerializationException($"Type: Unknown. Path name: {path}", ex);
            }
        }
    }
}
