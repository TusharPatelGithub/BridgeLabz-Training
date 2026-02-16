using System;
using System.IO;
class FileRead{
    public static void Main(){
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine()!;
        try{
            string content = File.ReadAllText(fileName);
            Console.WriteLine("File Content:");
            Console.WriteLine(content);
        }
        catch (IOException){
            Console.WriteLine("File not found");
        }
    }
}