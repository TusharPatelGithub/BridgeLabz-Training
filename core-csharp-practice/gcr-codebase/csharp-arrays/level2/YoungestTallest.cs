class YoungestTallest
{
    static void Main(String[] args)
    {
        string[] name=new string[3];
        int []age=new int[3];
        int []height=new int[3];
        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter the name: ");
            name[i]=Console.ReadLine();
            Console.WriteLine("Enter the age: ");
            age[i]=Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter the height: ");
            height[i]=Convert.ToInt16(Console.ReadLine());
        }
        if (age[0] < age[1] && age[0] < age[2])
        {
            Console.WriteLine(name[0]+" is the yougest");

        }else if (age[1] < age[0] && age[1] < age[2])
        {
            Console.WriteLine(name[1]+" is the yougest");
        }
        else
        {
            Console.WriteLine(name[2]+" is the yougest");
        }
        if (height[0] > height[1] && height[0] > age[2])
        {
            Console.WriteLine(name[0]+" is the tallest");

        }else if (height[1] > age[0] && height[1] > age[2])
        {
            Console.WriteLine(name[1]+" is the talllest");
        }
        else
        {
            Console.WriteLine(name[2]+" is the tallest");
        }
    }
}