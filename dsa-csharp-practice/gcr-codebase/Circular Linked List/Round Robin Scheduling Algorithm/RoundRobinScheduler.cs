using System;

public class RoundRobinScheduler
{
    private CircularProcessQueue queue;
    private int timeQuantum;
    private int currentTime;

    public RoundRobinScheduler(CircularProcessQueue queue, int timeQuantum)
    {
        this.queue = queue;
        this.timeQuantum = timeQuantum;
        currentTime = 0;
    }

    public void StartScheduling()
    {
        if (queue.IsEmpty())
        {
            Console.WriteLine("No processes to schedule.");
            return;
        }

        ProcessNode current = queue.GetHead();

        while (!queue.IsEmpty())
        {
            int executionTime = Math.Min(timeQuantum, current.RemainingTime);
            current.RemainingTime -= executionTime;
            currentTime += executionTime;

            Console.WriteLine($"\nExecuting Process {current.ProcessId} for {executionTime} units");

            if (current.RemainingTime == 0)
            {
                current.TurnAroundTime = currentTime;
                current.WaitingTime = current.TurnAroundTime - current.BurstTime;

                int completedId = current.ProcessId;
                current = current.Next;
                queue.RemoveProcess(completedId);
            }
            else
            {
                current = current.Next;
            }

            Console.WriteLine("Queue after this round:");
            queue.Display();
        }
    }

    public void DisplayAverages(ProcessNode[] processes)
    {
        double totalWT = 0, totalTAT = 0;

        foreach (var p in processes)
        {
            totalWT += p.WaitingTime;
            totalTAT += p.TurnAroundTime;
        }

        Console.WriteLine($"\nAverage Waiting Time: {totalWT / processes.Length}");
        Console.WriteLine($"Average Turnaround Time: {totalTAT / processes.Length}");
    }
}
