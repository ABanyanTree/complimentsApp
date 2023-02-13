using System;
using Likekero.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        private SignupViewModel viewModel;
        public ForgotPassword()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignupViewModel();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Email.Validate();
            viewModel.Password.Validate();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginOtp());
        }
    }
}