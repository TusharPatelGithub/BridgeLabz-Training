using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Service_Call_Log_Manager
{
    class CallLog
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public CallLog(string phoneNumber, string message, DateTime timestamp)
        {
            PhoneNumber = phoneNumber;
            Message = message;
            Timestamp = timestamp;
        }

        public void Display()
        {
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Time: {Timestamp}");
            Console.WriteLine("-----------------------");
        }
    }
}
