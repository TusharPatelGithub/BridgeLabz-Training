using System;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        VesselUtil util = new VesselUtil();
        Console.WriteLine("Enter the number of vessels to be added");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter vessel details");
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] data = input.Split(':');
            Vessel vessel = new Vessel(
                data[0],
                data[1],
                double.Parse(data[2]),
                data[3]
            );
            util.AddVesselPerformance(vessel);
        }
        Console.WriteLine("Enter the Vessel Id to check speed");
        string searchId = Console.ReadLine();
        Vessel found = util.GetVesselById(searchId);
        if (found != null)
        {
            Console.WriteLine(
                $"{found.VesselId}|{found.VesselName}|{found.VesselType}|{found.AverageSpeed} knots");
        }
        else
        {
            Console.WriteLine($"Vessel Id {searchId} not found");
        }
        Console.WriteLine("High performance vessels are");
        List<Vessel> highPerf = util.GetHighPerformanceVessels();
        foreach (Vessel v in highPerf)
        {
            Console.WriteLine(
                $"{v.VesselId}|{v.VesselName}|{v.VesselType}|{v.AverageSpeed} knots");
        }
    }
}
