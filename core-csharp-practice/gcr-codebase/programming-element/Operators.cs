using System;

class Operators
{
    static void Main()
    {
        
        int a = 10;
        int b = 5;

        // ---------------- ARITHMETIC OPERATORS ----------------
        // +  -  *  /  %
        Console.WriteLine("Arithmetic Operators:");
        Console.WriteLine("Addition (a + b) = " + (a + b));        // 10 + 5 = 15
        Console.WriteLine("Subtraction (a - b) = " + (a - b));     // 10 - 5 = 5
        Console.WriteLine("Multiplication (a * b) = " + (a * b)); // 10 * 5 = 50
        Console.WriteLine("Division (a / b) = " + (a / b));       // 10 / 5 = 2
        Console.WriteLine("Modulus (a % b) = " + (a % b));        // Remainder

        // ---------------- RELATIONAL OPERATORS ----------------
        // >  <  >=  <=  ==  !=
        Console.WriteLine("\nRelational Operators:");
        Console.WriteLine("a > b : " + (a > b));   // true
        Console.WriteLine("a < b : " + (a < b));   // false
        Console.WriteLine("a == b : " + (a == b)); // false
        Console.WriteLine("a != b : " + (a != b)); // true

        // ---------------- LOGICAL OPERATORS ----------------
        // &&  ||  !
        bool x = true;
        bool y = false;

        Console.WriteLine("\nLogical Operators:");
        Console.WriteLine("x && y : " + (x && y)); // AND
        Console.WriteLine("x || y : " + (x || y)); // OR
        Console.WriteLine("!x : " + (!x));         // NOT

        // ---------------- UNARY OPERATORS ----------------
        // ++  --
        Console.WriteLine("\nUnary Operators:");
        Console.WriteLine("Pre-increment (++a) = " + (++a)); // a becomes 11
        Console.WriteLine("Post-decrement (b--) = " + (b--)); // prints 5
        Console.WriteLine("Value of b after decrement = " + b); // b becomes 4

        // ---------------- TERNARY OPERATOR ----------------
        // condition ? true_value : false_value
        Console.WriteLine("\nTernary Operator:");
        string result = (a > b) ? "a is greater" : "b is greater";
        Console.WriteLine(result);

        // ---------------- 'is' OPERATOR ----------------
        // Checks object type at runtime
        Console.WriteLine("\n'is' Operator:");
        object obj = "Hello World";

        Console.WriteLine(obj is string); // true
        Console.WriteLine(obj is int);    // false
    }
}
