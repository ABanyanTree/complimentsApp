using System;
using Likekero.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        private SignupViewModel viewModel;
        public SignIn()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignupViewModel();
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Email.Validate();
            viewModel.Password.Validate();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }

        private async void ForgotPassword_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }
    }
}