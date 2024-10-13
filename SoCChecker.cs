public class SoCChecker
{
    private const float SOC_MIN = 20;
    private const float SOC_MAX = 80;
    private const float WARNING_TOLERANCE_PERCENT = 5;

    public static bool IsSoCOk(float soc, out string message)
    {
        if (!CheckRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message))
            return false;

        return CheckWarningRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message);
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

        message = null;
        return true;
    }
}
