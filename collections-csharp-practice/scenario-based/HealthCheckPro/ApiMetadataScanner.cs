using System;
using System.Linq;
using System.Reflection;
//scans controller methods using reflection to validate API metadata annotations
public class ApiMetadataScanner
{
    public void ScanControllers()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        //find all classes ending with 'Controller'
        var controllers = assembly.GetTypes().Where(t => t.Name.EndsWith("Controller"));
        foreach (var controller in controllers)
        {
            Console.WriteLine($"\nController: {controller.Name}");
            //get only public instance methods declared in controller
            var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (var method in methods)
            {
                var publicApi = method.GetCustomAttribute<PublicAPIAttribute>();
                var requiresAuth = method.GetCustomAttribute<RequiresAuthAttribute>();
                //flag methods with no API-related annotations
                if (publicApi == null && requiresAuth == null)
                {
                    Console.WriteLine($"⚠️ {method.Name} → Missing API annotations");
                }
            }
        }
    }
}
