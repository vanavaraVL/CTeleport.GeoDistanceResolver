using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CTeleport.GeoDistanceResolver.Application.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get SHA256 from string
        /// </summary>
        public static string GetSha256(this string value)
        {
            var crypt = new SHA256Managed();
            var hash = string.Empty;

            var crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(value));

            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x2"));
        }
    }
}
