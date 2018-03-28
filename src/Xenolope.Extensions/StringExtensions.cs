using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Xenolope.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string value, string comparison)
        {
            return value != null && value.IndexOf(comparison, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool EqualsIgnoreCase(this string value, string comparison)
        {
            return value != null && value.Equals(comparison, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Check if a string equals any one of a given array of values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparisons"></param>
        /// <returns></returns>
        public static bool EqualsOneOf(this string value, params string[] comparisons)
        {
            return EqualsOneOf(value, false, comparisons);
        }

        /// <summary>
        /// Check if a string equals any one of a given array of values, ignoring casing
        /// </summary>
        /// <param name="value">The string value to check</param>
        /// <param name="comparisons">The values to check equality with</param>
        /// <returns>Whether the string equals one of the given values</returns>
        public static bool EqualsOneOfIgnoreCase(this string value, params string[] comparisons)
        {
            return EqualsOneOf(value, true, comparisons);
        }

        /// <summary>
        /// Check if a string equals any one of a given array of values, optionally ignoring casing
        /// </summary>
        /// <param name="value">The string value to check</param>
        /// <param name="ignoreCase">Whether to compare with case sensitivity or not</param>
        /// <param name="comparisons">The values to check equality with</param>
        /// <returns>Whether the string equals one of the given values</returns>
        public static bool EqualsOneOf(this string value, bool ignoreCase, params string[] comparisons)
        {
            if (value.IsNullOrWhitespace())
            {
                return false;
            }

            if (comparisons == null || comparisons.Length == 0)
            {
                return false;
            }

            var comparisonType = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            if (comparisons.Any(comparison => comparison.IndexOf(value, comparisonType) > -1))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a string is null, empty or consists only of whitespace characters (different cased name to the built-in method)
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <returns>Whether the string is null, empty or consists only of whitespace characters</returns>
        public static bool IsNullOrWhitespace(this string value)
        {
            // This doesn't use the built-in "string.IsNullOrWhiteSpace" method, as it's not available in .NET 3.5
            if (value == null) return true;

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Parse a string into an instance of an enum
        /// </summary>
        /// <typeparam name="T">The enum type to parse the string into</typeparam>
        /// <param name="value">The string to be parsed</param>
        /// <returns>An enum constant</returns>
        public static T ToEnum<T>(this string value)
        {
            var enumType = typeof(T);
            
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = enumType.GetRuntimeField(name).GetCustomAttribute<EnumMemberAttribute>();
                if (enumMemberAttribute != null && enumMemberAttribute.Value == value)
                {
                    return (T) Enum.Parse(enumType, name);
                }
            }
            
            return (T) Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Parse a string into an instance of an enum, with a default value if the string cannot be parsed
        /// </summary>
        /// <typeparam name="T">The enum type to parse the string into</typeparam>
        /// <param name="value">The string to be parsed</param>
        /// <param name="defaultValue">The default enum constant to use if the given string cannot be parsed</param>
        /// <returns>An enum constant</returns>
        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            // Normally we would use Enum.TryParse here, but it's not available in .NET 3.5
            try
            {
                return value.ToEnum<T>();
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}