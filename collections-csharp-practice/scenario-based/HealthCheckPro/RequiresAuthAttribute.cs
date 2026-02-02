using System;
//marks an API method as secured and specifies required user role
[AttributeUsage(AttributeTargets.Method)]
public class RequiresAuthAttribute : Attribute
{
    public string Role { get; }
    public RequiresAuthAttribute(string role = "User")
    {
        Role = role;
    }
}