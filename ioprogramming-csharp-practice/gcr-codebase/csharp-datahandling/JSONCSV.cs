using System.IO;
using System.Text.Json;
class JSONCSV
{
    static void Main()
    {
        var json = "[{\"Name\":\"Alice\",\"Age\":20}]";
        File.WriteAllText("students.json", json);
        File.WriteAllText("fromjson.csv", "Name,Age\nAlice,20");
    }
}
