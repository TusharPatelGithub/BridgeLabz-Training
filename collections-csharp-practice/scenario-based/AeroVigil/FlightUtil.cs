using System;
using System.Text.RegularExpressions;
//implements flight validation and fuel calculation operations
public class FlightUtil : IFlightUtil
{
    //validates flight number format (FL-XXXX)
    public bool ValidateFlightNumber(string flightNumber)
    {
        string pattern = @"^FL-[1-9][0-9]{3}$";
        if (!Regex.IsMatch(flightNumber, pattern))
        {
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");
        }
        return true;
    }
    //validates flight name against allowed airline list
    public bool ValidateFlightName(string flightName)
    {
        if (!(flightName.Equals("SpiceJet", StringComparison.OrdinalIgnoreCase) ||
            flightName.Equals("Vistara", StringComparison.OrdinalIgnoreCase) ||
            flightName.Equals("IndiGo", StringComparison.OrdinalIgnoreCase) ||
            flightName.Equals("Air Arabia", StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidFlightException($"The flight name {flightName} is invalid");
        }
        return true;
    }
    //validates passenger count based on flight capacity
    public bool ValidatePassengerCount(int passengerCount, string flightName)
    {
        int maxCapacity = flightName switch
        {
            "SpiceJet" => 396,
            "Vistara" => 615,
            "IndiGo" => 230,
            "Air Arabia" => 130,
            _ => 0
        };
        if (passengerCount <= 0 || passengerCount > maxCapacity)
        {
            throw new InvalidFlightException(
                $"The passenger count {passengerCount} is invalid for {flightName}");
        }

        return true;
    }
    //calculates fuel required to fill the tank
    public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuelCapacity = flightName switch
        {
            "SpiceJet" => 200000,
            "Vistara" => 300000,
            "IndiGo" => 250000,
            "Air Arabia" => 150000,
            _ => 0
        };
        if (currentFuelLevel < 0 || currentFuelLevel > maxFuelCapacity)
        {
            throw new InvalidFlightException($"Invalid fuel level for {flightName}");
        }
        return maxFuelCapacity - currentFuelLevel;
    }
}
