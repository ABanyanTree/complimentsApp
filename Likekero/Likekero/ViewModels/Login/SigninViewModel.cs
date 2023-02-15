using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Likekero.Navigation;
using Likekero.Validations;
using Likekero.Validations.Rules;
using Likekero.Views;
using Xamarin.Forms;

namespace Likekero.ViewModels.Login
{
    public class SigninViewModel : BaseViewModel
    {
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

        
        public ICommand SigninCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public ICommand SignupCommand { get; set; }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private readonly INavigationService _navigationService;
        public SigninViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            email = new ValidatableObject<string>();
            password = new ValidatableObject<string>();
            
            AddValidations();
            SigninCommand = new Command(Signin);
            SignupCommand = new Command(Signup);
            ForgotPasswordCommand = new Command(ForgotPassword);
        }

        private void AddValidations()
        {
            email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required." });
            email.Validations.Add(new EmailValidation<string> { ValidationMessage = "Email is invalid." });
            password.Validations.Add(new PasswordValidation<string>());
        }

        private async void Signin()
        {
            if (!Validate()) return;
            //await Application.Current.MainPage.DisplayAlert("Likekero", "Save successful", "Ok");
            await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//AboutPage");
        }

        private async void ForgotPassword(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPassword());
            //_navigationService.NavigateToAsync(typeof(ForgotPasswordViewModel));
        }

        private async void Signup(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Signup());
            //await Shell.Current.Navigation.PushAsync(new Signup());
            //_navigationService.NavigateToAsync(typeof(SignupViewModel));
        }

        private bool Validate()
        {
            bool isValidEmail = email.Validate();
            bool isValidPassword = password.ValidatePassword();

            return isValidEmail && isValidPassword;
        }

        //private bool IsValid()
        //{
        //    if (string.IsNullOrWhiteSpace(FirstName.Value))
        //    {
        //        ErrorMessage = "First Name is required.";
        //        FirstName.Errors.Add(ErrorMessage);
        //    }

        //    if (string.IsNullOrWhiteSpace(LastName.Value))
        //    {
        //        ErrorMessage = "Last Name is required.";
        //        LastName.Errors.Add(ErrorMessage);
        //    }

        //    if (string.IsNullOrWhiteSpace(Email.Value) || !IsValidEmail(Email.Value))
        //    {
        //        ErrorMessage = "Email is invalid.";
        //        Email.IsValid = false;
        //        Email.Errors.Add(ErrorMessage);
        //    }

        //    if (string.IsNullOrWhiteSpace(Password.Value) || Password.Value.Length < 6)
        //    {
        //        ErrorMessage = "Password must be at least 6 characters long.";
        //        Password.IsValid = false;
        //        Password.Errors.Add(ErrorMessage);
        //    }

        //    if (!Over14)
        //    {
        //        ErrorMessage = "You must be over 14 years old to sign up.";
        //    }

        //    ErrorMessage = string.Empty;
        //    return true;
        //}
    }
}
