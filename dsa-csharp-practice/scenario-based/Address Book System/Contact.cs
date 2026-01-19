using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace AddressBookSystem
{
    public class Contact : ContactBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Contact(string firstName, string lastName, string address,
                       string city, string state, string zip,
                       string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj is Contact other)
                return FirstName == other.FirstName &&
                       LastName == other.LastName;
            return false;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        // UC10 requirement
        public override string ToString()
        {
            return $"{FirstName} {LastName} | {City} | {State}";
        }

        public override void DisplayContact()
        {
            Console.WriteLine(ToString());
        }
    }
}
