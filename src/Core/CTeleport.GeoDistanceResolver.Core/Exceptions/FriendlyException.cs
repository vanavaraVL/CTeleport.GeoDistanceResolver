using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Core.Exceptions
{
    /// <summary>
    /// Friendly exception
    /// </summary>
    public class FriendlyException: Exception
    {
        public FriendlyException(string message) : base(message)
        {
        }

        public FriendlyException(Exception ex) : base(ex.Message, ex)
        {
        }
    }
}
