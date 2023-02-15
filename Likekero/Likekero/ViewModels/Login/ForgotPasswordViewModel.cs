using System;
using System.Windows.Input;
using Likekero.Navigation;
using Likekero.Validations;
using Likekero.Validations.Rules;
using Likekero.Views;
using Xamarin.Forms;

namespace Likekero.ViewModels.Login
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        private ValidatableObject<string> email;
        public ValidatableObject<string> Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        public ICommand SubmitCommand { get; set; }

        private INavigationService _navigationService;

        public ForgotPasswordViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            email = new ValidatableObject<string>();
            AddValidations();
            SubmitCommand = new Command(Submit);
        }

        private async void Submit(object obj)
        {
            if (Email.Validate())
                await Application.Current.MainPage.Navigation.PushAsync(new Otp());
            //await _navigationService.NavigateToAsync(typeof(OTPViewModel));
        }

        private void AddValidations()
        {
            email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required." });
            email.Validations.Add(new EmailValidation<string> { ValidationMessage = "Email is invalid." });
        }
    }
}
