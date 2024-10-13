using System;
using System.Diagnostics;

namespace paradigm_shift_csharp
{
    class Checker
    {
        const float TEMP_MIN = 0;
        const float TEMP_MAX = 45;
        const float SOC_MIN = 20;
        const float SOC_MAX = 80;
        const float CHARGERATE_MIN = 0;
        const float CHARGERATE_MAX = 0.8f;
        const float WARNING_TOLERANCE_PERCENT = 5;
        const string INVALID_RANGE = " is out of range";
        const string WARNING_APPROACHING_LOW = "Approaching lower limit of ";
        const string WARNING_APPROACHING_HIGH = "Approaching upper limit of ";

        private static bool CheckRange(float value, float min, float max, string parameter, out string message)
        {
            if (value < min || value > max)
            {
                message = parameter + INVALID_RANGE;
                return false;
            }
            message = null;  // Valid case
            return true;
        }

        private static bool CheckWarningRange(float value, float min, float max, string parameter, out string message)
        {
            float warningTolerance = max * WARNING_TOLERANCE_PERCENT / 100;

            if (value >= min && value <= min + warningTolerance)
            {
                message = WARNING_APPROACHING_LOW + parameter;
                return true;
            }
            else if (value >= max - warningTolerance && value <= max)
            {
                message = WARNING_APPROACHING_HIGH + parameter;
                return true;
            }

            message = null;  // No warning, within safe range
            return true;
        }

        public static bool isTemperatureOk(float temperature, out string message)
        {
            if (!CheckRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message))
                return false;

            return CheckWarningRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message);
        }

        public static bool isSoCOk(float soc, out string message)
        {
            if (!CheckRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message))
                return false;

            return CheckWarningRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message);
        }

        public static bool isChargeRateOk(float chargeRate, out string message)
        {
            if (!CheckRange(chargeRate, CHARGERATE_MIN, CHARGERATE_MAX, "Charge Rate", out message))
                return false;

            return CheckWarningRange(chargeRate, CHARGERATE_MIN, CHARGERATE_MAX, "Charge Rate", out message);
        }

         public static bool isBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
        {
            string tempMessage, socMessage, chargeRateMessage;

            bool tempCheck = isTemperatureOk(temperature, out tempMessage);
            bool socCheck = isSoCOk(soc, out socMessage);
            bool chargeRateCheck = isChargeRateOk(chargeRate, out chargeRateMessage);

            if (!tempCheck || !socCheck || !chargeRateCheck)
            {
                errorMessage = tempMessage ?? socMessage ?? chargeRateMessage;  // Return the first error encountered
                return false;
            }

            errorMessage = tempMessage ?? socMessage ?? chargeRateMessage; // Return warning if exists
            return true;
        }
    }
}
