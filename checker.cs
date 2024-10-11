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
        const float CHARGERATE_MIN = 0.8f;
        const string INVALID_RANGE = " is out of range";

        static bool CheckRange(float value, float min, float max, string parameter, out string message)
        {
            if (value < min || value > max)
            {
                message = parameter + INVALID_RANGE;
                return false;
            }
            message = null;  // Valid case
            return true;
        }

        static bool isTemperatureOk(float temperature, out string message)
        {
            return CheckRange(temperature, TEMP_MIN, TEMP_MAX, "Temperature", out message);
        }

        static bool isSoCOk(float soc, out string message)
        {
            return CheckRange(soc, SOC_MIN, SOC_MAX, "State of Charge", out message);
        }

        static bool isChargeRateOk(float chargeRate, out string message)
        {
            return CheckRange(chargeRate, 0, CHARGERATE_MIN, "Charge Rate", out message);
        }

        static bool isBatteryOk(float temperature, float soc, float chargeRate, out string errorMessage)
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

            errorMessage = null;
            return true;
        }

        static void AssertTrue(bool condition)
        {
            Debug.Assert(condition, "Test failed: expected true");
        }

        static void AssertFalse(bool condition)
        {
            Debug.Assert(!condition, "Test failed: expected false");
        }

        static int RunTest()
        {
            string errorMessage;

            AssertTrue(isBatteryOk(25, 70, 0.7f, out errorMessage));  
            AssertFalse(isBatteryOk(50, 85, 0.0f, out errorMessage));  
            return 0;
        }

        static void Main(string[] args)
        {
            RunTest();
            Console.WriteLine("All tests passed.");
        }
    }
}
