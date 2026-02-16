using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
    //attribute Definition
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute { }
    //applying the Attribute
    public class MathService
    {
        private static Dictionary<int, int> cache = new Dictionary<int, int>();
        [CacheResult]
        public int Square(int x)
        {
            Console.WriteLine("Computing...");
            return x * x;
        }
        public int Execute(int value)
        {
            if (cache.ContainsKey(value))
            {
                Console.WriteLine("From Cache");
                return cache[value];
            }
            MethodInfo method = typeof(MathService).GetMethod("Square");
            int result = (int)method.Invoke(this, new object[] { value });
            cache[value] = result;
            return result;
        }
    }
