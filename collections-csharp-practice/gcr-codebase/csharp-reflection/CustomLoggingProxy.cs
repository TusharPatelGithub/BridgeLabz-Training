using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
// Interface
public interface IGreeting{
        void SayHello(string name);
    }
    class Greeting : IGreeting{
        public void SayHello(string name){
            Console.WriteLine("Hello " + name);
        }
    }
    // Logging Proxy
    class LoggingProxy : DispatchProxy{
        private object target;

        protected override object Invoke(MethodInfo method, object[] args){
            Console.WriteLine("Calling method: " + method.Name);
            // Call actual method
            return method.Invoke(target, args);
        }
        public static T Create<T>(T target){
            object proxy = Create<T, LoggingProxy>();
            ((LoggingProxy)proxy).target = target;
            return (T)proxy;
        }
    }
    internal class CustomLoggingProxy {
        public static void Main(string[] args){
            IGreeting greeting = new Greeting();
            // Wrap with logging proxy
            IGreeting proxy = LoggingProxy.Create(greeting);
            proxy.SayHello("Lavanya");
        }
    }

