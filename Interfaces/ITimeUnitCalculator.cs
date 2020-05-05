namespace BerlinClock
{
    public interface ITimeUnitCalculator
    {
        bool IsSecondsLightActive(int seconds);
        int CalculateUpperHoursNumberOfLights(int hours);
        int CalculateLowerHoursNumberOfLights(int hours);
        int CalculateUpperMinutesNumberOfLights(int minutes);
        int CalculateLowerMinutesNumberOfLights(int minutes);

    }
}