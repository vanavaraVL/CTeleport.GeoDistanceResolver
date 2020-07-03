using System;
using System.Collections.Generic;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Data.Exceptions
{
    /// <summary>
    /// Validation Exceptions
    /// </summary>
    public class ValidationException: FriendlyException
    {
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(Exception ex) : base(ex)
        {
        }
    }
}
