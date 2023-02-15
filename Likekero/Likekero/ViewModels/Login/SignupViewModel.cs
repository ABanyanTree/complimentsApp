using System;
using System.Windows.Input;
using Likekero.Navigation;
using Likekero.Validations;
using Likekero.Validations.Rules;
using Likekero.Views.Login;
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

        public ICommand SigninCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        private INavigationService _navigationService;

        public SignupViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            firstName = new ValidatableObject<string>();
            lastName = new ValidatableObject<string>();
            email = new ValidatableObject<string>();
            password = new ValidatableObject<string>();
            SigninCommand = new Command(Signin);
            SignUpCommand = new Command(SignUp);
            Over14 = TermsAndConditions = true;
            AddValidations();
        }

        private void AddValidations()
        {
            firstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name is required." });
            lastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name is required." });
            email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required." });
            email.Validations.Add(new EmailValidation<string> { ValidationMessage = "Email is invalid." });
            password.Validations.Add(new PasswordValidation<string>());
            //password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is required." });
            //password.Validations.Add(new PasswordValidation<string> { ValidationMessage = "Password must be at least 6 characters long and contain at least one capital letter, number and one special character." });
        }
        private async void Signin(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignIn());
            //_navigationService.NavigateToAsync(typeof(SigninViewModel));
        }
        private async void SignUp(object obj)
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
            bool isValidPassword = password.ValidatePassword();

            return isValidFirstName && isValidLastName && isValidEmail && isValidPassword;
        }
    }
}
