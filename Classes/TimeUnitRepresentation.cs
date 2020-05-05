using System;

namespace BerlinClock
{
    public class TimeUnitRepresentation : ITimeUnitRepresentation
    {
        private ITimeUnitFormatter timeUnitFormatter = new TimeUnitFormatter();
        private ITimeUnitCalculator timeUnitCalculation = new TimeUnitCalculator();

        public string SecondsRepresentation(int seconds)
        {
            bool isSecondActive = timeUnitCalculation.IsSecondsLightActive(seconds);

            return timeUnitFormatter.FormatSecondRepresentation(isSecondActive); 
        }

        public string HoursRepresentation(int hours)
        {

            int lowerHours = timeUnitCalculation.CalculateLowerHoursNumberOfLights(hours);
            int upperHours = timeUnitCalculation.CalculateUpperHoursNumberOfLights(hours);

            return timeUnitFormatter.FormatHoursRepresentation(upperHours, lowerHours );
        }

        public string MinutesRepresentation(int minutes)
        {
            int lowerMinutes = timeUnitCalculation.CalculateLowerMinutesNumberOfLights(minutes);
            int upperMinutes = timeUnitCalculation.CalculateUpperMinutesNumberOfLights(minutes);

            return timeUnitFormatter.FormatMinutesRepresentation(upperMinutes, lowerMinutes );
        }     

        public string TimeRepresentation(int seconds,  int minutes, int hours)
        {
            return $"{SecondsRepresentation(seconds)}{Environment.NewLine}" +
               $"{HoursRepresentation(hours)}{Environment.NewLine}" +
               $"{MinutesRepresentation(minutes)}";
        }
    }
}
