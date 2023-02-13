using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Likekero.Validations;
using Likekero.Validations.Rules;
using Xamarin.Forms;

namespace Likekero.ViewModels.Login
{
    public class SignupViewModel : BaseViewModel
    {
        private ValidatableObject<string> firstName;
        public ValidatableObject<string> FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private ValidatableObject<string> lastName;
        public ValidatableObject<string> LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        private ValidatableObject<string> email;
        public ValidatableObject<string> Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private ValidatableObject<string> password;
        public ValidatableObject<string> Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private bool over14;
        public bool Over14
        {
            get { return over14; }
            set { SetProperty(ref over14, value); }
        }

        private bool termsAndConditions;
        public bool TermsAndConditions
        {
            get { return termsAndConditions; }
            set { SetProperty(ref termsAndConditions, value); }
        }

        public ICommand SignUpCommand { get; set; }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public SignupViewModel()
        {
            firstName = new ValidatableObject<string>();
            lastName = new ValidatableObject<string>();
            email = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            Over14 = TermsAndConditions = true;
            AddValidations();
            SignUpCommand = new Command(SignUp);
        }

        private void AddValidations()
        {
            firstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name is required." });
            lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name is required." });
            email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required." });
            email.Validations.Add(new EmailValidation<string> { ValidationMessage = "Email is invalid." });
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is required." });
            password.Validations.Add(new PasswordValidation<string> { ValidationMessage = "Password must be at least 6 characters long." });
        }

        private async void SignUp()
        {
            if (!Validate()) return;
            //if (!IsValid())
            //{
            //    // Add logic for sign up process here
            //}
            await Application.Current.MainPage.DisplayAlert("Likekero", "Save successful", "Ok");
        }

        private bool Validate()
        {
            bool isValidFirstName = firstName.Validate();
            bool isValidLastName = lastName.Validate();
            bool isValidEmail = email.Validate();
            bool isValidPassword = password.Validate();

            return isValidFirstName && isValidLastName && isValidEmail && isValidPassword;
        }

        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(FirstName.Value))
            {
                ErrorMessage = "First Name is required.";
                FirstName.Errors.Add(ErrorMessage);
            }

            if (string.IsNullOrWhiteSpace(LastName.Value))
            {
                ErrorMessage = "Last Name is required.";
                LastName.Errors.Add(ErrorMessage);
            }

            if (string.IsNullOrWhiteSpace(Email.Value) || !IsValidEmail(Email.Value))
            {
                ErrorMessage = "Email is invalid.";
                Email.IsValid = false;
                Email.Errors.Add(ErrorMessage);
            }

            if (string.IsNullOrWhiteSpace(Password.Value) || Password.Value.Length < 6)
            {
                ErrorMessage = "Password must be at least 6 characters long.";
                Password.IsValid = false;
                Password.Errors.Add(ErrorMessage);
            }

            if (!Over14)
            {
                ErrorMessage = "You must be over 14 years old to sign up.";
            }

            ErrorMessage = string.Empty;
            return true;
        }

        private bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            return regex.IsMatch(email);
        }
    }
}
