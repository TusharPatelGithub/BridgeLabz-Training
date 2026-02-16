using System;
class MethodPropagation{
    public static void Method1(){
        int x = 10 / 0;
    }
    public static void Method2(){
        Method1();
    }
    public static void Main(){
        try{
            Method2();
        }
        catch (ArithmeticException){
            Console.WriteLine("Handled exception in Main");
        }
    }
}