using System;

namespace BerlinClock
{

    public class TimeParser : ITimeParser
    {
        private readonly string TimeArgumentNullOrEmptyExceptionMessage = "Time argument is null or empty";
        private readonly string TimeArgumentInvalidFormatExceptionMessage = "The time should be provided in the format hh:mm:ss";
        private readonly string TimeArgumentInvalidHourValuesExceptionMessage = "The time should be provided in the format hh:mm:ss, hours should be between 0 and 24";
        private readonly string TimeArgumentInvalidMinuteFormatExceptionMessage = "The time should be provided in the format hh:mm:ss, minutes should be between 0 and 59";
        private readonly string TimeArgumentInvalidSecondFormatExceptionMessage = "The time should be provided in the format hh:mm:ss, seconds should be between 0 and 59";

        public TimeStruct ParseTimeInput(string aTime)
        {
            int hours, minutes, seconds;

            if (string.IsNullOrEmpty(aTime))
                throw new ArgumentException(TimeArgumentNullOrEmptyExceptionMessage);

            string[] timeElements = aTime.Split(':');

            if (timeElements.Length != 3)
                throw new ArgumentException(TimeArgumentInvalidFormatExceptionMessage);

            hours = Int32.Parse(timeElements[0]);

            if (hours > 24 || hours < 0)
                throw new FormatException(TimeArgumentInvalidHourValuesExceptionMessage);

            minutes = Int32.Parse(timeElements[1]);
            
            if (minutes > 59 || minutes < 0)
                throw new FormatException(TimeArgumentInvalidMinuteFormatExceptionMessage);

            seconds = Int32.Parse(timeElements[2]);
            
            if (seconds > 59 || seconds < 0)
                throw new FormatException(TimeArgumentInvalidSecondFormatExceptionMessage);

            return new TimeStruct(hours, minutes, seconds);
        }
    }
}
