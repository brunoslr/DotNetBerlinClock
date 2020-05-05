using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class TimeUnitCalculationTests
    {
        readonly ITimeUnitCalculator sut = new TimeUnitCalculator();

        [TestCase(5, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(59, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        public bool IsSecondsLightActiveTest(int input)
        {
            return sut.IsSecondsLightActive(input);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(12, ExpectedResult = 2)] 
        [TestCase(16, ExpectedResult = 3)] 
        [TestCase(24, ExpectedResult = 4)] 
        public int CalculateUpperHoursNumberOfLightsTest(int hours)
        {
            return sut.CalculateUpperHoursNumberOfLights(hours);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(16, ExpectedResult = 1)]
        [TestCase(24, ExpectedResult = 4)]
        public int CalculateLowerHoursNumberOfLightsTest(int hours)
        {
            return sut.CalculateLowerHoursNumberOfLights(hours);
        }


        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(16, ExpectedResult = 3)]
        [TestCase(24, ExpectedResult = 4)]
        public int CalculateUpperMinutesNumberOfLightsTest(int hours)
        {
            return sut.CalculateUpperMinutesNumberOfLights(hours);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(16, ExpectedResult = 1)]
        [TestCase(24, ExpectedResult = 4)]
        public int CalculateLowerMinutesNumberOfLightsTest(int hours)
        {
            return sut.CalculateLowerMinutesNumberOfLights(hours);
        }
    }
}

