using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
    //attribute Definition
    [AttributeUsage(AttributeTargets.Method)]
    internal class TodoAttribute : Attribute
    {
        public string Task { get; }
        public string AssignedTo { get; }
        public string Priority { get; }
        public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
        {
            Task = task;
            AssignedTo = assignedTo;
            Priority = priority;
        }
    }
    //applying the Attribute
    public class Project
    {
        [Todo("Implement payment module", "Alice", "HIGH")]
        public void Payment() { }

        [Todo("Add logging", "Bob")]
        public void Logging() { }
    }
    //reflection Logic
    class Program
    {
        static void Main()
        {
            foreach (MethodInfo method in typeof(Project).GetMethods(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                var todo = method.GetCustomAttribute<TodoAttribute>();
                if (todo != null)
                {
                    Console.WriteLine(
                        $"Task: {todo.Task}, AssignedTo: {todo.AssignedTo}, Priority: {todo.Priority}");
                }
            }
        }
    }
