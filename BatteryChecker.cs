public class BatteryChecker
{
    public static bool IsBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        // Validate each parameter and get the corresponding error or warning message
        string tempMessage = ValidateParameter(TemperatureChecker.IsTemperatureOk, temperature);
        string socMessage = ValidateParameter(SoCChecker.IsSoCOk, soc);
        string chargeRateMessage = ValidateParameter(ChargeRateChecker.IsChargeRateOk, chargeRate);

        // Determine if any of the checks failed, and return the first error encountered
        errorMessage = tempMessage ?? socMessage ?? chargeRateMessage;

        // Return false if any of the checks failed, true otherwise
        return errorMessage == null;
    }

    // Helper method to validate parameters and return the error/warning message
    private static string ValidateParameter(Func<float, out string, bool> checkerFunction, float value)
    {
        string message;
        checkerFunction(value, out message);  // Call the checker function
        return message;  // Return the message (null if valid, otherwise error or warning)
    }
}
