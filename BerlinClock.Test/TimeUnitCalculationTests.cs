using NUnit.Framework;
using System;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class TimeUnitCalculationTests
    {
        ITimeUnitCalculator _sut = new TimeUnitCalculator();

        [TestCase(5, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(59, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        public bool IsSecondsLightActiveTest(int input)
        {
            return _sut.IsSecondsLightActive(input);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(12, ExpectedResult = 2)] 
        [TestCase(16, ExpectedResult = 3)] 
        [TestCase(24, ExpectedResult = 4)] 
        public int CalculateUpperHoursNumberOfLightsTest(int hours)
        {
            return _sut.CalculateUpperHoursNumberOfLights(hours);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(16, ExpectedResult = 1)]
        [TestCase(24, ExpectedResult = 4)]
        public int CalculateLowerHoursNumberOfLightsTest(int hours)
        {
            return _sut.CalculateLowerHoursNumberOfLights(hours);
        }


        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(16, ExpectedResult = 3)]
        [TestCase(24, ExpectedResult = 4)]
        public int CalculateUpperMinutesNumberOfLightsTest(int hours)
        {
            return _sut.CalculateUpperMinutesNumberOfLights(hours);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(16, ExpectedResult = 1)]
        [TestCase(24, ExpectedResult = 4)]
        public int CalculateLowerMinutesNumberOfLightsTest(int hours)
        {
            return _sut.CalculateLowerMinutesNumberOfLights(hours);
        }
    }
}

