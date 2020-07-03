using System;

namespace CTeleport.GeoDistanceResolver.Data.Exceptions
{
    /// <summary>
    /// Serialization Exception
    /// </summary>
    public class SerializationException: FriendlyException
    {
        public SerializationException(string message) : base(message)
        {
        }

        public SerializationException(string message, Exception ex) : base(message, ex)
        {
        }

        public SerializationException(Exception ex) : base(ex)
        {
        }
    }
}
