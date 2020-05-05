using System;

namespace BerlinClock
{
    public class BerlinClockRepresentationBuilder : IBerlinClockRepresentationBuilder
    {
        private const string DefaultErrorMessage = "The conversion process has failed with the following message: ";

        private readonly ITimeUnitFormatter timeUnitFormatter = new TimeUnitFormatter();
        private readonly ITimeUnitCalculator timeUnitCalculation = new TimeUnitCalculator();
        private readonly ITimeParser timeParser = new TimeParser();

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

        private string TimeRepresentation(TimeStruct time)
        {
            return $"{SecondsRepresentation(time.Seconds)}{Environment.NewLine}" +
               $"{HoursRepresentation(time.Hours)}{Environment.NewLine}" +
               $"{MinutesRepresentation(time.Minutes)}";
        }

        public string ConvertToBerlinClockTime(string aTime)
        {
            try
            {
                TimeStruct time = timeParser.ParseTimeInput(aTime);
                return TimeRepresentation(time);
            }

            catch(Exception e)
            {
                //Error logging would go here!
                return $"{DefaultErrorMessage}{e.Message}";
            }
        }
    }
}
