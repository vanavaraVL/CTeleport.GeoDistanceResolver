namespace CTeleport.GeoDistanceResolver.Core.GeoDistanceResolvers.Infrastructure
{
    /// <summary>
    /// Contract resolver for latitude and longitude distance
    /// Takes and work with <see cref="GeoPoint"/> points
    /// Produces distance in meters
    /// </summary>
    public interface IGeoDistanceResolver
    {
        /// <summary>
        /// Resolve distance betwen two geo points
        /// </summary>
        /// <returns>Distance</returns>
        double ResolveDistance(GeoPoint pointOne, GeoPoint pointTwo);

        /// <summary>
        /// Resolve distance betwen two geo points for specific measure <see cref="EMeasureUnit"/>
        /// </summary>
        /// <returns>Distance in measure unit</returns>
        double ResolveDistance(GeoPoint pointOne, GeoPoint pointTwo, EMeasureUnit measureUnit);
    }
}
