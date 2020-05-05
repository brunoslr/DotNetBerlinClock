using NUnit.Framework;
using System;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class TimeParserTests
    {
        readonly ITimeParser sut = new TimeParser();

        [Test]
        public void TimeParserSimpleTest()
        {
            var result = sut.ParseTimeInput("03:15:39");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(3, result.Hours);
                Assert.AreEqual(15, result.Minutes);
                Assert.AreEqual(39, result.Seconds);
            });
        }

        [Test]
        public void ShouldThrowErrorForEmptyStringInput()
        {
            Assert.Throws<ArgumentException>(() => { sut.ParseTimeInput(""); });
        }

        [Test]
        public void ShouldThrowErrorForInvalidStringInput()
        {
            Assert.Throws<ArgumentException>(() => { sut.ParseTimeInput("Not_a_valid_input"); });
        }

        [Test]
        public void ShouldThrowErrorForInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => { sut.ParseTimeInput("0:1:2:3:4"); });
        }

        [Test]
        public void ShouldThrowErrorForInvalidHourValue()
        {
            Assert.Throws<FormatException>(() => { sut.ParseTimeInput("99:15:39"); });
        }
        
        [Test]
        public void ShouldThrowErrorForInvalidMinuteValue()
        {
            Assert.Throws<FormatException>(() => { sut.ParseTimeInput("00:99:39"); });
        }

        [Test]
        public void ShouldThrowErrorForInvalidSecondValue()
        {
            Assert.Throws<FormatException>(() => { sut.ParseTimeInput("00:15:99"); });
        }
    }
}

