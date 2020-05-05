namespace BerlinClock
{
    public interface ITimeUnitFormatter
    {
        string FormatSecondRepresentation(bool active);
        string FormatMinutesRepresentation(int upperLights, int lowerLights);
        string FormatHoursRepresentation(int upperLights, int lowerLights);
    }
}
