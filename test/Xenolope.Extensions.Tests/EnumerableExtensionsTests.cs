using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Xenolope.Extensions.Tests
{
    public class EnumerableExtensionTests
    {
        [Fact]
        public void TestContainsOneOfWithEmpty()
        {
            var enumerable = new List<string>();

            Assert.False(enumerable.ContainsOneOf("one", "two", "three"));
        }

        [Fact]
        public void TestContainsOneOfWithNull()
        {
            IEnumerable<string> enumerable = null;

            Assert.False(enumerable.ContainsOneOf("one", "two", "three"));
        }

        [Fact]
        public void TestContainsOneOfWithNonEmptyIncluding()
        {
            var enumerable = new List<string>()
            {
                "one",
                "two",
                "four"
            };

            Assert.True(enumerable.ContainsOneOf("one", "two", "three"));
        }

        [Fact]
        public void TestContainsOneOfWithNonEmptyNotIncluding()
        {
            var enumerable = new List<string>()
            {
                "four",
                "six",
                "nine"
            };

            Assert.False(enumerable.ContainsOneOf("one", "two", "three"));
        }

        [Fact]
        public void TestIsNotNullOrEmptyWithEmpty()
        {
            var enumerable = new List<string>();

            Assert.False(enumerable.IsNotNullOrEmpty());
        }

        [Fact]
        public void TestIsNotNullOrEmptyWithNull()
        {
            IEnumerable<string> enumerable = null;

            Assert.False(enumerable.IsNotNullOrEmpty());
        }

        [Fact]
        public void TestIsNotNullOrEmptyWithNonEmpty()
        {
            var enumerable = new List<string>()
            {
                "value"
            };

            Assert.True(enumerable.IsNotNullOrEmpty());
        }

        [Fact]
        public void TestIsNullOrEmptyWithEmpty()
        {
            var enumerable = new List<string>();

            Assert.True(enumerable.IsNullOrEmpty());
        }

        [Fact]
        public void TestIsNullOrEmptyWithNull()
        {
            IEnumerable<string> enumerable = null;

            Assert.True(enumerable.IsNullOrEmpty());
        }

        [Fact]
        public void TestIsNullOrEmptyWithNonEmpty()
        {
            var enumerable = new List<string>()
            {
                "value"
            };

            Assert.False(enumerable.IsNullOrEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithEmpty()
        {
            var enumerable = new List<string>();

            Assert.False(enumerable.IsNotEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithNull()
        {
            IEnumerable<string> enumerable = null;

            Assert.False(enumerable.IsNotEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithNonEmpty()
        {
            var enumerable = new List<string>()
            {
                "value"
            };

            Assert.True(enumerable.IsNotNullOrEmpty());
        }

        [Fact]
        public void TestIsEmptyWithEmpty()
        {
            var enumerable = new List<string>();

            Assert.True(enumerable.IsEmpty());
        }

        [Fact]
        public void TestIsEmptyWithNull()
        {
            IEnumerable<string> enumerable = null;

            Assert.True(enumerable.IsEmpty());
        }

        [Fact]
        public void TestIsEmptyWithNonEmpty()
        {
            var enumerable = new List<string>()
            {
                "value"
            };

            Assert.False(enumerable.IsEmpty());
        }

        [Fact]
        public void TestWhereNotWithNullPredicate()
        {
            var enumerable = new List<string>
            {
                "value",
                "other",
                "jonjo"
            };

            Assert.Throws<ArgumentNullException>(() => enumerable.WhereNot(null));
        }

        [Fact]
        public void TestWhereNotWithValidPredicate()
        {
            var enumerable = new List<string>
            {
                "value",
                "other",
                "jonjo"
            };

            var result = enumerable
                .WhereNot(value => value == "jonjo")
                .ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("value", result[0]);
            Assert.Equal("other", result[1]);
        }
    }
}