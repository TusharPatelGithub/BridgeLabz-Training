class StudentAge
{
    static void Main(String[] args)
    {
        int[] arr=new int[10];
        for(int i = 0; i < arr.Length; i++)
        {
          arr[i]=Convert.ToInt16(Console.ReadLine());
        }
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 18)
            {
                Console.WriteLine(arr[i]+ " can vote: ");
            }
            else
            {
                Console.WriteLine(arr[i]+" cannot vote: ");
            }
        }
    }
}