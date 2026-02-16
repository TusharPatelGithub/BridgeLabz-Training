using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
class TestClass{
        public void Task1(){
            for (int i = 0; i < 1000000; i++) ;
        }
        public void Task2(){
            for (int i = 0; i < 2000000; i++) ;
        }
    }
    internal class MethodExecutionTiming{
        public static void Main(string[] args) {
            TestClass obj = new TestClass();
            Type type = typeof(TestClass);
            foreach (MethodInfo method in type.GetMethods(
                    BindingFlags.Public | BindingFlags.Instance)){
                if (method.DeclaringType == type){
                    Stopwatch sw = Stopwatch.StartNew();
                    // Invoke method
                    method.Invoke(obj, null);
                    sw.Stop();
                    Console.WriteLine(method.Name + " executed in " +sw.ElapsedMilliseconds + " ms");
                }
            }
        }
    }
