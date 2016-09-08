﻿using System;
using Xenolope.Extensions.Tests.Entities;
using Xunit;

namespace Xenolope.Extensions.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void TestEqualsIgnoreCaseWithNull()
        {
            string value = null;

            Assert.False(value.EqualsIgnoreCase(string.Empty));
        }

        [Fact]
        public void TestEqualsIgnoreCaseWithDifferentCasedText()
        {
            var value = "test";

            Assert.True(value.EqualsIgnoreCase("TEST"));
        }

        [Fact]
        public void TestEqualsIgnoreCaseWithSamedCasedText()
        {
            var value = "test";

            Assert.True(value.EqualsIgnoreCase("test"));
        }

        [Fact]
        public void TestEqualsIgnoreCaseWithNonEqualText()
        {
            var value = "test";

            Assert.False(value.EqualsIgnoreCase("no-test"));
        }

        [Fact]
        public void TestEqualsOneOfIgnoreCaseWithNull()
        {
            string value = null;

            var values = new string[] {"hello", "test"};

            Assert.False(value.EqualsOneOfIgnoreCase(values));
        }

        [Fact]
        public void TestEqualsOneOfIgnoreCaseWithDifferentCasedText()
        {
            var values = new string[] {"hello", "test"};

            Assert.True("Hello".EqualsOneOfIgnoreCase(values));
        }

        [Fact]
        public void TestEqualsOneOfIgnoreCaseWithSameCasedText()
        {
            var values = new string[] {"hello", "test"};

            Assert.True("hello".EqualsOneOfIgnoreCase(values));
        }

        [Fact]
        public void TestEqualsOneOfIgnoreCaseWithNonEqualText()
        {
            var values = new string[] {"hello", "test"};

            Assert.False("nope".EqualsOneOfIgnoreCase(values));
        }

        [Fact]
        public void TestEqualsOneOfKeepingCaseWithNull()
        {
            string value = null;

            var values = new string[] {"hello", "test"};

            Assert.False(value.EqualsOneOf(values));
        }

        [Fact]
        public void TestEqualsOneOfKeepingCaseWithDifferentCasedText()
        {
            var values = new string[] {"hello", "test"};

            Assert.False("Hello".EqualsOneOf(values));
        }

        [Fact]
        public void TestEqualsOneOfKeepingCaseWithSameCasedText()
        {
            var values = new string[] {"hello", "test"};

            Assert.True("hello".EqualsOneOf(values));
        }

        [Fact]
        public void TestEqualsOneOfKeepingCaseWithNonEqualText()
        {
            var values = new string[] {"hello", "test"};

            Assert.False("nope".EqualsOneOf(values));
        }

        [Fact]
        public void TestEqualsOneOfWithNullComparisons()
        {
            Assert.False("nope".EqualsOneOf(null));
        }

        [Fact]
        public void TestEqualsOneOfWithEmptyComparisons()
        {
            var values = new string[] {};

            Assert.False("nope".EqualsOneOf(values));
        }

        [Fact]
        public void TestIsNullOrWhitespaceWithNull()
        {
            string value = null;

            Assert.True(value.IsNullOrWhitespace());
        }

        [Fact]
        public void TestIsNullOrWhitespaceWithEmpty()
        {
            var value = "";

            Assert.True(value.IsNullOrWhitespace());
        }

        [Fact]
        public void TestIsNullOrWhitespaceWithWhitespace()
        {
            var value = " \t      \r\n";

            Assert.True(value.IsNullOrWhitespace());
        }

        [Fact]
        public void TestIsNullOrWhitespaceWithText()
        {
            var value = " \t   hello   \r\n";

            Assert.False(value.IsNullOrWhitespace());
        }

        [Fact]
        public void TestToEnum()
        {
            Assert.Equal(Gender.Male, "male".ToEnum<Gender>());
        }

        [Fact]
        public void TestToEnumWithInvalidString()
        {
            Assert.Throws<ArgumentException>(() => "woman".ToEnum<Gender>());
        }

        [Fact]
        public void TestToEnumWithNull()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => nullString.ToEnum<Gender>());
        }

        [Fact]
        public void TestToEnumWithDefault()
        {
            Assert.Equal(Gender.Male, "male".ToEnum(Gender.Unknown));
        }

        [Fact]
        public void TestToEnumWithDefaultWithInvalidString()
        {
            Assert.Equal(Gender.Unknown, "woman".ToEnum(Gender.Unknown));
        }

        [Fact]
        public void TestToEnumWithDefaultWithNull()
        {
            string nullString = null;

            Assert.Equal(Gender.Unknown, nullString.ToEnum(Gender.Unknown));
        }
    }
}