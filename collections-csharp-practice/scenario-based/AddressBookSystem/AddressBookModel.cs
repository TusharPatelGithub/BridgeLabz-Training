using System;
namespace BridgeLabz.AddressBookSystem
{
        //model class demonstrating encapsulation
        public class AddressBookModel
        {
            //UC1-contact details
            private string firstName;
            private string lastName;
            private string address;
            private string city;
            private string state;
            private string zip;
            private string phoneNumber;
            private string email;
            // UC0 - Welcome Message (Private)
            private string welcomeMessage;
            // Public Properties
            public string FirstName { get { return firstName; } set { firstName = value; } }
            public string LastName { get { return lastName; } set { lastName = value; } }
            public string Address { get { return address; } set { address = value; } }
            public string City { get { return city; } set { city = value; } }
            public string State { get { return state; } set { state = value; } }
            public string Zip { get { return zip; } set { zip = value; } }
            public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
            public string Email { get { return email; } set { email = value; } }
            public string WelcomeMessage { get { return welcomeMessage; } set { welcomeMessage = value; } }
            // UC1 - Input Method
            public void AddContact()
            {
                Console.Write("Enter First Name: ");
            FirstName = ReadRequiredInput("First Name");
                Console.Write("Enter Last Name: ");
            LastName = ReadRequiredInput("LAst Name");
                Console.Write("Enter Address: ");
            Address = ReadRequiredInput("Address: ");
                Console.Write("Enter City: ");
            City = ReadRequiredInput("City");
                Console.Write("Enter State: ");
                State = ReadRequiredInput("State");
                Console.Write("Enter Zip: ");
            Zip = ReadRequiredInput("Zip");
                Console.Write("Enter Phone Number: ");
            PhoneNumber = ReadRequiredInput("Phone Number");
                Console.Write("Enter Email: ");
            Email = ReadRequiredInput("Email");
                Console.WriteLine("\nContact Created Successfully\n");
            }
        //uc7-ovveride equals for duplicate check
        public override bool Equals(object obj) 
        {
            if (obj == null || !(obj is AddressBookModel))
                return false;
            AddressBookModel other = (AddressBookModel)obj;
            return this.FirstName.Equals(other.FirstName, StringComparison.OrdinalIgnoreCase)
                && this.LastName.Equals(other.LastName, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode() //have to override this because we overrode Equals.this gives hash code irrespective of the case of letters
        {
            return (FirstName + LastName).ToLower().GetHashCode();
        }
        //uc11 overide toString to write person details
        public override string ToString()
        {
            return $"Name  : {FirstName} {LastName}\n" +
                $"City: {City}\n" +
                $"State: {State}\n" +
                $"Phone: {PhoneNumber}\n" +
                $"Email: {Email}\n";
        }
        //exception added
        private string ReadRequiredInput(string fieldName)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new EmptyInputException($"{fieldName} cannot be empty");

            return input;
        }
    }
}
