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
    const string INVALID_RANGE = "Out of Range";
    

    static bool isTemperatureOk(float temperature){
        return (temperature < 0 || temperature > 45) ? false : true;
    }

    static bool isSoCOk(float soc){
        return (soc < 20 || soc > 80) ? false : true;
    }

    static bool isChargeRateOk(float chargeRate){
        return (chargeRate > 0.8) ? false : true
    }
        
    static bool isBatteryOk(float temperature, float soc, float chargeRate){
        bool tempCheck = isTemperatureOk(temperature);
        bool socCheck = isSoCOk(soc);
        bool chargeRateCheck = isChargeRateOk(chargeRate);

        return tempCheck && socCheck && chargeRateCheck;
    }   

    static string DisplayMessage(){
        
    }
    
    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
    
}
}
