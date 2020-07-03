using CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure;
using GeoCoordinatePortable;

namespace CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Implementation
{
    /// <summary>
    /// Geo distance resolver
    /// Resolves distance between two point <see cref="GeoPoint"/> and returns distance in meters
    /// </summary>
    public class DistanceResolver : IGeoDistanceResolver
    {
        /// <summary>
        /// Resolve distance between two points <see cref="GeoPoint"/> and produces distance in meters
        /// </summary>
        /// <returns></returns>
        public double ResolveDistance(GeoPoint pointOne, GeoPoint pointTwo)
        {
            var aPoint = new GeoCoordinate(pointOne.Latitude, pointOne.Longitude);
            var bPoint = new GeoCoordinate(pointTwo.Latitude, pointTwo.Longitude);

            return aPoint.GetDistanceTo(bPoint);
        }

        /// <summary>
        /// Resolve distance between two points <see cref="GeoPoint"/> and produces distance in unit <see cref="EMeasureUnit"/>
        /// </summary>
        /// <returns></returns>
        public double ResolveDistance(GeoPoint pointOne, GeoPoint pointTwo, EMeasureUnit measureUnit)
        {
            var distance = ResolveDistance(pointOne, pointTwo);

            return measureUnit switch
            {
                EMeasureUnit.Kilometers => distance / 1000,
                EMeasureUnit.Miles => distance * 0.000621371,
                _ => distance,
            };
        }
    }
}
