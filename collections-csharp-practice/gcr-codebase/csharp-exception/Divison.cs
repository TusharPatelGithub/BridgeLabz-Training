using System;
class Division{
    public static void Main(){
        try{
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine()!);
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Result: " + (a / b));
        }
        catch (DivideByZeroException){
            Console.WriteLine("Cannot divide by zero");
        }
        catch (FormatException){
            Console.WriteLine("Invalid numeric input");
        }
    }
}