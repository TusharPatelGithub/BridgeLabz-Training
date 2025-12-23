class MeanHeight
{
    static void Main(String[] args)
    {
        int mean=0;
        int sum=0;
        int[] arr=new int[11];
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i]=Convert.ToInt16(Console.ReadLine());
        }
        for(int i = 0; i < arr.Length; i++)
        {
            sum=sum+arr[i];
        }
        mean=sum/arr.Length;
        Console.WriteLine("Mean height of all player is "+mean );
    }
}