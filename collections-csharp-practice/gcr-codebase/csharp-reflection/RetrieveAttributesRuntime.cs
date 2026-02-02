using System;
using System.Collections.Generic;
using System.Text;    
// Create custom attribute
[AttributeUsage(AttributeTargets.Class)]
    class AuthorAttribute : Attribute{
        public string Name { get; }
        public AuthorAttribute(string name){
            Name = name;
        }
    }
    // Apply attribute to class
    [Author("David Goggins")]
    class DemoClass{
    }
    internal class RetrieveAttributesRuntime{
        public static void Main(string[] args){
            Type type = typeof(DemoClass);
            AuthorAttribute attribute =(AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));
            if (attribute != null) {
                Console.WriteLine("author name: " + attribute.Name);
            }else{
                Console.WriteLine("author attribute not found.");
            }
        }
    }
