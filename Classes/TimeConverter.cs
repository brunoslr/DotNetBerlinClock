using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private ITimeUnitRepresentation unitCalculation = new TimeUnitRepresentation();

        public string convertTime(string aTime)
        { 
          
            string[] timeElements = aTime.Split(':');
            int hours = Int32.Parse(timeElements[0]);
            int minutes = Int32.Parse(timeElements[1]);
            int seconds = Int32.Parse(timeElements[2]);

            return unitCalculation.TimeRepresentation(seconds, minutes, hours);


        }
    }
}
