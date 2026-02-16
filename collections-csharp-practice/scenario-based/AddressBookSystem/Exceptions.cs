using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.AddressBookSystem
{
    //uc-2
    public class DuplicateContactException : Exception
    {
        public DuplicateContactException(string message) : base(message) { }
    }
    //uc-3 / uc-4
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message) { }
    }
    //menu
    public class InvalidMenuChoiceException : Exception
    {
        public InvalidMenuChoiceException(string message) : base(message) { }
    }
    //input validation
    public class EmptyInputException : Exception
    {
        public EmptyInputException(string message) : base(message) { }
    }
}
