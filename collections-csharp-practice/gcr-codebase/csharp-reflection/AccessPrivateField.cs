using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;        
class Person{
    private int age = 20;
}
internal class AccessPrivateField{
    public  static void Main(string[] args){
        Person person = new Person();
        Type type = typeof(Person);
        // Access private field "age"
        FieldInfo field = type.GetField("age",BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(person, 22);
        int value = (int)field.GetValue(person);
        Console.WriteLine("Updated Age: " + value);
    }
}
