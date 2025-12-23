class Factors
{
    static void Main(String[] args)
    {
        Console.WriteLine("Enter a number: ");
        int[] arr=new int[50];
        int a=Convert.ToInt16(Console.ReadLine());
        int j=0;
        for(int i = 1; i<=a; i++)
        {
            if (a % i == 0)
            {
                arr[j++]=i;
            }
        }Console.WriteLine("Factors are: ");
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i]>0) Console.Write(arr[i]+" ");
            
        }
    }
}