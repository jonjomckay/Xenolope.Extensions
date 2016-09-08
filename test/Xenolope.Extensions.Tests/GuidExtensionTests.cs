using System;
using Xunit;

namespace Xenolope.Extensions.Tests
{
    public class GuidExtensionTests
    {
        [Fact]
        public void TestIsEmptyWithNullNullableGuid()
        {
            Guid? guid = null;

            Assert.True(guid.IsEmpty());
        }

        [Fact]
        public void TestIsEmptyWithEmptyNullableGuid()
        {
            Guid? guid = Guid.Empty;

            Assert.True(guid.IsEmpty());
        }

        [Fact]
        public void TestIsEmptyWithValuedNullableGuid()
        {
            Guid? guid = Guid.NewGuid();

            Assert.False(guid.IsEmpty());
        }

        [Fact]
        public void TestIsEmptyWithEmptyGuid()
        {
            Guid guid = Guid.Empty;

            Assert.True(guid.IsEmpty());
        }

        [Fact]
        public void TestIsEmptyWithGuid()
        {
            Guid guid = Guid.NewGuid();

            Assert.False(guid.IsEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithNullNullableGuid()
        {
            Guid? guid = null;

            Assert.False(guid.IsNotEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithEmptyNullableGuid()
        {
            Guid? guid = Guid.Empty;

            Assert.False(guid.IsNotEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithValuedNullableGuid()
        {
            Guid? guid = Guid.NewGuid();

            Assert.True(guid.IsNotEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithEmptyGuid()
        {
            Guid guid = Guid.Empty;

            Assert.False(guid.IsNotEmpty());
        }

        [Fact]
        public void TestIsNotEmptyWithGuid()
        {
            Guid guid = Guid.NewGuid();

            Assert.True(guid.IsNotEmpty());
        }
    }
}