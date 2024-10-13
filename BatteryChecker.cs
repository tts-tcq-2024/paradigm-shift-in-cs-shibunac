public class BatteryChecker
{
    public static bool IsBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        string tempMessage, socMessage, chargeRateMessage;

        bool tempCheck = TemperatureChecker.IsTemperatureOk(temperature, out tempMessage);
        bool socCheck = SoCChecker.IsSoCOk(soc, out socMessage);
        bool chargeRateCheck = ChargeRateChecker.IsChargeRateOk(chargeRate, out chargeRateMessage);

        errorMessage = tempMessage ?? socMessage ?? chargeRateMessage;
        // Consolidated check for errors in one method call
        return ValidateBatteryParameters(tempCheck, socCheck, chargeRateCheck);
    }

    public static bool ValidateBatteryParameters(bool tempCheck, bool socCheck, bool chargeRateCheck)
    {
        // Use a single check by grouping the messages
        return tempCheck && socCheck && chargeRateCheck;
    }
}
