using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
class Student{
        // creating an object
        public Student(){
            Console.WriteLine("student object created!");
        }
        // displaying the object 
        public void Show(){
            Console.WriteLine("welcome student");
        }
    }
    internal class DynamicallyCreateObjects {
    public static void Main(string[] args){
            Type type = typeof(Student);
            object obj = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Show");
            method.Invoke(obj, null);
        }
    }
