using System;
class RailwaySystem
{
    private Passenger[] passengers;
    private int count;
    private int nextPnr;
    public RailwaySystem(int size)
    {
        passengers = new Passenger[size];
        count = 0;
        nextPnr = 4301;
    }
    public void RegisterPassenger()
    {
        if (count >= passengers.Length)
        {
            Console.WriteLine("passenger limit reached");
            return;
        }
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Source Station: ");
        string source = Console.ReadLine();
        Console.Write("Enter Destination Station: ");
        string destination = Console.ReadLine();
        Console.WriteLine("Enter distance you have to tavel: ");
        double dis = Convert.ToDouble(Console.WriteLine());
        double price = dis*2.76;
        if (age >= 60)
        {
            Console.WriteLine("Discount Applied for senior passenger");
            price = price/1.89;
        }
        passengers[count] = new Passenger(nextPnr, name, age, source, destination,dis,price);
        Console.WriteLine($"Passenger registered successfully. PNR Number: {nextPnr}");
        nextPnr++;
        count++;
    }
    public void DisplayPassenger()
    {
        if (count == 0)
        {
            Console.WriteLine("No passengers record");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(passengers[i]);
        }
    }
    public void SortByPnr()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if (passengers[j].pnrNumber > passengers[j + 1].pnrNumber)
                {
                    Passengers temp = passengers[j];
                    passengers[j] = passengers[j + 1];
                    passengers[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Passengers sorted.");
    }
    public void SearchByPnr(int pnr)
    {
        int low = 0;
        int high = count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (passengers[mid].pnrNumber == pnr)
            {
                Console.WriteLine("Passenger found.");
                Console.WriteLine(passengers[mid]);
                return;
            }
            else if (passengers[mid].pnrNumber < pnr)
            {
                low=mid+1;
            }
            else
            {
                high = mid-1;
            }
        }
        Console.WriteLine("No passenger with this pnr found.");
    }
}