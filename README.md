# paradigm-shift-csharp

# Programming Paradigms

Electric Vehicles have BMS - Battery Management Systems

[Here is an article that helps to understand the need for BMS](https://circuitdigest.com/article/battery-management-system-bms-for-electric-vehicles)

[Wikipedia gives an idea of the types and topologies](https://en.wikipedia.org/wiki/Battery_management_system)

[This site gives the optimum Charging-temperature limits](https://batteryuniversity.com/learn/article/charging_at_high_and_low_temperatures)

[This abstract suggests a range for the optimum State of Charge](https://www.sciencedirect.com/science/article/pii/S2352484719310911)

[Here is a reference for the maximum charge rate](https://www.electronics-notes.com/articles/electronic_components/battery-technology/li-ion-lithium-ion-charging.php#:~:text=Constant%20current%20charge:%20In%20the%20first%20stage%20of,rate%20of%20a%20maximum%20of%200.8C%20is%20recommended.)

## Possible purpose

- Protect batteries while charging:
at home, in public place, within vehicle / regenerative braking
- Estimate life, inventory and supply chains

## The Starting Point

We will explore the charging phase of Li-ion batteries to start with.

## Issues

- The code here has high complexity in a single function.
- The tests are not complete - they do not cover all the needs of a consumer

## Tasks

1. Reduce the cyclomatic complexity.
1. Separate pure functions from I/O
1. Avoid duplication - functions that do nearly the same thing
1. Complete the tests - cover all conditions.
1. To take effective action, we need to know
the abnormal measure and the breach -
whether high or low. Add this capability.

## The Exploration

How well does our code hold-out in the rapidly evolving EV space?
Can we add new functionality without disturbing the old?

## The Landscape

- Limits may change based on new research
- Technology changes due to obsolescence
- Sensors may be from different vendors with different accuracy
- Predicting the future requires Astrology!

## Keep it Simple

Shorten the Semantic distance

- Procedural to express sequence
- Functional to express relation between input and output
- Object oriented to encapsulate state with actions
- Apect oriented to capture repeating aspects

## Implementation

### BatteryChecker Class
Purpose:
The BatteryChecker class validates the overall health of a battery by checking its temperature, state of charge (SoC), and charge rate.

Methods:

1) ValidateBatteryHealth(float temperature, float soc, float chargeRate, out string errorMessage):
Validates the battery's temperature, SoC, and charge rate.
Returns true if all checks are within valid ranges, otherwise returns false.
Outputs an error message detailing which parameter failed validation.

2) ValidateBatteryParameters(bool tempCheck, bool socCheck, bool chargeRateCheck):
Helper method that checks if all passed validation flags are true.
Returns true if all parameters are valid, otherwise false.

### ChargeRateChecker Class
Purpose:
The ChargeRateChecker class validates the charge rate of a battery, ensuring it falls within acceptable limits.

Methods:

1) ValidateChargeRate(float chargeRate, out string message):
Checks if the charge rate is within the valid range.
Uses CheckRange to validate the value.
Utilizes WarningRangeChecker to determine if the charge rate approaches warning limits.

2) CheckRange(float value, float min, float max, string parameter, out string message):
Checks if a given value is within a specified range and outputs an appropriate message.

### SoCChecker Class
Purpose:
The SoCChecker class validates the state of charge (SoC) of a battery.

Methods:

1) ValidateSoC(float soc, out string message):
Validates the SoC value against defined limits.
Utilizes WarningRangeChecker to check for warnings.
2) CheckRange(float value, float min, float max, string parameter, out string message):
Similar to ChargeRateChecker, checks if a value is within the acceptable range.

### TemperatureChecker Class
Purpose:
The TemperatureChecker class validates the operating temperature of the battery.

Methods:

1) ValidateTemperature(float temperature, out string message):
Checks if the temperature is within the valid range.
Uses WarningRangeChecker to check for proximity to warning thresholds.
2) CheckRange(float value, float min, float max, string parameter, out string message):
Validates if the temperature falls within acceptable limits.

### WarningRangeChecker Class
Purpose:
The WarningRangeChecker class checks if a value approaches the defined warning limits for various parameters.

Methods:

1) CheckWarningRange(float value, float min, float max, string parameter, out string message):
Determines if a value is approaching either the minimum or maximum warning thresholds.
2) CheckMinWarning(float value, float min, float warningTolerance, string parameter, out string message):
Checks if a value is near the lower limit and outputs a warning message if so.
3) CheckMaxWarning(float value, float max, float warningTolerance, string parameter, out string message):
Checks if a value is near the upper limit and outputs a warning message if so.

