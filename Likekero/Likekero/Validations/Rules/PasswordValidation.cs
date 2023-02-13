namespace Likekero.Validations.Rules
{
    class PasswordValidation<T> : IValidationRule<T>
    {
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
            return true;
        }
    }
}
