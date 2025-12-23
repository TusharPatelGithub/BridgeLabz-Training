using System;

class Fizzbuzz
{
    static void Main(String[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Please enter a positive integer");
            return;
        }

        string[] results = new string[number];

        for (int i = 1; i <= number; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
                results[i - 1] = "FizzBuzz";
            else if (i % 3 == 0)
                results[i - 1] = "Fizz";
            else if (i % 5 == 0)
                results[i - 1] = "Buzz";
            else
                results[i - 1] = i.ToString();
        }

        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine("Position " + (i + 1) + " = " + results[i]);
        }
    }
}
