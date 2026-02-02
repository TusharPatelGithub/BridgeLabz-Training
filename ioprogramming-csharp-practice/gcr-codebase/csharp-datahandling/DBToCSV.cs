using System.IO;
class DBtoCSV
{
    static void Main()
    {
        File.WriteAllText("db_export.csv",
            "ID,Name,Dept,Salary\n1,Rahul,IT,60000");
    }
}
