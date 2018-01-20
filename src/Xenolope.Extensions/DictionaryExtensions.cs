using System;
using System.Collections.Generic;

namespace Xenolope.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue)
        {
            if (dictionary == null)
            {
                return defaultValue;
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> defaultValueProvider)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            if (dictionary == null)
            {
                return defaultValueProvider(key);
            }

            return dictionary.TryGetValue(key, out var value) ? value : defaultValueProvider(key);
        }
    }
}