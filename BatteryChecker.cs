public class BatteryChecker
{
    public static bool IsBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        string tempMessage, socMessage, chargeRateMessage;

        bool tempCheck = TemperatureChecker.IsTemperatureOk(temperature, out tempMessage);
        bool socCheck = SoCChecker.IsSoCOk(soc, out socMessage);
        bool chargeRateCheck = ChargeRateChecker.IsChargeRateOk(chargeRate, out chargeRateMessage);

        errorMessage = ValidateBatteryParameters(float temperature, float soc, float chargeRate, out string errorMessage);

        errorMessage = tempMessage ?? socMessage ?? chargeRateMessage; // Return warning if exists
        return true;
    }

    public static bool ValidateBatteryParameters(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        if (!tempCheck || !socCheck || !chargeRateCheck)
        {
            errorMessage = tempMessage ?? socMessage ?? chargeRateMessage;  // Return the first error encountered
            return false;
        }
    }
}
