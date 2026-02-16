using System;
class Passenger
{
    public int pnrNumber;
    public string name;
    public int age;
    public string source;
    public string destination;
    public double distance;
    public double price;
    public passenger(int pnrNumber,string name,int age,string source,string destination,double distance)
    {
        this.pnrNumber = pnrNumber;
        this.name = name;
        this.age = age;
        this.source = source;
        this.destination = destination;
        this.distance = distance;
        this.price = price;

    }
    public override string ToString()
    {
        return $"Pnr: {pnrNumber}, Name: {name}, Age: {age}, From: {source}, Destination: {destination}, Distance: {distance}, Price: {price}";
    }
}