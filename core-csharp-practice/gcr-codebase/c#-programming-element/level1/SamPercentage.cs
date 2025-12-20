using System;
class SamPercentage {
    static void Main(string[] args)
    {
        int mathMarks = 94;
        int phyMarks = 95;
        int cheMarks = 96;
        double avgPercent = ((mathMarks + phyMarks + cheMarks) / 300.0) * 100;
        Console.WriteLine("Sam’s average mark in PCM is" + avgPercent);
    }
    
}