using System;
using System.Collections.Generic;
using Xunit;

namespace Xenolope.Extensions.Tests
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void TestGetValueOrDefaultWithNullDictionary()
        {
            Dictionary<string, string> dictionary = null;

            Assert.Equal("default value", dictionary.GetValueOrDefault("key", "default value"));
        }

        [Fact]
        public void TestGetValueOrDefaultWithEmptyDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            Assert.Equal("default value", dictionary.GetValueOrDefault("key", "default value"));
        }

        [Fact]
        public void TestGetValueOrDefaultWithValidDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "key", "value" }
            };

            Assert.Equal("value", dictionary.GetValueOrDefault("key", "default value"));
        }
        
        [Fact]
        public void TestGetValueOrDefaultWithValidDictionaryAndNoDefault()
        {
            var dictionary = new Dictionary<string, string>();

            Assert.Null(dictionary.GetValueOrDefault("key"));
        }

        [Fact]
        public void TestGetValueOrDefaultWithInvalidKey()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "key", "value" }
            };

            Assert.Throws<ArgumentNullException>("key", () => dictionary.GetValueOrDefault(null, "default value"));
        }

        [Fact]
        public void TestGetValueOrDefaultWithProviderWithNullDictionary()
        {
            Dictionary<string, string> dictionary = null;

            Assert.Equal("default value from key",
                dictionary.GetValueOrDefault("key", key => "default value from " + key));
        }

        [Fact]
        public void TestGetValueOrDefaultWithProviderWithEmptyDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            Assert.Equal("default value from key",
                dictionary.GetValueOrDefault("key", key => "default value from " + key));
        }

        [Fact]
        public void TestGetValueOrDefaultWithProviderWithValidDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "key", "value" }
            };

            Assert.Equal("value", dictionary.GetValueOrDefault("key", key => "default value from " + key));
        }

        [Fact]
        public void TestGetValueOrDefaultWithProviderWithInvalidKey()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "key", "value" }
            };

            Assert.Throws<ArgumentNullException>("key", () => dictionary.GetValueOrDefault(null, key => null));
        }
    }
}