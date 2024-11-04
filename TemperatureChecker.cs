public class TemperatureChecker
{
    private const float TEMP_MIN = 0;
    private const float TEMP_MAX = 45;
    private const float WARNING_TOLERANCE_PERCENT = 5;

    public static bool ValidateTemperature(float temperature, out string message)
    {
        if (!CheckRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message))
            return false;
        
        var warningChecker = new WarningRangeChecker();
        return !warningChecker.CheckWarningRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message);
    }

    private static bool CheckRange(float value, float min, float max, string parameter, out string message)
    {
        if (value < min || value > max)
        {
            message = $"{parameter} is out of range";
            return false;
        }
        message = null;
        return true;
    }
}
