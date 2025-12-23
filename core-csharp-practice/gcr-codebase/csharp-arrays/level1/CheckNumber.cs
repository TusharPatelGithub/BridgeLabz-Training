using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

class CheckNumber
{
    static void Main(String[] args)
    {
        int[] arr=new int[5];
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i]=Convert.ToInt16(Console.ReadLine());
        }
        for(int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
            {
                if (arr[i] % 2 == 0)
                {
                     Console.WriteLine(arr[i]+ " is a positive Even integer: ");
                }
                else
                {
                    Console.WriteLine(arr[i]+" is a positive odd integer: ");
                }
            }
            else if (arr[i] < 0)
            {
                Console.WriteLine(arr[i]+ " is a negative integer: ");
            }
            else
            {
                Console.WriteLine(arr[i]+" is a zero: ");
            }
        }
        if (arr[0] > arr[arr.Length - 1])
        {
            Console.WriteLine("first number is larger than last number: ");
        }else if (arr[0] < arr[arr.Length - 1])
        {
            Console.WriteLine("Last number is larger than first number: ");
        }
        else
        {
            Console.WriteLine ("First and Last number is same: ");
        }

    }
}