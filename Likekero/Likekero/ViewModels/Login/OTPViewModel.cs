using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Likekero.Navigation;
using Likekero.Views;
using Xamarin.Forms;

namespace Likekero.ViewModels.Login
{
    public class OTPViewModel : BaseViewModel
    {
        private string _otp1;
        public string OTP1
        {
            get { return _otp1; }
            set { SetProperty(ref _otp1, value); }
        }

        private string _otp2;
        public string OTP2
        {
            get { return _otp2; }
            set { SetProperty(ref _otp2, value); }
        }

        private string _otp3;
        public string OTP3
        {
            get { return _otp3; }
            set { SetProperty(ref _otp3, value); }
        }

        private string _otp4;
        public string OTP4
        {
            get { return _otp4; }
            set { SetProperty(ref _otp4, value); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        public ICommand SubmitCommand { get; set; }

        private readonly INavigationService _navigationService;
        public OTPViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SubmitCommand = new Command(Submit);
        }

        private async void Submit(object obj)
        {
            if (string.IsNullOrEmpty(OTP1) || string.IsNullOrEmpty(OTP2) ||
            string.IsNullOrEmpty(OTP3) || string.IsNullOrEmpty(OTP4))
            {
                ErrorMessage = "Please enter all 4 digits of the OTP.";
            }
            else
            {
                ErrorMessage = "";
                await Application.Current.MainPage.Navigation.PushAsync(new ResetPassword());
                //await _navigationService.NavigateToAsync(typeof(ResetPasswordViewModel));
                //await _navigationService.NavigateBackAsync();
            }

        }
    }
}
