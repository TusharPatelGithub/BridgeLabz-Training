class Fact
{
    static int sumSquare(int[] arr)
    {
        int add1=0;
        for(int i = 0; i < arr.Length; i++)
        {
            add1+=arr[i]*arr[i];
        }
        return add1;
    }
    static int sum(int[] arr)
    {
        int add=0;
        for(int i = 0; i < arr.Length; i++)
        {
            add+=arr[i];
        }
        return add;
    }
    static void facto(int a,int[] arr){
    
    int j=0;
    for(int i = 1; i <= a; i++)
        {
            if (a % i == 0)
            {
                arr[j++]=i;
            }
        }
        Console.Write("Factorial are: ");
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i]!=0) Console.Write(arr[i]+" ");    
        }
    }
    static void Main(string [] args)
    {
        Console.WriteLine("Enter the number:");
        int a=Convert.ToInt16(Console.ReadLine());  
        int []arr=new int [30]; 
        facto(a,arr);
        Console.WriteLine();
        Console.WriteLine("Sum of all factors: "+sum(arr));
        Console.WriteLine("Sum of all square factors: "+sumSquare(arr));
    }
}