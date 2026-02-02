using System;
// class manages all Circular Linked List
public class CircularRoute{
    private Unit head;
    // adds a new hospital unit to the circular route
    public void AddUnit(string name, bool isAvailable){
        Unit newUnit = new Unit(name, isAvailable);//create a new unit 
        if(head == null){ //if no unit exists, make this the first unit
            head = newUnit;
            head.Next = head;
            return;
        }
        Unit current = head; //traverse to the last unit in the circular list
        while(current.Next != head){
            current = current.Next;
        }
        current.Next = newUnit;
        newUnit.Next = head;
    }
    public void RoutePatient(){ //finds the available unit which is near
        if(head == null){
            Console.WriteLine("No hospital units available.");
            return;
        }
        Unit current = head;
        bool unitFound = false;
        do{
            Console.WriteLine("Checking unit: " + current.Name);
            if(current.IsAvailable){
                Console.WriteLine("Patient redirected to: " + current.Name);
                unitFound = true;
                break;
            }
            current = current.Next;
        }while(current != head);
        if(!unitFound){
            Console.WriteLine("All units are currently busy.");
        }
    }
    public void RemoveUnit(string name){ // removes a hospital unit under maintenance
        if(head == null){
            Console.WriteLine("No units to remove.");
            return;
        }
        Unit current = head;
        Unit previous = null;
        do{
            if(current.Name == name){
                if(current == head){ //unit to remove is the head
                    Unit temp = head;
                    while(temp.Next != head){ //find the last unit
                        temp = temp.Next;
                    }
                    head = head.Next; //move head to next unit
                    temp.Next = head;
                }
                else{
                    previous.Next = current.Next;
                }
                Console.WriteLine(name + " removed for maintenance.");
                return;
            }
            previous = current;
            current = current.Next;
        }while(current != head);
        Console.WriteLine("Unit not found.");
    }
    public void DisplayUnits(){ //displays all hospital units and their availability
        if(head == null){
            Console.WriteLine("No hospital units added yet.");
            return;
        }
        Unit current = head;
        Console.WriteLine("\nHospital Units List:");
        do{
            Console.WriteLine("Unit Name: " + current.Name +" | Available: " + (current.IsAvailable ? "Yes" : "No"));
            current = current.Next;
        }while(current != head);
    }
}