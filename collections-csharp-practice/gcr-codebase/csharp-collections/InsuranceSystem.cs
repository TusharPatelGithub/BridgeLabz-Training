using System;
using System.Collections.Generic;
using System.Linq;
class Policy
{
    public string PolicyNumber { get; set; }
    public string CoverageType { get; set; }
    public DateTime ExpiryDate { get; set; }
    public Policy(string number, string coverage, DateTime expiry)
    {
        PolicyNumber = number;
        CoverageType = coverage;
        ExpiryDate = expiry;
    }
    public override string ToString()
    {
        return $"{PolicyNumber} | {CoverageType} | {ExpiryDate.ToShortDateString()}";
    }
    // Equality based on PolicyNumber
    public override bool Equals(object obj)
    {
        return obj is Policy p && p.PolicyNumber == this.PolicyNumber;
    }
    public override int GetHashCode()
    {
        return PolicyNumber.GetHashCode();
    }
}
class InsuranceSystem
{
    // Unique policies for quick lookup
    private HashSet<Policy> policySet = new HashSet<Policy>();
    // Maintain insertion order
    private List<Policy> insertionOrder = new List<Policy>();
    // Sorted by expiry date
    private SortedSet<Policy> sortedByExpiry = new SortedSet<Policy>(Comparer<Policy>.Create(
        (x, y) => x.ExpiryDate.CompareTo(y.ExpiryDate) == 0 ? x.PolicyNumber.CompareTo(y.PolicyNumber) : x.ExpiryDate.CompareTo(y.ExpiryDate)
    ));
    // Add policy
    public void AddPolicy(Policy policy)
    {
        if (policySet.Add(policy))
        {
            insertionOrder.Add(policy);
            sortedByExpiry.Add(policy);
        }
        else
        {
            Console.WriteLine($"Duplicate policy found: {policy.PolicyNumber}");
        }
    }
    // Retrieve all unique policies
    public void DisplayAllPolicies()
    {
        Console.WriteLine("All Policies:");
        foreach (var p in insertionOrder)
            Console.WriteLine(p);
    }
    // Policies expiring in next N days
    public void DisplayExpiringSoon(int days = 30)
    {
        Console.WriteLine($"\nPolicies expiring in next {days} days:");
        DateTime now = DateTime.Today;
        foreach (var p in sortedByExpiry)
        {
            if ((p.ExpiryDate - now).TotalDays <= days && (p.ExpiryDate - now).TotalDays >= 0)
                Console.WriteLine(p);
        }
    }
    // Policies by coverage type
    public void DisplayByCoverage(string coverage)
    {
        Console.WriteLine($"\nPolicies with coverage type: {coverage}");
        foreach (var p in insertionOrder.Where(p => p.CoverageType.Equals(coverage, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine(p);
        }
    }
    // Find duplicate policies (based on policy number)
    public void DisplayDuplicates(List<Policy> newPolicies)
    {
        Console.WriteLine("\nDuplicate Policies (based on policy number):");
        foreach (var p in newPolicies)
        {
            if (!policySet.Add(p))
                Console.WriteLine(p);
        }
    }
}
class InsuranceSystemMain
{
    public static void Main(string[] args)
    {
        InsuranceSystem system = new InsuranceSystem();
        // Adding policies
        system.AddPolicy(new Policy("P1001", "Health", DateTime.Today.AddDays(10)));
        system.AddPolicy(new Policy("P1002", "Life", DateTime.Today.AddDays(40)));
        system.AddPolicy(new Policy("P1003", "Car", DateTime.Today.AddDays(20)));
        system.AddPolicy(new Policy("P1004", "Health", DateTime.Today.AddDays(5)));
        system.AddPolicy(new Policy("P1001", "Health", DateTime.Today.AddDays(10))); // duplicate
        system.DisplayAllPolicies();
        system.DisplayExpiringSoon(30);
        system.DisplayByCoverage("Health");
        // Checking duplicates in new incoming policies
        List<Policy> newPolicies = new List<Policy>
        {
            new Policy("P1002", "Life", DateTime.Today.AddDays(40)),
            new Policy("P1005", "Travel", DateTime.Today.AddDays(15))
        };
        system.DisplayDuplicates(newPolicies);
    }
}