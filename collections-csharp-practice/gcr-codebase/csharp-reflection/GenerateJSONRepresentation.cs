using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
class Student{
        public int Id;
        public string Name;
        public double Marks;
    }
    class JsonConverter{
        public static string ToJson(object obj){
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            StringBuilder json = new StringBuilder();
            json.Append("{ ");
            for (int i = 0; i < fields.Length; i++){
                json.Append("\"" + fields[i].Name + "\": ");
                json.Append("\"" + fields[i].GetValue(obj) + "\"");
                if (i < fields.Length - 1){
                    json.Append(", ");
                }
            }
            json.Append(" }");
            return json.ToString();
        }
    }
        internal class GenerateJSONRepresentation{
            public static void Main(string[] args){
            Student s = new Student { Id = 1, Name = "kshitiz", Marks = 75.3 };
            string json = JsonConverter.ToJson(s);
            Console.WriteLine(json);
        }
    }
