using System;

namespace Xenolope.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Check whether a GUID is empty or not
        /// </summary>
        /// <param name="value">The GUID to check</param>
        /// <returns>Whether the GUID is empty or not</returns>
        public static bool IsEmpty(this Guid value)
        {
            return value.Equals(Guid.Empty);
        }

        /// <summary>
        /// Check whether a nullable GUID is either null or empty
        /// </summary>
        /// <param name="value">The nullable GUID to check</param>
        /// <returns>Whether the nullable GUID is null or empty</returns>
        public static bool IsEmpty(this Guid? value)
        {
            return !value.HasValue || value.Value.Equals(Guid.Empty);
        }

        /// <summary>
        /// Check if a GUID is not empty
        /// </summary>
        /// <param name="value">The GUID to check</param>
        /// <returns>Whether the GUID is not empty</returns>
        public static bool IsNotEmpty(this Guid value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// Check if a nullable GUID is not empty
        /// </summary>
        /// <param name="value">The nullable GUID to check</param>
        /// <returns>Whether the nullable GUID is not empty</returns>
        public static bool IsNotEmpty(this Guid? value)
        {
            return !IsEmpty(value);
        }
    }
}