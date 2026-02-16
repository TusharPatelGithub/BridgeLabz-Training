using System;
using System.IO;
using System.Diagnostics;
class BufferedStreamDemo
{
    static void Main()
    {
        string folder = @"gcr-codebase\collections-csharp-streams";
        string src = Path.Combine(folder, "buffered.txt");
        string dest = Path.Combine(folder, "buffered-copy.txt");
        File.WriteAllText(src, new string('A', 5_000_000));
        Stopwatch sw = Stopwatch.StartNew();
        using FileStream fr = new FileStream(src, FileMode.Open);
        using FileStream fw = new FileStream(dest, FileMode.Create);
        using BufferedStream br = new BufferedStream(fr);
        using BufferedStream bw = new BufferedStream(fw);
        byte[] buffer = new byte[4096];
        int bytes;
        while ((bytes = br.Read(buffer, 0, buffer.Length)) > 0)
            bw.Write(buffer, 0, bytes);
        sw.Stop();
        Console.WriteLine("Buffered Time: " + sw.ElapsedMilliseconds);
    }
}