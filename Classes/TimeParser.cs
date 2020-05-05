using System;

namespace BerlinClock
{
    public class TimeParser : ITimeParser
    {
        private const string TimeArgumentNullOrEmptyExceptionMessage = "Time argument is null or empty";
        private const string TimeArgumentInvalidFormatExceptionMessage = 
            "The time should be provided in the format hh:mm:ss";
        private const string TimeArgumentInvalidHourValuesExceptionMessage = 
            "The time should be provided in the format hh:mm:ss, hours should be between 0 and 24";
        private const string TimeArgumentInvalidMinuteFormatExceptionMessage = 
            "The time should be provided in the format hh:mm:ss, minutes should be between 0 and 59";
        private const string TimeArgumentInvalidSecondFormatExceptionMessage = 
            "The time should be provided in the format hh:mm:ss, seconds should be between 0 and 59";

        public TimeStruct ParseTimeInput(string aTime)
        {
            if (string.IsNullOrEmpty(aTime))
                throw new ArgumentException(TimeArgumentNullOrEmptyExceptionMessage);

            var timeElements = aTime.Split(':');

            if (timeElements.Length != 3)
                throw new ArgumentException(TimeArgumentInvalidFormatExceptionMessage);

            var hours = int.Parse(timeElements[0]);

            if (hours > 24 || hours < 0)
                throw new FormatException(TimeArgumentInvalidHourValuesExceptionMessage);

            var minutes = int.Parse(timeElements[1]);
            
            if (minutes > 59 || minutes < 0)
                throw new FormatException(TimeArgumentInvalidMinuteFormatExceptionMessage);

            var seconds = int.Parse(timeElements[2]);
            
            if (seconds > 59 || seconds < 0)
                throw new FormatException(TimeArgumentInvalidSecondFormatExceptionMessage);

            return new TimeStruct(hours, minutes, seconds);
        }
    }
}
