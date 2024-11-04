public class SoCChecker
{
    private const float SOC_MIN = 20;
    private const float SOC_MAX = 80;
    private const float WARNING_TOLERANCE_PERCENT = 5;

    public static bool ValidateSoC(float soc, out string message)
    {
        if (!CheckRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message))
            return false;
        
        var warningChecker = new WarningRangeChecker();
        return !warningChecker.CheckWarningRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message);
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
