namespace BerlinClock
{
    public interface ITimeUnitRepresentation
    {
        string TimeRepresentation(int seconds, int minutes, int hours);

    }
}