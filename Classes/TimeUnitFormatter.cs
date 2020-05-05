using System;

namespace BerlinClock
{
    public class TimeUnitFormatter : ITimeUnitFormatter
    {

        private const string NumberofLightsArgumentExceptionMessage = "Number of Active Lights should not be higher than number of available lights";

        private const char InactiveLightPattern = 'O';
        private const char ActiveHourLightPattern = 'R';
        private const char ActiveMinuteLightPattern = 'Y';
        private const string ActiveSecondLightPattern = "Y";
        private const string SpecialActiveMinuteLightPattern = "YYR";

        //clock constraints
        private const int LowerMinutesNumberOfLights = 4;
        private const int UpperMinutesNumberOfLights = 11;
        private const int LowerHoursNumberOfLights = 4;
        private const int UpperHoursNumberOfLights = 4;
       
        public string FormatSecondRepresentation ( bool active )
        {
            return active ? ActiveSecondLightPattern : InactiveLightPattern.ToString();
        }

        public string FormatMinutesRepresentation(int upperLights, int lowerLights)
        {
            return FormatToClockUpperMinutesOutput(upperLights, ActiveMinuteLightPattern, SpecialActiveMinuteLightPattern)
               + Environment.NewLine + (FormatToBaseClockOutput(lowerLights, ActiveMinuteLightPattern, LowerMinutesNumberOfLights)); 
        }

        public string FormatHoursRepresentation(int upperLights, int lowerLights)
        {
            return FormatToBaseClockOutput(upperLights, ActiveHourLightPattern, UpperHoursNumberOfLights)
                + Environment.NewLine + (FormatToBaseClockOutput(lowerLights, ActiveHourLightPattern, LowerHoursNumberOfLights));
        }

        private string FormatToBaseClockOutput(int numberofActiveLights, char simpleActiveLightPattern, int size)
        {
            if(numberofActiveLights > size)
                throw new ArgumentOutOfRangeException(NumberofLightsArgumentExceptionMessage);

            return new string(simpleActiveLightPattern, numberofActiveLights)
                + new string(InactiveLightPattern, size - numberofActiveLights);       
        }
        
        private string FormatToClockUpperMinutesOutput(int lights, char simpleActiveLightPattern, string specialPattern)
        {
            var baseFormatOutput = FormatToBaseClockOutput(lights, simpleActiveLightPattern, UpperMinutesNumberOfLights);   
            return baseFormatOutput.Replace(new string(simpleActiveLightPattern, specialPattern.Length), specialPattern);
        }

    }
}
