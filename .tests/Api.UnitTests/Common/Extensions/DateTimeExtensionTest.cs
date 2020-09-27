using System;
using Api.Entities.Common.Extensions;
using NUnit.Framework;

namespace Api.UnitTests.Common.Extensions
{
    [TestFixture]
    public class DateTimeExtensionTest
    {
        [Test]
        public void DateTimeToUnixTimestampTest()
        {
            var dateTime = DateTime.UtcNow;
            var expected = (int)(dateTime - DateTimeExtension.epoch).TotalSeconds;
            var actual = dateTime.DateTimeToUnixTimestamp();

            Assert.AreEqual(expected, actual);
        }
    }
}