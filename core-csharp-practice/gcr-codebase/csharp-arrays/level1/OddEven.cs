class OddEven
{
    static void Main(String[] args)
    {
        Console.WriteLine("Enter the number: ");
        int a=Convert.ToInt16(Console.ReadLine());
        int[] oddnum=new int[a/2+1];
        int[] evennum=new int[a/2+1];
        int z=0;
        int b=0;
        for(int i = 1 ;i <= a; i++)
        {
            if (i % 2 == 1)
            {
                oddnum[z++]=i;
            }
            else
            {
                evennum[b++]=i;
            }
        }
        Console.Write("Odds numbers are: ");
        for(int i = 0; i < oddnum.Length; i++)
        {
            Console.Write(oddnum[i]+" ");
        }
        Console.WriteLine();
        Console.Write("Even numbers are: ");

        for(int i = 0; i < evennum.Length; i++)
        {
            Console.Write(evennum[i]+" ");
        }
    }
}