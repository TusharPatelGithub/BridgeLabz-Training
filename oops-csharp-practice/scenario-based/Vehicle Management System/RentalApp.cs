using Vehicle_Management_System;

class VehicleRentalApp
{
    static void Main()
    {
        Customer customer = new Customer("Tushar");

        Vehicle bike = new Bike("MH12B1234", "Yamaha", 300);
        Vehicle car = new Car("MH12C5678", "Honda", 1200);
        Vehicle truck = new Truck("MH12T9999", "Tata", 2500);

        bike.DisplayInfo();
        customer.RentVehicle((IRentable)bike, 3);

        Console.WriteLine();

        car.DisplayInfo();
        customer.RentVehicle((IRentable)car, 2);

        Console.WriteLine();

        truck.DisplayInfo();
        customer.RentVehicle((IRentable)truck, 1);
    }
}