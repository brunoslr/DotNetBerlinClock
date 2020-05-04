/**
 * Since the acceptance criteria accepts both 24:00:00 and 00:00:00 with different setup configurations
 * (Which is probably not the case of the real Berlin Clock...)
 * I have only limited the logic based on the rules of the read.me file and considered that only valid inputs
 * would be provided
 * If hours values above 23 are provided, the 4 "hour lights" will be enabled
 * If minutes values above 59 are provided, the 11 "minute lights" will be enabled
 * 
 **/

using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly char inactiveLightPattern = 'O';
        private readonly char activeHourLightPattern = 'R';
        private readonly char activeMinuteLightPattern = 'Y';
        private readonly string activeSecondLightPattern = "Y";
        private readonly string specialActiveMinuteLightPattern = "YYR";

        public string convertTime(string aTime)
        {
            string[] timeElements = aTime.Split(':');

            int hours = Int32.Parse(timeElements[0]);
            int minutes = Int32.Parse(timeElements[1]);
            int seconds = Int32.Parse(timeElements[2]);

            return $"{CalculateSecondRepresentation(seconds)}{Environment.NewLine}" +
                $"{CalculateHoursRepresentation(hours)}{Environment.NewLine}" +
                $"{CalculateMinutesRepresentation(minutes)}";
        }

        private string CalculateSecondRepresentation(int seconds)
        {
            return seconds % 2 == 0 ? activeSecondLightPattern : inactiveLightPattern.ToString();
        }

        private string CalculateHoursRepresentation(int hours)
        {
            //logic for the hour rows
            int upperHours = hours / 5; 
            int lowerHours = hours % 5;

            return FormatToClockOutput(upperHours, activeHourLightPattern, 4)
                + Environment.NewLine + (FormatToClockOutput(lowerHours, activeHourLightPattern, 4));
        }

        private string CalculateMinutesRepresentation(int minutes)
        {
            //logic for the lower two rows
            int upperMinutes = minutes / 5;
            int lowerMinutes = minutes % 5;

            return FormatToClockOutput(upperMinutes, activeMinuteLightPattern, 11, specialActiveMinuteLightPattern)
                + Environment.NewLine + (FormatToClockOutput(lowerMinutes, activeMinuteLightPattern, 4));
        }

        private string FormatToClockOutput(int numberofActiveLights, 
            char simpleActiveLightPattern, int size, string specialPattern = "")
        {
            var lightFormattedOutput = new string(simpleActiveLightPattern, numberofActiveLights)
                                        + new string(inactiveLightPattern, size - numberofActiveLights);

            if (string.IsNullOrEmpty(specialPattern))
                return lightFormattedOutput;

            return lightFormattedOutput.Replace(new string(simpleActiveLightPattern, specialPattern.Length), 
                specialPattern);
        }

    }
}
