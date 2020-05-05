namespace BerlinClock
{
    public interface ITimeParser
    {
        TimeStruct ParseTimeInput(string aTime);
    }
}