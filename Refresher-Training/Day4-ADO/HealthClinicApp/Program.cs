using HealthClinicApp.Menu;

namespace HealthClinicApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HealthMenu menu = new HealthMenu();
            menu.Run();
        }
    }
}