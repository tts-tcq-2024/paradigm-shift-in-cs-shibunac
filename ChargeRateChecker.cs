public class ChargeRateChecker
{
    private const float CHARGERATE_MIN = 0;
    private const float CHARGERATE_MAX = 0.8f;
    private const float WARNING_TOLERANCE_PERCENT = 5;

    public static bool ValidateChargeRateHealth(float chargeRate, out string message)
    {
        if (!CheckRange(chargeRate, CHARGERATE_MIN, CHARGERATE_MAX, "Charge Rate", out message))
            return false;

        return !CheckWarningRange(chargeRate, CHARGERATE_MIN, CHARGERATE_MAX, "Charge Rate", out message);
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
    
        // Initialize message to null
        message = null;
    
        // Check for minimum warning
        if (CheckMinWarning(value, min, warningTolerance, parameter, out message))
        {
            return false; // Warning found
        }
    
        // Check for maximum warning
        if (CheckMaxWarning(value, max, warningTolerance, parameter, out message))
        {
            return true; // Warning found
        }
    
        return false; // No warnings found
    }

    private static bool CheckMinWarning(float value, float min, float warningTolerance, string parameter, out string message)
    {
        if (value >= min && value <= min + warningTolerance)
        {
            message = $"Approaching lower limit of {parameter}";
            return true;
        }
        
        message = null; // No warning
        return false; // No warning found
    }
    
    private static bool CheckMaxWarning(float value, float max, float warningTolerance, string parameter, out string message)
    {
        if (value >= max - warningTolerance && value <= max)
        {
            message = $"Approaching upper limit of {parameter}";
            return true;
        }
    
        message = null; // No warning
        return false; // No warning found
    }

}
