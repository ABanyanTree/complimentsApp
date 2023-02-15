using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Likekero.Navigation;
using Likekero.Validations;
using Likekero.Validations.Rules;
using Likekero.Views.Login;
using Xamarin.Forms;

namespace Likekero.ViewModels.Login
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        public ResetPasswordViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            newPassword = new ValidatableObject<string>();
            confirmPassword = new ValidatableObject<string>();
            SubmitCommand = new Command(Submit);

            AddValidations();
        }

        private ValidatableObject<string> newPassword;
        public ValidatableObject<string> NewPassword
        {
            get { return newPassword; }
            set { SetProperty(ref newPassword, value); }
        }

        private ValidatableObject<string> confirmPassword;
        public ValidatableObject<string> ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }
        public ICommand SubmitCommand { get; set; }

        private void AddValidations()
        {
            newPassword.Validations.Add(new PasswordValidation<string>());
            confirmPassword.Validations.Add(new PasswordValidation<string>());
        }
        private async void Submit(object obj)
        {
            bool isNewPasswordOk = NewPassword.ValidatePassword();
            bool isConfirmPasswordOk = ConfirmPassword.ValidatePassword();
            if (isNewPasswordOk && isConfirmPasswordOk && NewPassword.Value != ConfirmPassword.Value)
                await Application.Current.MainPage.DisplayAlert("Error", "Values entered in the New Password and Confirm Password fields do not match", "Ok");

            bool res = await Application.Current.MainPage.DisplayAlert("Likekero", "Password has been reset. Please login with the new password.", "Ok", "");
            if (res) 
                await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
