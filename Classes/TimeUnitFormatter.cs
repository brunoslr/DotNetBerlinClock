using System;

namespace BerlinClock
{
    public class TimeUnitFormatter : ITimeUnitFormatter
    {

        private readonly char inactiveLightPattern = 'O';
        private readonly char activeHourLightPattern = 'R';
        private readonly char activeMinuteLightPattern = 'Y';
        private readonly string activeSecondLightPattern = "Y";
        private readonly string specialActiveMinuteLightPattern = "YYR";

        //clock constraints
        private readonly int lowerMinutesNumberOfLights = 4;
        private readonly int upperMinutesNumberOfLights = 11;
        private readonly int lowerHoursNumberOfLights = 4;
        private readonly int upperHoursNumberOfLights = 4;
       
        public string FormatSecondRepresentation ( bool active )
        {
            return active ? activeSecondLightPattern : inactiveLightPattern.ToString();
        }

        public string FormatMinutesRepresentation(int upperLights, int lowerLights)
        {
            return FormatToClockUpperMinutesOutput(upperLights, activeMinuteLightPattern, specialActiveMinuteLightPattern)
               + Environment.NewLine + (FormatToBaseClockOutput(lowerLights, activeMinuteLightPattern, lowerMinutesNumberOfLights)); 
        }

        public string FormatHoursRepresentation(int upperLights, int lowerLights)
        {
            return FormatToBaseClockOutput(upperLights, activeHourLightPattern, upperHoursNumberOfLights)
                + Environment.NewLine + (FormatToBaseClockOutput(lowerLights, activeHourLightPattern, lowerHoursNumberOfLights));
        }

        private string FormatToBaseClockOutput(int numberofActiveLights, char simpleActiveLightPattern, int size)
        {
            if(numberofActiveLights > size)
                throw new ArgumentOutOfRangeException("Number of Active Lights should not be higher than number of available lights ");

            return new string(simpleActiveLightPattern, numberofActiveLights)
                + new string(inactiveLightPattern, size - numberofActiveLights);       
        }
        
        private string FormatToClockUpperMinutesOutput(int lights, char simpleActiveLightPattern, string specialPattern)
        {
            var baseFormatOutput = FormatToBaseClockOutput(lights, simpleActiveLightPattern, upperMinutesNumberOfLights);   
            return baseFormatOutput.Replace(new string(simpleActiveLightPattern, specialPattern.Length), specialPattern);
        }

    }
}
