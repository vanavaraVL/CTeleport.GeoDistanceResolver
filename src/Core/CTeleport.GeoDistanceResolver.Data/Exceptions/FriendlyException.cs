using System;

namespace CTeleport.GeoDistanceResolver.Data.Exceptions
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

        public FriendlyException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
