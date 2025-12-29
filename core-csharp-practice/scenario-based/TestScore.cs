class TestScore

{
    static void AboveAverage(int[] score)
    {
        double sum=0;
        for(int i = 0; i < score.Length; i++)
        {
            sum=sum+score[i];
        }
        double avg=sum/score.Length;
        Console.WriteLine("Above average marks are: ");
        for(int i = 0; i < score.Length; i++)
        {
            if (score[i] > avg)
            {
                Console.Write(score[i]+" ");
            }
        }
    }
    static void AverageScore(int[] score)
    {
        double sum=0;
        for(int i = 0; i < score.Length; i++)
        {
            sum=sum+score[i];
        }
        Console.WriteLine("Average score is: "+ sum/score.Length);
    }
    static void HighestLowest(int[] score)
    {
        int max=score[0];
        int min=score[0];
        for(int i = 0; i < score.Length; i++)
        {
            if (score[i] > max)
            {
                max=score[i];
            }
            if (score[i] < min)
            {
                min=score[i];
            }
        }
        Console.WriteLine("Maximum score is "+max);
        Console.WriteLine("Minimum score is "+min);
    }
    static void test(int[] score)
    {
        Console.WriteLine("Enter your choice: \n 1: Calculate and display the average score. \n 2:  Find and display the highest and lowest scores.\n 3:  Identify and display the scores above the average. ");
        int choice=Convert.ToInt16(Console.ReadLine());
        switch (choice)
        {
            case 1: AverageScore(score);
            break;
            case 2: HighestLowest(score);
            break;
            case 3: AboveAverage(score);
            break;
            default: Console.WriteLine("Enter valid input: ");
            break;

        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of student ");
        int number=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Enter the "+ number+" student score: ");
        int[] score=new int[number];
        for(int i = 0; i < score.Length; i++)
        {
            score[i]=Convert.ToInt16(Console.ReadLine());
            if (score[i] < 0 && score[i] > 100)
            {
                Console.WriteLine("Enter a valid number: ");
            }
        }
        for(int i = 0; i < score.Length; i++)
        {
            if (score[i] < 0 || score[i] > 100)
            {
                Console.WriteLine("Enter a valid score: ");
                return;
            }
        }
        
        test(score);
    }
}