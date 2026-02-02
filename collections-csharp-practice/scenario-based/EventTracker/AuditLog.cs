using System;
//represents a structured audit log entry
public class AuditLog
{
    public string Action { get; set; }
    public string ClassName { get; set; }
    public string MethodName { get; set; }
    public DateTime Timestamp { get; set; }
}