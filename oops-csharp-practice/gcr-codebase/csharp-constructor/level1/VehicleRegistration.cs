class VehicleRegistration
{
    public static void Main(string[] args)
    {
        Vehicle[] vehicle=new Vehicle[3];

        vehicle[0]=new Vehicle("Tushar","suv");
        vehicle[1]=new Vehicle("vishal","sedan");
        vehicle[2]=new Vehicle("Gaurav","hashback");
        for(int i = 0; i < vehicle.Length; i++)
        {
            vehicle[i].DisplayVehicleDetails();
        }

    }

}
class Vehicle
{
    public string OwnerName;
    public string vehicleType;
    public static int registrationFees=30000;
    public Vehicle(string OwnerName,string vehicleType)
    {
        this.OwnerName=OwnerName;
        this.vehicleType=vehicleType;
    }
    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner name is {OwnerName}");
        Console.WriteLine($"Vehicle type is {vehicleType}");
        Console.WriteLine($"Registration fees is {registrationFees}");
        Console.WriteLine($"----------------------------");
        
    }
    public static int UpdateRegistrationFee(int fee)
    {
        registrationFees=fee;
        return registrationFees;
    }
}