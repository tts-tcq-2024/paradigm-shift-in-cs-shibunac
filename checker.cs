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
    const float CHARGERATE_MIN = 0.8;
    const string INVALID_RANGE = "out of range";
    

    static bool isTemperatureOk(float temperature, out string meassage){
        if (temperature < TEMP_MIN || temperature > TEMP_MAX) 
        {
            message = "Temperature" + INVALID_RANGE;
            return false;
        }
        return true;
    }

    static bool isSoCOk(float soc, out string meassage){
        if (soc < SOC_MIN || soc > SOC_MAX) 
        {
            message = "State of Charge" + INVALID_RANGE;
            return false;
        }
        return true;
    }

    static bool isChargeRateOk(float chargeRate, out string meassage){
        if (chargeRate > CHARGERATE_MIN) 
        {
            message = "Charge Rate" + INVALID_RANGE;
            return false;
        }
        return true;
    }
        
    static bool isBatteryOk(float temperature, float soc, float chargeRate){
        bool tempCheck = isTemperatureOk(temperature);
        bool socCheck = isSoCOk(soc);
        bool chargeRateCheck = isChargeRateOk(chargeRate);

        return tempCheck && socCheck && chargeRateCheck;
    }  
    
    }
    static int RunTest() {
        AssertTrue(isBatteryOk(25, 70, 0.7f));
        AssertFalse(isBatteryOk(50, 85, 0.0f));
        return 0;
    }
    
}
}
