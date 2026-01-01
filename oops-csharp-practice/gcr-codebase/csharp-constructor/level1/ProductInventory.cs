class ProductInventory
{
    public static void Main(string[] args)
    {
        Product p1=new Product("phones",20000);
        Product p2=new Product("laptop",50000);
        Product p3=new Product("headphone",2000);
        Product p4=new Product("bags",2000);
        Product p5=new Product("chair",200000);
        Console.WriteLine($"Total number of product is: {Product.totalProduct}");
        
    }
}
class Product
{
   public int price;
    public string productName;
    public static int totalProduct=0;
    public Product(String productName,int price)
    {
        this.productName=productName;
        this.price=price;
        totalProduct++;
    }

}