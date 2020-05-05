using System;

namespace BerlinClock
{
    public class BerlinClockRepresentation : IBerlinClockRepresentation
    {
        private readonly string DefaultErrorMessage = "The conversion process has failed with the following message: ";

        private ITimeUnitFormatter timeUnitFormatter = new TimeUnitFormatter();
        private ITimeUnitCalculator timeUnitCalculation = new TimeUnitCalculator();
        private ITimeParser timeParser = new TimeParser();

        private string SecondsRepresentation(int seconds)
        {
            bool isSecondActive = timeUnitCalculation.IsSecondsLightActive(seconds);

            return timeUnitFormatter.FormatSecondRepresentation(isSecondActive); 
        }

        private string HoursRepresentation(int hours)
        {
            int lowerHours = timeUnitCalculation.CalculateLowerHoursNumberOfLights(hours);
            int upperHours = timeUnitCalculation.CalculateUpperHoursNumberOfLights(hours);

            return timeUnitFormatter.FormatHoursRepresentation(upperHours, lowerHours );
        }

        private string MinutesRepresentation(int minutes)
        {
            int lowerMinutes = timeUnitCalculation.CalculateLowerMinutesNumberOfLights(minutes);
            int upperMinutes = timeUnitCalculation.CalculateUpperMinutesNumberOfLights(minutes);

            return timeUnitFormatter.FormatMinutesRepresentation(upperMinutes, lowerMinutes );
        }
        private string TimeRepresentation(int seconds, int minutes, int hours)
        {
            return $"{SecondsRepresentation(seconds)}{Environment.NewLine}" +
               $"{HoursRepresentation(hours)}{Environment.NewLine}" +
               $"{MinutesRepresentation(minutes)}";
        }

        public string ConvertToBerlinClockTime(string aTime)
        {
            try
            {
                TimeStruct time = timeParser.ParseTimeInput(aTime);
                return TimeRepresentation(time.Seconds, time.Minutes, time.Hours);
            }

            catch(Exception e)
            {
                return $"{DefaultErrorMessage}{e.Message}";
            }
        }
    }
}
