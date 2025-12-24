class ReminderQuotient

{
    static void output(int a, int b)
    {
        Console.WriteLine("Reminder is: "+a%b);
        Console.WriteLine("Quotient is: "+a/b);
    }
    static void Main(String[] args){

        Console.WriteLine("Enter the first Value: ");
        int a=Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Enter second Value: ");
        int b=Convert.ToInt16(Console.ReadLine());
        output(a,b);
    }
}