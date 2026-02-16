using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
//scans assemblies and generates JSON audit logs using reflection
public class EventTrackerEngine
{
    public string GenerateAuditLogs()
    {
        List<AuditLog> logs = new List<AuditLog>();
        Assembly assembly = Assembly.GetExecutingAssembly();
        //scan all classes in the assembly
        foreach (var type in assembly.GetTypes())
        {
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (var method in methods)
            {
                var auditAttr = method.GetCustomAttribute<AuditTrailAttribute>();
                //capture audit metadata for annotated methods
                if (auditAttr != null)
                {
                    logs.Add(new AuditLog
                    {
                        Action = auditAttr.ActionName,
                        ClassName = type.Name,
                        MethodName = method.Name,
                        Timestamp = DateTime.Now
                    });
                }
            }
        }
        //convert audit logs to formatted JSON
        return JsonSerializer.Serialize(logs, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
