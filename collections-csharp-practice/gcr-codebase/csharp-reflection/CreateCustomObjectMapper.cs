using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
class Person{
    public string Name;
    public int Age;
}
class ObjectMapper {
    public static T ToObject<T>(Dictionary<string, object> properties)where T : new(){
        T obj = new T();
        Type type = typeof(T);
        foreach (var item in properties){
            FieldInfo field = type.GetField(item.Key);
                if (field != null){
                    field.SetValue(obj, item.Value);
                }
            }
            return obj;
        }
    }
internal class CreateCustomObjectMapper{
        public static void Main(string[] args){
            Dictionary<string, object> data = new Dictionary<string, object>(){
            { "Name", "Lavanya" },
            { "Age", 21 }};
            Person person = ObjectMapper.ToObject<Person>(data);
            Console.WriteLine(person.Name + " - " + person.Age);
    }
}


