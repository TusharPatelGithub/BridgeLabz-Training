using System;
class InsufficientFundsException : Exception{
    public InsufficientFundsException(string message) : base(message) { }
}