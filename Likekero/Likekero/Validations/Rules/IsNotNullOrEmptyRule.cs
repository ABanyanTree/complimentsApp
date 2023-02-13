﻿namespace Likekero.Validations.Rules
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
    }
}