using System;
using System.IO;
class FileHandling
{
    static void Main()
    {
        string folder = @"gcr-codebase\collections-csharp-streams";
        string source = Path.Combine(folder, "source.txt");
        string dest = Path.Combine(folder, "destination.txt");
        try
        {
            if (!File.Exists(source))
            {
                Console.WriteLine("Source file does not exist");
                return;
            }
            using FileStream fr = new FileStream(source, FileMode.Open, FileAccess.Read);
            using FileStream fw = new FileStream(dest, FileMode.Create, FileAccess.Write);
            byte[] buffer = new byte[1024];
            int bytes;
            while ((bytes = fr.Read(buffer, 0, buffer.Length)) > 0)
                fw.Write(buffer, 0, bytes);
            Console.WriteLine("File copied");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}