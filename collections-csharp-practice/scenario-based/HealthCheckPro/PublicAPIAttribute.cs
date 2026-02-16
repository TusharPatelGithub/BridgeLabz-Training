using System;
//marks an API method as publicly accessible with description metadata
[AttributeUsage(AttributeTargets.Method)]
public class PublicAPIAttribute : Attribute
{
    public string Description { get; }
    public PublicAPIAttribute(string description)
    {
        Description = description;
    }
}