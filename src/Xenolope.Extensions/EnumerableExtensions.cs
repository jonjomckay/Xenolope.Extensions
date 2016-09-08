using System.Collections.Generic;
using System.Linq;

namespace Xenolope.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Check if an enumerable contains any one of the given values
        /// </summary>
        /// <param name="value">The enumerable to check against</param>
        /// <param name="values">The values to check the existence of inside the enumerable</param>
        /// <returns>Whether the enumerable contains any one of the given values</returns>
        public static bool ContainsOneOf<T>(this IEnumerable<T> value, params T[] values)
        {
            if (value == null || values == null)
            {
                return false;
            }

            return value.Any(values.Contains);
        }

        /// <summary>
        /// Check if an enumerable is neither null nor empty
        /// </summary>
        /// <param name="value">The enumerable to check</param>
        /// <returns>Whether the enumerable is neither null nor empty</returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return value != null && value.Any();
        }

        /// <summary>
        /// Check if an enumerable is null or empty
        /// </summary>
        /// <param name="value">The enumerable to check</param>
        /// <returns>Whether the enumerable is either null or empty</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return value == null || !value.Any();
        }

        /// <summary>
        /// Check if an enumerable is empty (also checks if the enumerable is null)
        /// </summary>
        /// <param name="value">The enumerable to check</param>
        /// <returns>Whether the enumerable is empty or not</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            return IsNullOrEmpty(value);
        }

        /// <summary>
        /// Check if an enumerable is not empty (also checks if the enumerable is not null)
        /// </summary>
        /// <param name="value">The enumerable to check</param>
        /// <returns>Whether the enumerable is not empty</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> value)
        {
            return IsNotNullOrEmpty(value);
        }
    }
}