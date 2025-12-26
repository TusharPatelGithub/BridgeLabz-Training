using System;

public class StudentVoteChecker
{
    public static bool CanStudentVote(int age)
    {
        if (age < 0)
            return false;

        if (age >= 18)
            return true;

        return false;
    }

    public static void Main()
    {
        int[] ages = new int[10];

        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write($"Enter age of student {i + 1}: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            bool canVote = CanStudentVote(ages[i]);

            if (canVote)
                Console.WriteLine("Eligible to vote");
            else
                Console.WriteLine("Not eligible to vote");
        }
    }
}
