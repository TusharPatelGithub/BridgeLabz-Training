using System;

class HarshadNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        int originalNumber = number;
        int sum = 0;

        while (number != 0)
        {
            int digit = number % 10;
            sum = sum + digit;
            number = number / 10;
        }

        if (originalNumber % sum == 0)
        {
            Console.WriteLine(originalNumber + " is a Harshad Number");
        }
        else
        {
            Console.WriteLine(originalNumber + " is not a Harshad Number");
        }
    }
}
