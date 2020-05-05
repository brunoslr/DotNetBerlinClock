using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class TimeUnitRepresentationTests
    {

        ITimeUnitRepresentation _sut = new TimeUnitRepresentation();

        [TestCase(0, 0, 0, ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(0, 0, 24, ExpectedResult = "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(0, 0, 13, ExpectedResult = "Y\r\nRROO\r\nRRRO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase(0, 13, 0, ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nYYOOOOOOOOO\r\nYYYO")]
        [TestCase(0, 59, 0, ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase(59, 59, 24, ExpectedResult = "O\r\nRRRR\r\nRRRR\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase(35, 53, 12, ExpectedResult = "O\r\nRROO\r\nRROO\r\nYYRYYRYYRYO\r\nYYYO")]
        public string FormatMinutesRepresentationTest(int seconds, int minutes , int hours)
        {
            return _sut.TimeRepresentation(seconds, minutes, hours);
        }
    }
}
