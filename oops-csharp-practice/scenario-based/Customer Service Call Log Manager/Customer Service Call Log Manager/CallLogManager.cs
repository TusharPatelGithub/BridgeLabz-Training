using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Service_Call_Log_Manager
{
    class CallLogManager
    {
        private CallLog[] logs;
        private int count;

        public CallLogManager(int size)
        {
            logs = new CallLog[size];
            count = 0;
        }
        public void AddCallLog(CallLog log)
        {
            if (count < logs.Length)
            {
                logs[count++] = log;
            }
            else
            {
                Console.WriteLine("Call log storage is full.");
            }
        }
        public void SearchByKeyword(string keyword)
        {
            Console.WriteLine($"Searching for keyword: {keyword}");
            for (int i = 0; i < count; i++)
            {
                if (logs[i].Message.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    logs[i].Display();
                }
            }
        }
        public void FilterByTime(DateTime start, DateTime end)
        {
            Console.WriteLine($"Logs between {start} and {end}");
            for (int i = 0; i < count; i++)
            {
                if (logs[i].Timestamp >= start && logs[i].Timestamp <= end)
                {
                    logs[i].Display();
                }
            }
        }
    }

}
