using System;
class ArrayOperation{
    public static void Main(){
        try{
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine()!);
            int[] arr = new int[size];
            for (int i = 0; i < size; i++){
                Console.Write($"Enter element {i}: ");
                arr[i] = int.Parse(Console.ReadLine()!);
            }
            Console.Write("Enter index to access: ");
            int index = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Value at index {index}: {arr[index]}");
        }
        catch (IndexOutOfRangeException){
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException){
            Console.WriteLine("Array is not initialized!");
        }
        catch (FormatException){
            Console.WriteLine("Invalid input format!");
        }
    }
}