using System;

class DataTyeps
{
    static void Main()
    {
        // ================================
        // Primitive Data Types in C#
        // ================================

        int age = 21;                 // Integer type
        double salary = 25000.75;     // Double type
        float percentage = 85.5f;     // Float type
        char grade = 'A';             // Character type
        bool isPassed = true;         // Boolean type
        long population = 1400000000; // Long type

        Console.WriteLine("Primitive Data Types:");
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Salary: " + salary);
        Console.WriteLine("Percentage: " + percentage);
        Console.WriteLine("Grade: " + grade);
        Console.WriteLine("Is Passed: " + isPassed);
        Console.WriteLine("Population: " + population);

        Console.WriteLine("\n-----------------------------");

        // ================================
        // Type Casting
        // ================================

        // 1. Implicit Type Casting (Automatic)
        // smaller type -> larger type
        int number = 10;
        double convertedNumber = number; // int to double

        Console.WriteLine("Implicit Type Casting:");
        Console.WriteLine("Int value: " + number);
        Console.WriteLine("Converted to Double: " + convertedNumber);

        Console.WriteLine("\n-----------------------------");

        // 2. Explicit Type Casting (Manual)
        // larger type -> smaller type
        double price = 99.99;
        int roundedPrice = (int)price; // double to int (decimal part lost)

        Console.WriteLine("Explicit Type Casting:");
        Console.WriteLine("Double value: " + price);
        Console.WriteLine("Converted to Int: " + roundedPrice);

        Console.WriteLine("\n-----------------------------");

        // 3. Type Casting using Convert class
        double marks = 88.6;
        int finalMarks = Convert.ToInt32(marks);

        Console.WriteLine("Type Casting using Convert:");
        Console.WriteLine("Marks (double): " + marks);
        Console.WriteLine("Final Marks (int): " + finalMarks);
    }
}
