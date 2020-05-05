using NUnit.Framework;
using System;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class TimeUnitFormatterTests
    {
        ITimeUnitFormatter _sut = new TimeUnitFormatter();

        [TestCase(true, ExpectedResult = "Y")]
        [TestCase(false, ExpectedResult = "O")]
        public string FormatSecondRepresentationTest(bool input)
        {
            return _sut.FormatSecondRepresentation(input);
        }

        [TestCase(11, 4, ExpectedResult = "YYRYYRYYRYY\r\nYYYY")]//59
        [TestCase(8, 3, ExpectedResult = "YYRYYRYYOOO\r\nYYYO")] // 43
        [TestCase(4, 2, ExpectedResult = "YYRYOOOOOOO\r\nYYOO")] // 22
        [TestCase(2, 2, ExpectedResult = "YYOOOOOOOOO\r\nYYOO")] // 12
        [TestCase(0, 0, ExpectedResult = "OOOOOOOOOOO\r\nOOOO")] // 0
        public string FormatMinutesRepresentationTest(int upperLights, int lowerLights)
        {
            return _sut.FormatMinutesRepresentation(upperLights, lowerLights);
        }

        [TestCase(4, 4, ExpectedResult = "RRRR\r\nRRRR")] // 24
        [TestCase(2, 3, ExpectedResult = "RROO\r\nRRRO")] // 13 
        [TestCase(1, 2, ExpectedResult = "ROOO\r\nRROO")] // 7
        [TestCase(0, 0, ExpectedResult = "OOOO\r\nOOOO")] // 0
        public string FormatHoursRepresentationTest(int upperLights, int lowerLights)
        {
            return _sut.FormatHoursRepresentation(upperLights, lowerLights);
        }

        [Test]
        public void ShouldNotAcceptMoreLightsThanCapacity()
        {
            int hours = 999;
            Assert.Throws<ArgumentOutOfRangeException>(() => { _sut.FormatHoursRepresentation(hours, 0); });

        }
    }
}

