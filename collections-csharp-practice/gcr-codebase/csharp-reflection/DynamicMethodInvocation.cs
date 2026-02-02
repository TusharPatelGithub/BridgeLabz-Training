using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
class MathOperations{
        public int Add(int a, int b){
            return a + b;
        }
        public int Subtract(int a, int b){
            return a - b;
        }
        public int Multiply(int a, int b){
            return a * b;
        }
    }
    internal class DynamicMethodInvocation{
    public static void Main(string[] args){
            // Create object normally
            MathOperations obj = new MathOperations();
            Console.Write("enter method name (Add / Subtract / Multiply): ");
            string methodName = Console.ReadLine();
            Console.Write("enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Type type = typeof(MathOperations);
            MethodInfo method = type.GetMethod(methodName);
            if (method == null){
                Console.WriteLine("Invalid method name!");
                return;
            }
            object result = method.Invoke(obj, new object[] { a, b });
            Console.WriteLine("Result: " + result);
        }
    }
