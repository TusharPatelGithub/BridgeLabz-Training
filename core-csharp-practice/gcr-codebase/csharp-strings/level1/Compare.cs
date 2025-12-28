class Compare
{
    static void Main(String[] args)
    {
        Console.WriteLine("Enter a first string: ");
        string s=Console.ReadLine()!;
        Console.WriteLine("Enter a first string: ");
        string s1=Console.ReadLine()!;
        for(int i = 0; i < s.Length; i++)
        {
            if (s[i] != s1[i])
            {
                Console.WriteLine("false");
            }
        }
    }
}