namespace CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure
{
    /// <summary>
    /// Geo point
    /// Describes coordinate point in longitude and latitude
    /// </summary>
    public class GeoPoint
    {

        /// <summary>
        /// ctr
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public GeoPoint(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; }
    }
}
