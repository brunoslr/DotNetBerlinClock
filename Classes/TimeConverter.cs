namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        
        private IBerlinClockRepresentation berlinClockRepresentation = new BerlinClockRepresentation();

        public string convertTime(string aTime)
        {
            
            return berlinClockRepresentation.ConvertToBerlinClockTime(aTime);
            
        }
    }
}
