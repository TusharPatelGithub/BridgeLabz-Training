using System;
using System.Diagnostics;
using System.Text;

class StringConcatenationComparison
{
    static void Main()
    {
        int[] operations = { 1000, 10000, 1000000 };

        foreach (int n in operations)
        {
            Console.WriteLine($"\nOperations Count: {n}");

            Stopwatch sw = new Stopwatch();

            // ---------- Using string (O(N^2)) ----------
            string result = "";
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                result += "a";
            }
            sw.Stop();
            Console.WriteLine($"string Time: {sw.ElapsedMilliseconds} ms");

            // ---------- Using StringBuilder (O(N)) ----------
            StringBuilder sb = new StringBuilder();
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                sb.Append("a");
            }
            sw.Stop();
            Console.WriteLine($"StringBuilder Time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
