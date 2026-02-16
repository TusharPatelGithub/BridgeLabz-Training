using System.Linq;

namespace SecurityUtilities
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            bool hasMinLength = password.Length >= 8;
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);

            return hasMinLength && hasUpperCase && hasDigit;
        }
    }
}
