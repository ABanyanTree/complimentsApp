namespace Likekero.Validations.Rules
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }

        public string ReturnError(T value)
        {
            return null;
        }
    }

    public class IsComboboxNotSelected : IValidationRule<int>
    {
        public string ValidationMessage { get; set; }

        public bool Check(int foundIndex)
        {
            if (foundIndex == 0)
            {
                return false;
            }
            return true;
        }

        public string ReturnError(int value)
        {
            return null;
        }
    }
}
