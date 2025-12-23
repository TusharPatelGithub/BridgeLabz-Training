class Multiplication
{
    static void Main(String[] args)
    {
        Console.WriteLine("Enter the number: ");
        int a=Convert.ToInt16(Console.ReadLine());
        int[] arr=new int[4];
        int x=0;
        for(int i=6;i<=9;i++){
            arr[x++]=a*i;
        }
        x=6;
        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(a+" * "+ x++ +  " = "+ arr[i]);
        }
    }
}