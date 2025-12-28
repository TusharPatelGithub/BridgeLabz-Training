using System;

class IndexOut
{
    static void Main()
    {
        ShowException();
    }

    static void ShowException()
    {
        try
        {
            string text = "Hello";
            Console.WriteLine(text[10]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Exception Caught: " + ex.Message);
        }
    }
}
