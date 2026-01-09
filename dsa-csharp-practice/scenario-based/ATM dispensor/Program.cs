using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Scenario A (All Notes Available)");
        int[] notesA = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
        ATMDispenser.Dispense(880, notesA);

        Console.WriteLine("\nScenario B (₹500 Removed)");
        int[] notesB = { 200, 100, 50, 20, 10, 5, 2, 1 };
        ATMDispenser.Dispense(880, notesB);

        Console.WriteLine("\nScenario C (Fallback Case)");
        ATMDispenser.Dispense(885, notesB);
    }
}
