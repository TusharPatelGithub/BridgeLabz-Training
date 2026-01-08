using System;

class Program
{
    static void Main()
    {
        TicketReservationSystem system = new TicketReservationSystem();

        system.AddTicket(101, "Tushar", "Inception", "A1");
        system.AddTicket(102, "Rahul", "Inception", "A2");
        system.AddTicket(103, "Neha", "Interstellar", "B1");

        Console.WriteLine("All Booked Tickets:");
        system.DisplayTickets();

        Console.WriteLine("\nSearch by Customer:");
        system.SearchByCustomer("Tushar");

        Console.WriteLine("\nSearch by Movie:");
        system.SearchByMovie("Inception");

        Console.WriteLine($"\nTotal Tickets Booked: {system.CountTickets()}");

        Console.WriteLine("\nCancel Ticket:");
        system.RemoveTicket(102);

        Console.WriteLine("\nUpdated Ticket List:");
        system.DisplayTickets();
    }
}
