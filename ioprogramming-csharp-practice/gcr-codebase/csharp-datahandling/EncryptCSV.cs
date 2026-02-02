using System;
using System.IO;
using System.Text;
class EncryptCSV
{
    static void Main()
    {
        string enc = Convert.ToBase64String(Encoding.UTF8.GetBytes("60000"));
        Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(enc)));
    }
}
