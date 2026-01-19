using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class LargeFileReadingComparison
{
    static void Main()
    {
        string filePath = "largefile.txt"; // Path to large file (100MB / 500MB)

        Stopwatch sw = new Stopwatch();

        // ---------- Using StreamReader ----------
        sw.Start();
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (reader.ReadLine() != null)
            {
                // Reading line by line
            }
        }
        sw.Stop();
        Console.WriteLine($"StreamReader Time: {sw.ElapsedMilliseconds} ms");

        // ---------- Using FileStream ----------
        sw.Restart();
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[8192]; // 8KB buffer
            int bytesRead;

            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Reading raw bytes
            }
        }
        sw.Stop();
        Console.WriteLine($"FileStream Time: {sw.ElapsedMilliseconds} ms");
    }
}
