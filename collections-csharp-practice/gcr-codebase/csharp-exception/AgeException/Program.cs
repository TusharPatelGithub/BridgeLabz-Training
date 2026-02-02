using System;
class Program{
    static void ValidateAge(int age){
        if (age < 18)
            throw new InvalidAgeException("Age must be 18 or above");
    }
    public static void Main(){
        try{
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine()!);
            ValidateAge(age);
            Console.WriteLine("Access granted!");
        }
        catch (InvalidAgeException ex){
            Console.WriteLine(ex.Message);
        }
    }
}