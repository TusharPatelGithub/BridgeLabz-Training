using System.IO;
using System.Linq;
class MergeCSV
{
    static void Main()
    {
        var s1 = File.ReadAllLines("students1.csv")[1..];
        var s2 = File.ReadAllLines("students2.csv")[1..];
        var merged = s1.Join(s2,
            a => a.Split(',')[0],
            b => b.Split(',')[0],
            (a, b) => a + "," + b.Split(',')[1] + "," + b.Split(',')[2]);
        File.WriteAllLines("merged.csv", merged);
    }
}
