using System;
using System.IO;
class BinaryStream
{
    static void Main()
    {
        string file = @"gcr-codebase\collections-csharp-streams\student.dat";
        using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
        {
            bw.Write(101);
            bw.Write("Sam");
            bw.Write(8.9);
        }
        using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
        {
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadDouble());
        }
    }
}