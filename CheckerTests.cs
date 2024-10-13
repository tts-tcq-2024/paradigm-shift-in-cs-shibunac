using Xunit;

namespace paradigm_shift_csharp.Tests
{
    public class CheckerTests
    {
        [Theory]
        [InlineData(25, true, null)] // Temperature within normal range
        [InlineData(2, true, "Approaching lower limit of Temperature")] // Temperature approaching lower limit
        [InlineData(43, true, "Approaching upper limit of Temperature")] // Temperature approaching upper limit
        [InlineData(-5, false, "Temperature is out of range")] // Temperature below lower limit
        [InlineData(50, false, "Temperature is out of range")] // Temperature above upper limit
        public void IsTemperatureOk_Test(float temperature, bool expectedValidity, string expectedMessage)
        {
            string message;
            bool isValid = TemperatureChecker.isTemperatureOk(temperature, out message);

            Assert.Equal(expectedValidity, isValid);
            Assert.Equal(expectedMessage, message);
        }

        [Theory]
        [InlineData(70, true, null)] // SoC within normal range
        [InlineData(21, true, "Approaching lower limit of State of Charge")] // SoC approaching lower limit
        [InlineData(79, true, "Approaching upper limit of State of Charge")] // SoC approaching upper limit
        [InlineData(15, false, "State of Charge is out of range")] // SoC below lower limit
        [InlineData(85, false, "State of Charge is out of range")] // SoC above upper limit
        public void IsSoCOk_Test(float soc, bool expectedValidity, string expectedMessage)
        {
            string message;
            bool isValid = SoCChecker.isSoCOk(soc, out message);

            Assert.Equal(expectedValidity, isValid);
            Assert.Equal(expectedMessage, message);
        }

        [Theory]
        [InlineData(0.7f, true, null)] // Charge rate within normal range
        [InlineData(0.1f, true, "Approaching lower limit of Charge Rate")] // Charge rate approaching lower limit
        [InlineData(0.77f, true, "Approaching upper limit of Charge Rate")] // Charge rate approaching upper limit
        [InlineData(-0.2f, false, "Charge Rate is out of range")] // Charge rate below lower limit
        [InlineData(0.9f, false, "Charge Rate is out of range")] // Charge rate above upper limit
        public void IsChargeRateOk_Test(float chargeRate, bool expectedValidity, string expectedMessage)
        {
            string message;
            bool isValid = ChargeRateChecker.isChargeRateOk(chargeRate, out message);

            Assert.Equal(expectedValidity, isValid);
            Assert.Equal(expectedMessage, message);
        }

        [Theory]
        [InlineData(25, 70, 0.7f, true, null)] // All parameters within range
        [InlineData(21, 70, 0.7f, true, "Approaching lower limit of Temperature")] // Warning for low temperature
        [InlineData(25, 79, 0.7f, true, "Approaching upper limit of State of Charge")] // Warning for SoC high
        [InlineData(25, 70, 0.77f, true, "Approaching upper limit of Charge Rate")] // Warning for charge rate
        [InlineData(50, 85, 0.9f, false, "Temperature is out of range")] // Multiple errors, return first error
        public void IsBatteryOk_Test(float temperature, float soc, float chargeRate, bool expectedValidity, string expectedMessage)
        {
            string message;
            bool isValid = BatteryChecker.isBatteryOk(temperature, soc, chargeRate, out message);

            Assert.Equal(expectedValidity, isValid);
            Assert.Equal(expectedMessage, message);
        }
    }
}
