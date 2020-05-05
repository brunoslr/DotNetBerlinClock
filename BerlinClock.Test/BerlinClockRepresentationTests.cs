using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    class BerlinClockRepresentationTests
    {
        readonly IBerlinClockRepresentationBuilder sut = new BerlinClockRepresentationBuilder();

        [TestCase("00:00:00", ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase("24:00:00", ExpectedResult = "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase("13:00:00", ExpectedResult = "Y\r\nRROO\r\nRRRO\r\nOOOOOOOOOOO\r\nOOOO")]
        [TestCase("00:13:00", ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nYYOOOOOOOOO\r\nYYYO")]
        [TestCase("00:59:00", ExpectedResult = "Y\r\nOOOO\r\nOOOO\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase("24:59:59", ExpectedResult = "O\r\nRRRR\r\nRRRR\r\nYYRYYRYYRYY\r\nYYYY")]
        [TestCase("InvalidInput", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss")]
        [TestCase("", ExpectedResult = "The conversion process has failed " +
            "with the following message: Time argument is null or empty")]
        [TestCase("25:00:00", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss," +
            " hours should be between 0 and 24")]
        [TestCase("-999:00:00", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss," +
            " hours should be between 0 and 24")]
        [TestCase("00:-01:00", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss," +
            " minutes should be between 0 and 59")]
        [TestCase("00:60:00", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss," +
            " minutes should be between 0 and 59")]
        [TestCase("00:00:-59", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss," +
            " seconds should be between 0 and 59")]
        [TestCase("00:00:60", ExpectedResult = "The conversion process has failed " +
            "with the following message: The time should be provided in the format hh:mm:ss," +
            " seconds should be between 0 and 59")]
        public string ConvertToBerlinClockRepresentationTest(string aTime)
        {
            return sut.ConvertToBerlinClockTime(aTime);
        }
    }
}
