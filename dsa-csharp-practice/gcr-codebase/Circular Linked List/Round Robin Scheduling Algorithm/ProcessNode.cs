using System;

public class ProcessNode
{
    public int ProcessId;
    public int BurstTime;
    public int RemainingTime;
    public int Priority;

    public int WaitingTime;
    public int TurnAroundTime;

    public ProcessNode Next;

    public ProcessNode(int id, int burstTime, int priority)
    {
        ProcessId = id;
        BurstTime = burstTime;
        RemainingTime = burstTime;
        Priority = priority;
        Next = null;
    }
}
