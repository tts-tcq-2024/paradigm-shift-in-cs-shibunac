public class BatteryChecker
{
    public static bool IsBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        string tempMessage, socMessage, chargeRateMessage;

        bool tempCheck = TemperatureChecker.IsTemperatureOk(temperature, out tempMessage);
        bool socCheck = SoCChecker.IsSoCOk(soc, out socMessage);
        bool chargeRateCheck = ChargeRateChecker.IsChargeRateOk(chargeRate, out chargeRateMessage);

        // Pass the check results to the validation method
        return ValidateBatteryParameters(tempCheck, socCheck, chargeRateCheck, tempMessage, socMessage, chargeRateMessage, out errorMessage);
    }

    public static bool ValidateBatteryParameters(bool tempCheck, bool socCheck, bool chargeRateCheck, 
                                                 string tempMessage, string socMessage, string chargeRateMessage, 
                                                 out string errorMessage)
    {
        if (!tempCheck || !socCheck || !chargeRateCheck)
        {
            errorMessage = tempMessage ?? socMessage ?? chargeRateMessage;  // Return the first error encountered
            return false;
        }

        errorMessage = null;  // No errors
        return true;
    }
}
