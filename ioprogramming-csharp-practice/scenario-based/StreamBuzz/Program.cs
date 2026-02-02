using System;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        EngagementService service = new EngagementService();
        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreatorStats creator = new CreatorStats();
                    Console.WriteLine("Enter Creator Name:");
                    creator.CreatorName = Console.ReadLine();
                    creator.WeeklyLikes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = double.Parse(Console.ReadLine());
                    }
                    service.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully");
                    break;
                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());
                    Dictionary<string, int> result =
                        service.GetTopPostCounts(
                            CreatorStats.EngagementBoard, threshold);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;
                case 3:
                    double avg = service.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {avg}");
                    break;
                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;
            }
        }
    }
}
