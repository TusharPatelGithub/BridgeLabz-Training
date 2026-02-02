using System;
//custom exception class used to handle invalid flight details
public class InvalidFlightException : Exception
{
    //constructor that passes the error message to the base exception class
    public InvalidFlightException(string message) : base(message)
    {
    }
}
