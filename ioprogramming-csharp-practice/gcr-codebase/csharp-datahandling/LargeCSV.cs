using System.IO;
class LargeCSV
{
    static void Main()
    {
        int count = 0;
        foreach (var line in File.ReadLines("students.csv"))
            if (++count % 100 == 0)
                System.Console.WriteLine($"Processed {count}");
    }
}
