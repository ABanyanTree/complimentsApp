using System;
using Likekero.ViewModels.Login;
using Likekero.Views.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Likekero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        private SignupViewModel viewModel;

        public Signup()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignupViewModel();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.FirstName.Validate();
            viewModel.LastName.Validate();
            viewModel.Email.Validate();
            viewModel.Password.Validate();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
    }
}