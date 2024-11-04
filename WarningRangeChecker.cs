public class WarningRangeChecker
{
    private const float WARNING_TOLERANCE_PERCENT = 5;

    public bool CheckWarningRange(float value, float min, float max, string parameter, out string message)
    {
        float warningTolerance = max * WARNING_TOLERANCE_PERCENT / 100;

        // Initialize message to null
        message = null;

        // Check for minimum warning
        if (CheckMinWarning(value, min, warningTolerance, parameter, out message))
        {
            return true; // Warning found
        }

        // Check for maximum warning
        if (CheckMaxWarning(value, max, warningTolerance, parameter, out message))
        {
            return true; // Warning found
        }

        return false; // No warnings found
    }

    private bool CheckMinWarning(float value, float min, float warningTolerance, string parameter, out string message)
    {
        if (value >= min && value <= min + warningTolerance)
        {
            message = $"Approaching lower limit of {parameter}";
            return true;
        }

        message = null; // No warning
        return false; // No warning found
    }

    private bool CheckMaxWarning(float value, float max, float warningTolerance, string parameter, out string message)
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
