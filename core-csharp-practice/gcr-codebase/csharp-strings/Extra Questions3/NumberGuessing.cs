using System;

class NumberGuessingGame
{
    static void Main()
    {
        Console.WriteLine("Think of a number between 1 and 100.");
        Console.WriteLine("I will try to guess it!");
        Console.WriteLine("Respond with: high, low, or correct.\n");
        int low = 1;
        int high = 100;
        bool guessed = false;
        while (!guessed)
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine($"Is your number {guess}? (high / low / correct)");

            string response = GetUserFeedback();

            if (response == "correct")
            {
                Console.WriteLine("Yay! I guessed your number correctly.");
                guessed = true;
            }
            else if (response == "high")
            {
                high = guess - 1;
            }
            else if (response == "low")
            {
                low = guess + 1;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
    static int GenerateGuess(int low, int high)
    {
        return (low + high) / 2;
    }

    static string GetUserFeedback()
    {
        return Console.ReadLine()?.ToLower() ?? "";
    }
}
