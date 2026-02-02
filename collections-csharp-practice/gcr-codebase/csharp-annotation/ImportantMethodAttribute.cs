using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
    //attribute Definition
    [AttributeUsage(AttributeTargets.Method)]
    internal class ImportantMethodAttribute : Attribute
    {
        public string Level { get; }

        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }
    }
    //applying the Attribute
    public class Service
    {
        [ImportantMethod]
        public void CriticalOperation() { }
        [ImportantMethod("LOW")]
        public void MinorOperation() { }
        public void NormalOperation() { }
    }
    //reflection Logic
    class Program
    {
        static void Main()
        {
            Type type = typeof(Service);
            foreach (MethodInfo method in type.GetMethods(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                var attr = method.GetCustomAttribute<ImportantMethodAttribute>();
                if (attr != null)
                {
                    Console.WriteLine($"{method.Name} → Importance: {attr.Level}");
                }
            }
        }
    }
