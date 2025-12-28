using System;

class Format
{
    static void Main()
    {
        try
        {
            string value = "abc";
            int number = int.Parse(value);
            Console.WriteLine(number);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Exception Caught: " + ex.Message);
        }
    }
}
