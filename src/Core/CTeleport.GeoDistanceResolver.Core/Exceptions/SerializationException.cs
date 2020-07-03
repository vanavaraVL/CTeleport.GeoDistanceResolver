using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Core.Exceptions
{
    /// <summary>
    /// Serialization Exception
    /// </summary>
    public class SerializationException: FriendlyException
    {
        public SerializationException(string message) : base(message)
        {
        }

        public SerializationException(Exception ex) : base(ex)
        {
        }
    }
}
