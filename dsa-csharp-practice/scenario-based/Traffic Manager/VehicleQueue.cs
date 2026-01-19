using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Manager
{
    class VehicleQueue//manages vehicle waiting to enter the roundabout
    {
        private VehicleNode front;
        private VehicleNode rear;
        private int capacity;
        private int count;
        public VehicleQueue(int capacity)
        {
            this.capacity = capacity;
            front = null;
            rear = null;
            count = 0;
        }
        public void Enqueue(string vehicleNumber) //add vehicle in queue
        {
            if (count == capacity)
            {
                Console.WriteLine("Cannot add more vehicles. Queue is full");
                return;
            }
            VehicleNode newNode = new VehicleNode(vehicleNumber);
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            count++;
            Console.WriteLine($"Vehicle {vehicleNumber} added to waiting queue.");
        }
        public string Dequeue() //remove vehicle from the queue
        {
            if (front == null)
            {
                Console.WriteLine("No vehicle in waiting.");
                return null;
            }
            string vehicleNumber = front.VehicleNumber;
            front = front.Next;
            if (front == null)
                rear = null;
            count--;
            return vehicleNumber;
        }
        public void PrintQueue()//print queue
        {
            if (front == null)
            {
                Console.WriteLine("waiting queue is empty.");
                return;
            }
            Console.WriteLine("Queue: ");
            VehicleNode temp = front;
            while (temp != null)
            {
                Console.Write(temp.VehicleNumber + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
    }
}
