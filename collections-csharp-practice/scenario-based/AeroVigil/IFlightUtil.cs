//interface that defines flight validation and fuel calculation contracts
public interface IFlightUtil
{
    //validates the flight number format
    bool ValidateFlightNumber(string flightNumber);
    //validates the flight name against allowed airlines
    bool ValidateFlightName(string flightName);
    //validates passenger count based on flight capacity
    bool ValidatePassengerCount(int passengerCount, string flightName);
    //calculates the fuel required to fill the tank
    double CalculateFuelToFillTank(string flightName, double currentFuelLevel);
}

