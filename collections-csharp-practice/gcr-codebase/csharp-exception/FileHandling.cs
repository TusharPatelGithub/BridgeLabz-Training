using System;
using System.IO;
class FileHandling{
    public static void Main(){
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine()!;
        try{
            using StreamReader reader = new StreamReader(fileName);
            Console.WriteLine("First Line:");
            Console.WriteLine(reader.ReadLine());
        }
        catch (IOException){
            Console.WriteLine("Error reading file");
        }
    }
}