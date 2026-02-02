using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;     
class Configuration{
    private static string API_KEY = "OLD_KEY";
}
internal class AccessAndModifyStaticFields{
    public static void Main(string[] args){
        Type type = typeof(Configuration);
        // Access private static field
        FieldInfo field = type.GetField("API_KEY",BindingFlags.NonPublic | BindingFlags.Static); 
        field.SetValue(null, "NEW_SECRET_KEY");
        string value = (string)field.GetValue(null);
        Console.WriteLine("Updated API Key: " + value);
    }
}
