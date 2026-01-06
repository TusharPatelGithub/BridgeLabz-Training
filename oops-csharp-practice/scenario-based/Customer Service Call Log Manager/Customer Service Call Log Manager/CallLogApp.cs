using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Service_Call_Log_Manager
{
    class CallLogApp
    {
        static void Main()
        {
            CallLogManager manager = new CallLogManager(10);

            manager.AddCallLog(new CallLog("123456789", "Network issue reported", DateTime.Now.AddHours(-5)));
            manager.AddCallLog(new CallLog("0876543", "Billing related query", DateTime.Now.AddHours(-2)));
            manager.AddCallLog(new CallLog("123456789", "Internet not working", DateTime.Now));
            manager.SearchByKeyword("network");
            DateTime startTime = DateTime.Now.AddHours(-3);
            DateTime endTime = DateTime.Now;

            manager.FilterByTime(startTime, endTime);
        }
    }
}
