using System.Linq;
using System.Reflection;
using System.Text;
//generates human-readable API documentation using reflection metadata
public class ApiDocGenerator
{
    public string GenerateDocs()
    {
        StringBuilder doc = new StringBuilder();
        Assembly assembly = Assembly.GetExecutingAssembly();
        // Iterate through all controller classes
        foreach (var controller in assembly.GetTypes().Where(t => t.Name.EndsWith("Controller")))
        {
            doc.AppendLine($"## {controller.Name}");
            foreach (var method in controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                var publicApi = method.GetCustomAttribute<PublicAPIAttribute>();
                var requiresAuth = method.GetCustomAttribute<RequiresAuthAttribute>();
                doc.Append($"- {method.Name}");
                // Append public API metadata
                if (publicApi != null)
                    doc.Append($" | Public | {publicApi.Description}");
                // Append authentication metadata
                if (requiresAuth != null)
                    doc.Append($" | Secured (Role: {requiresAuth.Role})");
                // Highlight missing metadata
                if (publicApi == null && requiresAuth == null)
                    doc.Append(" | ❌ No metadata");
                doc.AppendLine();
            }
        }
        return doc.ToString();
    }
}
