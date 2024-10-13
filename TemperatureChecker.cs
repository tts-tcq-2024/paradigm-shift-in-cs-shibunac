public class TemperatureChecker
{
    private const float TEMP_MIN = 0;
    private const float TEMP_MAX = 45;
    private const float WARNING_TOLERANCE_PERCENT = 5;

    public static bool IsTemperatureOk(float temperature, out string message)
    {
        if (!CheckRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message))
            return false;

        return CheckWarningRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message);
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

    private static bool CheckWarningRange(float value, float min, float max, string parameter, out string message)
    {
        float warningTolerance = max * WARNING_TOLERANCE_PERCENT / 100;

        if (value >= min && value <= min + warningTolerance)
        {
            message = $"Approaching lower limit of {parameter}";
            return true;
        }
        else if (value >= max - warningTolerance && value <= max)
        {
            message = $"Approaching upper limit of {parameter}";
            return true;
        }

        message = null;  // No warning, within safe range
        return true;
    }
}
