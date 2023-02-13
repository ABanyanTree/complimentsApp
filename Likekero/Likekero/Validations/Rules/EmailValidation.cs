using System.Text.RegularExpressions;

namespace Likekero.Validations.Rules
{
    class EmailValidation<T> : IValidationRule<T>
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

            var regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            var match = regex.Match(str);
            return match.Success;
        }
    }
}
