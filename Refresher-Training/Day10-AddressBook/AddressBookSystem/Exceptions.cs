using System;
namespace BridgeLabz.AddressBookSystem
{
    public class DuplicateContactException : Exception
    {
        public DuplicateContactException(string message) : base(message) { }
    }
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message) { }
    }
    public class InvalidMenuChoiceException : Exception
    {
        public InvalidMenuChoiceException(string message) : base(message) { }
    }
    public class EmptyInputException : Exception
    {
        public EmptyInputException(string message) : base(message) { }
    }
}
