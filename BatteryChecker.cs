public class BatteryChecker
{
    public static bool ValidateBatteryHealth(float temperature, float soc, float chargeRate, out string errorMessage)
    {
        string tempMessage, socMessage, chargeRateMessage;

        bool tempCheck = TemperatureChecker.IsTemperatureOk(temperature, out tempMessage);
        bool socCheck = SoCChecker.IsSoCOk(soc, out socMessage);
        bool chargeRateCheck = ChargeRateChecker.IsChargeRateOk(chargeRate, out chargeRateMessage);

        errorMessage = tempMessage ?? socMessage ?? chargeRateMessage;
        return ValidateBatteryParameters(tempCheck, socCheck, chargeRateCheck);
    }

    public static bool ValidateBatteryParameters(bool tempCheck, bool socCheck, bool chargeRateCheck)
    {
        return tempCheck && socCheck && chargeRateCheck;
    }
}
