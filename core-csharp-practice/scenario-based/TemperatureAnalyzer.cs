using System.Numerics;

class TemperatureAnalyzer
{
    static void hotcool(float[,] arr)
    {
        float sum=0;
        float max=arr[0,0];
        float min=arr[0,0];
        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < 24; j++)
            {
                if (arr[i, j] > max)
                {
                    max=arr[i,j];
                }
                if (arr[i, j] < min)
                {
                    min=arr[i,j];
                }
                sum=sum+arr[i,j];
            }
           
        }
         Console.WriteLine("Max temp is "+max);
            Console.WriteLine("Min temp is "+min);
            Console.WriteLine("Average temperature is: "+sum/24);
    }
    static void Main(string[] args)
    {
        float[,] arr=new float[7,24];
        Console.WriteLine("Enter the temperature: ");
        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < 24; j++)
            {
                arr[i,j]=Convert.ToSingle(Console.ReadLine());
            }
        }
        hotcool(arr);
    }
}