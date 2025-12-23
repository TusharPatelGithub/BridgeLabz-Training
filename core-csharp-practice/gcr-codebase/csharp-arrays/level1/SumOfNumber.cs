class SumOfNumber
{
    static void Main(String[] args)
    {
        int sum=0;
        int[] arr=new int[10];
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i]=Convert.ToInt16(Console.ReadLine());
            if(arr[i]<1) break;
            else
            {
                sum=sum+arr[i];
            }
        }
        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine( arr[i]+" " );
        }
        Console.WriteLine("sum of all number: "+ sum);
    }
}