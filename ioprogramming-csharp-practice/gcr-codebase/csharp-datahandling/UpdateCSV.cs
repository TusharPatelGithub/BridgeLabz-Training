using System.IO;
class UpdateCSV
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");
        for (int i = 1; i < lines.Length; i++)
        {
            var d = lines[i].Split(',');
            if (d[2] == "IT")
                d[3] = (int.Parse(d[3]) * 1.1).ToString();
            lines[i] = string.Join(",", d);
        }
        File.WriteAllLines("employees_updated.csv", lines);
    }
}
