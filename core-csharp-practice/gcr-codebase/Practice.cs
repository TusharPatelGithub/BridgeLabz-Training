using System;
using System.ComponentModel.Design.Serialization;
class Practice
{
    static void Main(String[] mains)
    {
     Console.WriteLine("Choose number: ");
     int a=Convert.ToInt16(Console.ReadLine());
        switch (a)
        {
            case 1: Console.WriteLine("Sunday");
            break;
            case 2: Console.WriteLine("Monday");
            break;
            case 3: Console.WriteLine("Tuesday");
            break;
            default: Console.WriteLine("Enter valid date: ");
            break;
        }
        
    }
}