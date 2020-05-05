namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        
        private readonly IBerlinClockRepresentationBuilder berlinClockRepresentationBuilder = new BerlinClockRepresentationBuilder();

        public string convertTime(string aTime)
        {
            
            return berlinClockRepresentationBuilder.ConvertToBerlinClockTime(aTime);
            
        }
    }
}
