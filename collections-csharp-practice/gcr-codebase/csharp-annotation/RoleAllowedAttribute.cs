using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
    //attribute Definition
    [AttributeUsage(AttributeTargets.Method)]
    public class RoleAllowedAttribute : Attribute
    {
        public string Role { get; }
        public RoleAllowedAttribute(string role)
        {
            Role = role;
        }
    }
    //applying the Attribute
    public class AdminService
    {
        [RoleAllowed("ADMIN")]
        public void DeleteUser()
        {
            Console.WriteLine("User deleted");
        }
    }
    //reflection Logic
    class Program
    {
        static void Main()
        {
            string currentRole = "USER";
            MethodInfo method = typeof(AdminService).GetMethod("DeleteUser");
            var attr = method.GetCustomAttribute<RoleAllowedAttribute>();
            if (attr != null && attr.Role != currentRole)
            {
                Console.WriteLine("Access Denied!");
                return;
            }
            method.Invoke(new AdminService(), null);
        }
    }