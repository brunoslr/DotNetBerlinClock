namespace BerlinClock
{
    public class TimeUnitCalculator : ITimeUnitCalculator
    {
        private ITimeUnitFormatter timeUnitFormatter = new TimeUnitFormatter();

        public bool IsSecondsLightActive(int seconds)
        {
            return seconds % 2 == 0;
        }
        
        public int CalculateUpperHoursNumberOfLights(int hours)
        {
            return hours / 5;
        }

        public int CalculateLowerHoursNumberOfLights(int hours)
        {
            return hours % 5;
        }

        public int CalculateUpperMinutesNumberOfLights(int minutes)
        {
            return minutes / 5;
        }

        public int CalculateLowerMinutesNumberOfLights(int minutes)
        {
            return minutes % 5;
        }
    }
}
