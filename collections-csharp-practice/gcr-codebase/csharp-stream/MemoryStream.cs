using System;
using System.IO;
class MemoryStreamDemo
{
    static void Main()
    {
        string folder = @"gcr-codebase\collections-csharp-streams";
        byte[] bytes = File.ReadAllBytes(Path.Combine(folder, "image.jpg"));
        using MemoryStream ms = new MemoryStream(bytes);
        File.WriteAllBytes(Path.Combine(folder, "05-image-copy.jpg"), ms.ToArray());
        Console.WriteLine("Image copied");
    }
}