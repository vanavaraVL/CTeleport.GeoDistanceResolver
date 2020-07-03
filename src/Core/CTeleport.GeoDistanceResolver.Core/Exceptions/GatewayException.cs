using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Core.Exceptions
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
