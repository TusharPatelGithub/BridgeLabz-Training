using System;
//application entry point that triggers audit log generation
class Program
{
    static void Main()
    {
        EventTrackerEngine tracker = new EventTrackerEngine();
        string jsonLogs = tracker.GenerateAuditLogs();
        Console.WriteLine("=== AUDIT LOG OUTPUT (JSON) ===");
        Console.WriteLine(jsonLogs);
    }
}
