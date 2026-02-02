using System;
using System.Text.RegularExpressions;
class ValidIPAddress{
    static void Main(string[] args){
        Console.WriteLine("enter an IPv4 address:");
        string ip = Console.ReadLine();
        string pattern ="^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\\.){3}" + "(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";
        if(Regex.IsMatch(ip, pattern)){
            Console.WriteLine("valid IPv4 address");
        }
        else{
            Console.WriteLine("invalid IPv4 address");
        }
    }
}