using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
// Custom attribute
[AttributeUsage(AttributeTargets.Field)]
    class InjectAttribute : Attribute { }
    // Service
    class Service{
        public void Execute(){
            Console.WriteLine("Service Executed");
        }
    }
    // Client
    class Client {
        [Inject]
        public Service service;
    }
    // Simple DI Container
    class DIContainer {
        public static void InjectDependencies(object obj){
            Type type = obj.GetType();
            foreach (FieldInfo field in type.GetFields()){
                if (field.IsDefined(typeof(InjectAttribute), false)){
                    // Create dependency dynamically
                    object dependency = Activator.CreateInstance(field.FieldType);
                    field.SetValue(obj, dependency);
                }
            }
        }
    }
    internal class DependencyInjectionUsing {
        public static void Main(string[] args){
            Client client = new Client();
            DIContainer.InjectDependencies(client);
            client.service.Execute();
        }
    }
