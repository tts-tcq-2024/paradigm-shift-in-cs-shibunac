// Define a delegate that matches the checking method signature.
public delegate bool CheckerFunction(float value, out string message);

public class BatteryChecker
{
    public static bool IsBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        errorMessage = ValidateParameter(TemperatureChecker.IsTemperatureOk, temperature) ??
                       ValidateParameter(SoCChecker.IsSoCOk, soc) ??
                       ValidateParameter(ChargeRateChecker.IsChargeRateOk, chargeRate);

        return errorMessage == null;
    }

    private static string ValidateParameter(CheckerFunction checkerFunction, float value)
    {
        string message;
        bool isValid = checkerFunction(value, out message);
        return isValid ? null : message; // Return either null (if valid) or the error/warning message.
    }
}
