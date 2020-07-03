using System;

namespace CTeleport.GeoDistanceResolver.Data.Exceptions
{
    /// <summary>
    /// Gateway exception
    /// </summary>
    public class GatewayException: FriendlyException
    {
        public GatewayException(string message) : base(message)
        {
        }

        public GatewayException(Exception ex) : base(ex)
        {
        }
    }
}
