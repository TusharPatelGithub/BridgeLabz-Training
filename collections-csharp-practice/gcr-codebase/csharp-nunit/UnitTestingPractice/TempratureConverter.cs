namespace UtilityConverters
{
    public class TemperatureConverter
    {
        // Formula: (°C × 9/5) + 32
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // Formula: (°F − 32) × 5/9
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
