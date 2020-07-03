using System;
using System.Collections.Generic;
using System.Text;
using CTeleport.GeoDistanceResolver.Core.Exceptions;
using RestSharp;
using RestSharp.Serialization.Json;

namespace CTeleport.GeoDistanceResolver.Core.Extensions
{
    /// <summary>
    /// Extension for REST response <see cref="IRestResponse"/>
    /// </summary>
    public static class RestResponseExtension
    {
        /// <summary>
        /// Deserialize response
        /// </summary>
        public static T Deserialize<T>(this IRestResponse response)
        {
            if (response == null)
            {
                throw new SerializationException("No answer from gateway");
            }

            try
            {
                var serializer = new JsonSerializer();

                return serializer.Deserialize<T>(response);
            }
            catch (Exception e)
            {
                throw new SerializationException($"Error on deserialization json content {response.Content}: {e.Message}");
            }
        }
    }
}
