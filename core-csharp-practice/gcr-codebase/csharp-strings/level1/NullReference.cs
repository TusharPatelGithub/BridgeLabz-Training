using System;

class NullReference
{
    static void Main()
    {
        ShowException();
    }
    static void ShowException()
    {
        try
        {
            string text = null;
            Console.WriteLine(text.Length);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Exception Caught: " + ex.Message);
        }
    }
}
