using System;
class Vote
{
    public static string[] candidateName = new string[100];
    public static int[] voteCountPerCandidate = new int[100];
    public static int number = 0;
    public static void Main(String[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to vote counting system.");
            Console.WriteLine("1. Admin.");
            Console.WriteLine("2. Voter.");
            Console.WriteLine("3. Exit.");
            Console.Write("Enter an option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Authenticate();
                    break;
                case "2":
                    Voter();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    public static void Voter()
    {
        if (number == 0)
        {
            Console.WriteLine("No candidates found. Contact Admin.");
            return;
        }
        Console.WriteLine("Please verify your age to vote.");
        Console.Write("Please enter your age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Not valid age");
            return;
        }
        if (age < 18)
        {
            Console.WriteLine("You are not eligible to vote.");
            return;
        }
        Console.Write("Choose your candidate: ");
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"{i + 1}. {candidateName[i]}");
        }
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > number)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }
        voteCountPerCandidate[choice - 1]++;
        Console.WriteLine("Your vote is recorded.Thank you!");

    }
    public static void Authenticate()
    {
        string adminPassword = "admin123";
        Console.WriteLine("Enter admin password.");
        string input = Console.ReadLine();
        if (input == adminPassword)
        {
            AdminMenu();
        }
        else
        {
            Console.WriteLine("Invalid credentials");
        }
    }
    public static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Enter No. users.");
            Console.WriteLine("2. Enter candidates names: ");
            Console.WriteLine("3. Compute result");
            Console.WriteLine("4. Logout");
            Console.Write("Enter a choice: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("please enter a no. of voters participating in election.");
                    number = Convert.ToInt32(Console.ReadLine());
                    break;
                case "2":
                    if (number == 0)
                    {
                        Console.WriteLine("Please enter no. of candidates first");
                        break;
                    }
                    Console.WriteLine("Enter candidates name: ");
                    for (int i = 0; i < number; i++)
                    {
                        candidateName[i] = Console.ReadLine();
                    }
                    break;
                case "3":
                    if (number == 0)
                    {
                        Console.WriteLine("Please enter no. of candidates first");
                        break;
                    }
                    int winner = 0;
                    for (int i = 1; i < number; i++)
                    {
                        if (voteCountPerCandidate[i] > voteCountPerCandidate[winner])
                        {
                            winner = i;
                        }
                    }
                    Console.WriteLine("Winner Candidate is: " + candidateName[winner]);
                    Console.WriteLine("Candidate has total of votes: " + voteCountPerCandidate[winner]);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }
        }
    }
}