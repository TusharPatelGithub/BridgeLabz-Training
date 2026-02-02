using System;
using System.Collections.Generic;
class VotingSystem
{
    // Store votes: candidate -> vote count
    private Dictionary<string, int> votes = new Dictionary<string, int>();
    // Maintain order of first vote (like LinkedHashMap)
    private List<string> voteOrder = new List<string>();
    // Cast a vote
    public void CastVote(string candidate)
    {
        if (votes.ContainsKey(candidate))
        {
            votes[candidate]++;
        }
        else
        {
            votes[candidate] = 1;
            voteOrder.Add(candidate); // first time vote, maintain order
        }
    }
    // Display results in order of first vote
    public void DisplayResultsByVoteOrder()
    {
        Console.WriteLine("\nResults in order of first vote cast:");
        foreach (string candidate in voteOrder)
        {
            Console.WriteLine($"{candidate}: {votes[candidate]} votes");
        }
    }
    // Display results sorted alphabetically
    public void DisplayResultsSorted()
    {
        Console.WriteLine("\nResults sorted alphabetically:");
        List<string> keys = new List<string>(votes.Keys);
        keys.Sort(); // sort keys alphabetically
        foreach (string candidate in keys)
        {
            Console.WriteLine($"{candidate}: {votes[candidate]} votes");
        }
    }
    // Display results sorted by vote count descending
    public void DisplayResultsByVotesDesc()
    {
        Console.WriteLine("\nResults sorted by vote count descending:");
        // Convert dictionary to a list of KeyValuePair for sorting
        List<KeyValuePair<string, int>> voteList = new List<KeyValuePair<string, int>>(votes);
        // Bubble sort (or any sort) by vote count descending
        for (int i = 0; i < voteList.Count - 1; i++)
        {
            for (int j = 0; j < voteList.Count - i - 1; j++)
            {
                if (voteList[j].Value < voteList[j + 1].Value)
                {
                    var temp = voteList[j];
                    voteList[j] = voteList[j + 1];
                    voteList[j + 1] = temp;
                }
            }
        }
        foreach (var pair in voteList)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value} votes");
        }
    }
}
class Program
{
    static void Main()
    {
        VotingSystem voting = new VotingSystem();
        // Cast votes
        voting.CastVote("Alice");
        voting.CastVote("Bob");
        voting.CastVote("Alice");
        voting.CastVote("Charlie");
        voting.CastVote("Bob");
        voting.CastVote("Alice");
        // Display results
        voting.DisplayResultsByVoteOrder();
        voting.DisplayResultsSorted();
        voting.DisplayResultsByVotesDesc();
    }
}