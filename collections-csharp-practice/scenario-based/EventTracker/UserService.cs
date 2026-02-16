//handles user-related operations
public class UserService
{
    [AuditTrail("User Login")]
    public void Login()
    {
        //simulated login logic
    }
    [AuditTrail("User Logout")]
    public void Logout()
    {
        //simulated logout logic
    }
}