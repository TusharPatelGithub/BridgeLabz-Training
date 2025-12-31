class Circle
{
    public class Calculate
    {
        double radius;
        public Calculate(double radius)
        {
            this.radius=radius;
        }
       public void Area()
        {
            double ans=3.14*radius*radius;
            Console.WriteLine($"Area of cicle is {ans}");
            
        }
        public void Circumference()
        {
            double ans2=2*3.14*radius;
            Console.WriteLine($"Circumference of cicle is {ans2}");
            
        }
    }
public static void Main(string[] args)
{
    Calculate c1=new Calculate(35);
    c1.Area();
    c1.Circumference();
}
}