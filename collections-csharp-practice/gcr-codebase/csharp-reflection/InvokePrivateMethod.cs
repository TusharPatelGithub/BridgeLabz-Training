using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
class Calculator{
        private int Multiply(int a, int b){
            return a * b;
        }
    }
    internal class InvokePrivateMethod{
    public static void Main(string[] args) {
            Calculator calc = new Calculator();
            Type type = typeof(Calculator);
            MethodInfo method = type.GetMethod("multiply",BindingFlags.NonPublic | BindingFlags.Instance);
            object result = method.Invoke(calc, new object[] { 5, 4 });
            Console.WriteLine("multiplication Result: " + result);
        }
    }
