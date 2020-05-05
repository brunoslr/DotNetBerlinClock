using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class BerlinClockRepresentationTests
    {

        IBerlinClockRepresentation _sut = new BerlinClockRepresentation();

        [TestCase("00:00:00", ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase("24:00:00", ExpectedResult = "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase("13:00:00", ExpectedResult = "Y\r\nRROO\r\nRRRO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase("00:13:00", ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nYYOOOOOOOOO\r\nYYYO")]
        [TestCase("00:59:00", ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase("24:59:59", ExpectedResult = "O\r\nRRRR\r\nRRRR\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase("InvalidInput", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss")]
        public string FormatMinutesRepresentationTest(string aTime)
        {
            return _sut.ConvertToBerlinClockTime(aTime);
        }
    }
}
