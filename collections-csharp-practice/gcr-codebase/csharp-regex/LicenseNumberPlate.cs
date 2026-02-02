using System;
using System.Text.RegularExpressions;
class LicensePlateNumber{
    static void Main(string[] args){
        Console.Write("Enter license plate number: ");
        string plate = Console.ReadLine();
        string pattern = "^[A-Z]{2}[0-9]{4}$";
        if(Regex.IsMatch(plate, pattern)){ // Validate license plate using regex
            Console.WriteLine("Valid License Plate");
        }
        else{
            Console.WriteLine("Invalid License Plate");
        }
    }
}