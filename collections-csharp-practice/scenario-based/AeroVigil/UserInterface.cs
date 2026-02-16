using System;
//handles user interaction and program execution
public class UserInterface
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter flight details");
            string input = Console.ReadLine();
            string[] details = input.Split(':');
            string flightNumber = details[0];
            string flightName = details[1];
            int passengerCount = int.Parse(details[2]);
            double currentFuelLevel = double.Parse(details[3]);
            // Interface reference promotes loose coupling
            IFlightUtil flightUtil = new FlightUtil();
            flightUtil.ValidateFlightNumber(flightNumber);
            flightUtil.ValidateFlightName(flightName);
            flightUtil.ValidatePassengerCount(passengerCount, flightName);
            double fuelRequired = flightUtil.CalculateFuelToFillTank(flightName, currentFuelLevel);
            Console.WriteLine($"Fuel required to fill the tank: {fuelRequired} liters");
        }
        catch (InvalidFlightException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception)
        {
        }
    }
}
