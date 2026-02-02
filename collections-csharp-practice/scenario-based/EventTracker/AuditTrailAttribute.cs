using System;
//marks methods whose execution should be audited
[AttributeUsage(AttributeTargets.Method)]
public class AuditTrailAttribute : Attribute
{
    public string ActionName { get; }
    public AuditTrailAttribute(string actionName)
    {
        ActionName = actionName;
    }
}