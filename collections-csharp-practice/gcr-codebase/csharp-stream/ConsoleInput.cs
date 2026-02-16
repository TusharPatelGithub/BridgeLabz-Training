using System;
using System.IO;
class ConsoleInput
{
    static void Main()
    {
        string path = @"gcr-codebase\collections-csharp-streams\user.txt";
        try
        {
            using StreamWriter sw = new StreamWriter(path);
            Console.Write("Name: ");
            sw.WriteLine("Name: " + Console.ReadLine());
            Console.Write("Age: ");
            sw.WriteLine("Age: " + Console.ReadLine());
            Console.Write("Language: ");
            sw.WriteLine("Language: " + Console.ReadLine());
            Console.WriteLine("Saved");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}