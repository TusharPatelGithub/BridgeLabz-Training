using System;

public class TicketReservationSystem
{
    private TicketNode head;
    private TicketNode tail;

    // Add ticket at end
    public void AddTicket(int id, string customer, string movie, string seat)
    {
        TicketNode newTicket = new TicketNode(id, customer, movie, seat);

        if (head == null)
        {
            head = tail = newTicket;
            newTicket.Next = newTicket;
            return;
        }

        tail.Next = newTicket;
        newTicket.Next = head;
        tail = newTicket;
    }

    // Remove ticket by Ticket ID
    public void RemoveTicket(int ticketId)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode current = head;
        TicketNode prev = tail;

        do
        {
            if (current.TicketId == ticketId)
            {
                if (current == head)
                    head = head.Next;

                if (current == tail)
                    tail = prev;

                prev.Next = current.Next;

                if (head == current)
                    head = null;

                Console.WriteLine("Ticket cancelled successfully.");
                return;
            }

            prev = current;
            current = current.Next;

        } while (current != head);

        Console.WriteLine("Ticket not found.");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        do
        {
            DisplayTicket(temp);
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by Customer Name
    public void SearchByCustomer(string customerName)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase))
            {
                DisplayTicket(temp);
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tickets found for this customer.");
    }

    // Search by Movie Name
    public void SearchByMovie(string movieName)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
            {
                DisplayTicket(temp);
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No tickets found for this movie.");
    }

    // Count total tickets
    public int CountTickets()
    {
        if (head == null)
            return 0;

        int count = 0;
        TicketNode temp = head;
        do
        {
            count++;
            temp = temp.Next;
        } while (temp != head);

        return count;
    }

    private void DisplayTicket(TicketNode t)
    {
        Console.WriteLine(
            $"TicketID: {t.TicketId}, Customer: {t.CustomerName}, Movie: {t.MovieName}, Seat: {t.SeatNumber}, Time: {t.BookingTime}"
        );
    }
}
