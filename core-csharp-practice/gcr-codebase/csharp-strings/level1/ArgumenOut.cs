using System;

class ArgumentOut
{
    static void Main()
    {
        try
        {
            string text = "Hello";
            string result = text.Substring(4, 5);
            Console.WriteLine(result);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Exception Caught: " + ex.Message);
        }
    }
}
