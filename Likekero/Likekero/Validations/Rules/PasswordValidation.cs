using System.Linq;
using System.Text.RegularExpressions;

namespace Likekero.Validations.Rules
{
    class PasswordValidation<T> : IValidationRule<T>
    {
        const string passwordRegex = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$";
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            if (str.Length < 6)
                return false;

            bool isValid = Regex.IsMatch(str, passwordRegex);
            return isValid;
        }

        public string ReturnError(T value)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
                return "Password is required.";
            if (str.Length < 6)
                return "Password must be at least 6 characters long";

            if (!str.Any(char.IsUpper))
                return "Password must contain at least one capital letter";

            if (!str.Any(char.IsNumber))
                return "Password must contain at least one number";

            if (!str.Any(ch => !char.IsLetterOrDigit(ch)))
                return "Password must contain at least one special character";

            return null;
        }
    }
}
