public class BatteryChecker
{
    public static bool IsBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        // Array of tuples containing the checker function and corresponding value to check
        var checks = new (Func<float, out string, bool> checker, float value)[]
        {
            (TemperatureChecker.IsTemperatureOk, temperature),
            (SoCChecker.IsSoCOk, soc),
            (ChargeRateChecker.IsChargeRateOk, chargeRate)
        };

        // Iterate over each check and return the first error message encountered
        foreach (var (checker, value) in checks)
        {
            if (!checker(value, out errorMessage))  // If check fails, return the error message
            {
                return false;
            }
        }

        // If all checks passed, return null for errorMessage and true
        errorMessage = null;
        return true;
    }
}
